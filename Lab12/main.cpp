#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#define _USE_MATH_DEFINES
#include "math.h"

#include <iostream>
#include <array>
#include <initializer_list>

// ���������� � ����������������� ID
// ID ��������� ���������
GLuint Program;
// ID �������� ������
GLint Attrib_vertex;
// ID �������� �����
GLint Attrib_color;
// ID ������� ���������� �����
GLint Unif_xmove;
GLint Unif_zmove;
GLint Unif_ymove;
// ID VBO ������
GLuint VBO_position;
// ID VBO �����
GLuint VBO_color;
// �������
struct Vertex
{
	GLfloat x;
	GLfloat y;
	GLfloat z;
};

struct VertexG
{
	GLfloat x;
	GLfloat y;
	GLfloat z;
	GLfloat r;
	GLfloat g;
	GLfloat b;
};



// �������� ��� ���������� �������
const char* VertexShaderSource = R"(
    #version 330 core
    in vec3 coord;
    in vec3 color;

    uniform float x_move;
    uniform float y_move;
    uniform float z_move;

    out vec3 vert_color;

    void main() {
        vec3 position =  vec3(coord.x + x_move, coord.y + y_move, coord.z + z_move);
        gl_Position = vec4(position, 1.0);
        vert_color = color;
    }
)";

// �������� ��� ������������ �������
const char* FragShaderSource = R"(
    #version 330 core
    in vec3 vert_color;

    out vec4 color;
    void main() {
        color = vec4(vert_color, 1.0);
    }
)";


void Init(int num_task);
void Draw(int num_task);
void Release();

float moveX = 0;
float moveY = 0;
float moveZ = 0;
void moveShape(float moveXinc, float moveYinc, float moveZinc) {
	moveX += moveXinc;
	moveY += moveYinc;
	moveZ += moveZinc;
}


// �������� ������ OpenGL, ���� ���� �� ����� � ������� ��� ������
void checkOpenGLerror() {
	GLenum errCode;
	// ���� ������ ����� �������� ���
	// https://www.khronos.org/opengl/wiki/OpenGL_Error
	if ((errCode = glGetError()) != GL_NO_ERROR)
		std::cout << "OpenGl error!: " << errCode << std::endl;
}

// ������� ������ ���� �������
void ShaderLog(unsigned int shader)
{
	int infologLen = 0;
	int charsWritten = 0;
	char* infoLog;
	glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
	if (infologLen > 1)
	{
		infoLog = new char[infologLen];
		if (infoLog == NULL)
		{
			std::cout << "ERROR: Could not allocate InfoLog buffer" << std::endl;
			exit(1);
		}
		glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog);
		std::cout << "InfoLog: " << infoLog << "\n\n\n";
		delete[] infoLog;
	}
}

void InitVBO(int num_task)
{
	glGenBuffers(1, &VBO_position);
	glGenBuffers(1, &VBO_color);

	// ������� ���������
	Vertex triangle[] = {
	   { 0.2, 0.45, -0.5 }, { -0.6, 0, -0.5 }, { 0, 0, 0.5 },
	   { -0.6, 0, -0.5 }, { 0, 0, 0.5 }, { 0.2, -0.45, -0.5 },
	   { 0, 0, 0.5 }, { 0.2, 0.45, -0.5 }, { 0.2, -0.45, -0.5 },

	};
	float colors[9][4] = {
		{ 0.0, 0.0, 1.0, 1.0 }, { 1.0, 0.0, 0.0, 1.0 }, { 1.0, 1.0, 1.0, 1.0 },
		{ 1.0, 0.0, 0.0, 1.0 }, { 1.0, 1.0, 1.0, 1.0 }, { 0.0, 1.0, 0.0, 1.0 },
		{ 1.0, 1.0, 1.0, 1.0 }, { 0.0, 0.0, 1.0, 1.0 }, { 0.0, 1.0, 0.0, 1.0 },
	};


	//������� ���� 
	VertexG cube[] = {
		// �������� �����
	  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f }, // ����� ���
	  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f }, // ������ ���
	  { 0.25f, 0.5f, 0.5f, 0.0f, 1.0f, 0.0f }, // ������ �����
	  { -0.5f, 0.25f, 0.5f, 0.0f, 0.0f, 1.0f }, // ����� �����

	  // ������ �����
	  { 0.5f, -0.25f, -0.5f, 1.0f, 1.0f, 0.0f  }, // ����� ���
	  { 0.25f, 0.5f, -0.5f, 0.0f, 1.0f, 0.0f  }, // ����� �����
	  { 0.5f, 0.5f, -0.5f, 0.1f, 0.6f, 0.4f }, // ������ �����
	  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f }, // ������ ���

	  // ������ �����
	  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f }, // ����� ��� 
	  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f }, // ����� �����
	  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f }, // ������ �����
	  { 0.0f, -0.5f, -0.5f, 1.0f, 1.0f, 0.0f }, // ������ ���
	};

	// �������� ������� � �����
	if (num_task == 1) {
		glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
		glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
		glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
		glBufferData(GL_ARRAY_BUFFER, sizeof(colors), colors, GL_STATIC_DRAW);
	}
	else if (num_task == 2) {
		glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
		glBufferData(GL_ARRAY_BUFFER, sizeof(cube), cube, GL_STATIC_DRAW);
	}
	checkOpenGLerror();
}


void InitShader() {
	// ������� ��������� ������
	GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
	// �������� �������� ���
	glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	// ����������� ������
	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	ShaderLog(vShader);

	// ������� ����������� ������
	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	// �������� �������� ���
	glShaderSource(fShader, 1, &FragShaderSource, NULL);
	// ����������� ������
	glCompileShader(fShader);
	std::cout << "fragment shader \n";
	ShaderLog(fShader);

	// ������� ��������� � ����������� ������� � ���
	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);

	// ������� ��������� ���������
	glLinkProgram(Program);
	// ��������� ������ ������
	int link_ok;
	glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
	if (!link_ok)
	{
		std::cout << "error attach shaders \n";
		return;
	}

	// ���������� ID �������� ������ �� ��������� ���������
	Attrib_vertex = glGetAttribLocation(Program, "coord");
	if (Attrib_vertex == -1)
	{
		std::cout << "could not bind attrib coord" << std::endl;
		return;
	}

	// ���������� ID �������
	const char* unif_name = "x_move";
	Unif_xmove = glGetUniformLocation(Program, unif_name);
	if (Unif_xmove == -1)
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}

	unif_name = "y_move";
	Unif_ymove = glGetUniformLocation(Program, unif_name);
	if (Unif_ymove == -1)
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}

	unif_name = "z_move";
	Unif_zmove = glGetUniformLocation(Program, unif_name);
	if (Unif_zmove == -1)
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}
	checkOpenGLerror();
}

void Init(int num_task) {
	InitShader();
	InitVBO(num_task);
	glEnable(GL_DEPTH_TEST);
}


void Draw(int num_task) {
	// ������������� ��������� ��������� �������
	glUseProgram(Program);

	glUniform1f(Unif_xmove, moveX);
	glUniform1f(Unif_ymove, moveY);
	glUniform1f(Unif_zmove, moveZ);

	if (num_task == 1) {
		// �������� ������� ���������
		glEnableVertexAttribArray(Attrib_vertex);
		glEnableVertexAttribArray(Attrib_color);

		// ���������� VBO_position
		glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
		glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 0, 0);

		// ���������� VBO_color
		glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
		glVertexAttribPointer(Attrib_color, 4, GL_FLOAT, GL_FALSE, 0, 0);
	}
	else if (num_task == 2) {
		// �������� ������ ��������� ������
		glEnableVertexAttribArray(Attrib_vertex);
		glEnableVertexAttribArray(Attrib_color);

		// ���������� VBO_position
		glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
		glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)0);

		// ������� � ������������

		// ���������� VBO_color
		glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
		glVertexAttribPointer(Attrib_color, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	}

	// ��������� VBO
	glBindBuffer(GL_ARRAY_BUFFER, 0);

	// ������
	if (num_task == 1)
		glDrawArrays(GL_TRIANGLES, 0, 9);
	else
		glDrawArrays(GL_TRIANGLES, 0, 36);

	// ��������� ������� ���������
	glDisableVertexAttribArray(Attrib_vertex);
	glDisableVertexAttribArray(Attrib_color);

	// ���������� ��������� �������� �� ��������� (0)
	glUseProgram(0);

	// �������� ������ OpenGL
	checkOpenGLerror();
}



// ������������ ��������
void ReleaseShader() {
	// ��������� ����, �� ��������� �������� ���������
	glUseProgram(0);
	// ������� ��������� ���������
	glDeleteProgram(Program);
}

// ������������ ������
void ReleaseVBO()
{
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDeleteBuffers(1, &VBO_position);
	glDeleteBuffers(1, &VBO_color);
}

void Release() {
	ReleaseShader();
	ReleaseVBO();
}

void WindowWork(int num_task) {
	sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
	window.setVerticalSyncEnabled(true);

	window.setActive(true);

	// ������������� glew
	glewInit();

	Init(num_task);

	while (window.isOpen()) {
		sf::Event event;
		while (window.pollEvent(event)) {
			if (event.type == sf::Event::Closed) {
				window.close();
			}
			else if (event.type == sf::Event::Resized) {
				glViewport(0, 0, event.size.width, event.size.height);
			}
			else if (event.type == sf::Event::KeyPressed) {
				switch (event.key.code) {
				case (sf::Keyboard::W): moveShape(0, 0.1, 0); break;
				case (sf::Keyboard::S): moveShape(0, -0.1, 0); break;
				case (sf::Keyboard::A): moveShape(-0.1, 0, 0); break;
				case (sf::Keyboard::D): moveShape(0.1, 0, 0); break;
				case (sf::Keyboard::Q): moveShape(0, 0, -0.2); break;
				case (sf::Keyboard::E): moveShape(0, 0, 0.2); break;
				default: break;
				}
			}
		}

		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		Draw(num_task);

		window.display();
	}

	Release();
}

int main() {
	int num_task = 0;
	while (true) {
		std::cout << "Enter task: ";
		std::cin >> num_task;
		if (num_task == 4 || num_task == 2 || num_task == 3 || num_task == 1)
			WindowWork(num_task);
	}
	return 0;
}