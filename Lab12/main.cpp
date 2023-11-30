#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>

// ID ��������� ���������
GLuint Program;
// ID ��������
GLint Attrib_vertex;
// ID Vertex Buffer Object
GLuint VBO;
GLint Unif_xmove;
GLint Unif_zmove;
GLint Unif_ymove;

GLint UniformColor;

struct Vertex {
	GLfloat x;
	GLfloat y;
};

struct VertexG {
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

out vec3 vertexColor; 
void main() {
	vec3 position = vec3(coord) + vec3(x_move, y_move, z_move);
    gl_Position = vec4(position, 1.0);
    vertexColor = color; // �������� ����� �� ����������� ������
}
)";


// �������� ��� ������������ ������� ��� ������������ ������������
const char* FragShaderSource_Gradient = R"(
#version 330 core
in vec3 vertexColor; // �������� ���� �� ���������� �������
out vec4 color;
void main() {
    color = vec4(vertexColor, 1.0); // ���������� ���� �� �������
}
)";

float moveX = 0;
float moveY = 0;
float moveZ = 0;
void moveShape(float moveXinc, float moveYinc, float moveZinc) {
	moveX += moveXinc;
	moveY += moveYinc;
	moveZ += moveZinc;
}

void ShaderLog(unsigned int shader)
{
	int infologLen = 0;
	glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
	if (infologLen > 1)
	{
		int charsWritten = 0;
		std::vector<char> infoLog(infologLen);
		glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
		std::cout << "InfoLog: " << infoLog.data() << std::endl;
	}
}

void checkOpenGLerror()
{
	GLenum err;
	while ((err = glGetError()) != GL_NO_ERROR)
	{
		// Process/log the error.
		std::cout << err << std::endl;
	}
}

void InitShader(int num_task) {
	GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	ShaderLog(vShader);
	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fShader, 1, &FragShaderSource_Gradient, NULL);

	glCompileShader(fShader);
	std::cout << "fragment shader \n";
	ShaderLog(fShader);
	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);
	glLinkProgram(Program);
	int link_ok;
	glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
	if (!link_ok) {
		std::cout << "error attach shaders \n";
		return;
	}
	// ���������� ID �������� �� ��������� ���������
	const char* attr_name = "coord"; //��� � �������
	Attrib_vertex = glGetAttribLocation(Program, attr_name);
	if (Attrib_vertex == -1) {
		std::cout << "could not bind attrib " << attr_name << std::endl;
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

void InitVBO(int num_task) {
	glGenBuffers(1, &VBO);
	//��������
	VertexG triangle[] = {
		{ 0.2f, 0.45f, -0.5f,0.0f, 0.0f, 1.0f },
		{ -0.6f, 0.f, -0.5f ,1.0f, 0.0f , 0.0f },
		{ 0.f, 0.f, 0.5f ,1.0f, 1.0f, 1.0f },

		{ -0.6f, 0.f, -0.5f,1.0f, 0.0f, 0.0f },
		{ 0.f, 0.f, 0.5f , 1.0f, 1.0f, 1.0f},
		{ 0.2f, -0.45f, -0.5f , 0.0f, 1.0f, 0.0f},

		{ 0.f, 0, 0.5f ,1.0f, 1.0f, 1.0f},
		{ 0.2f, 0.45f, -0.5f,0.0f, 0.0f, 1.0f },
		{ 0.2f, -0.45f, -0.5f,0.0f, 1.0f, 0.0f },
	};

	// ���
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
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	if (num_task == 1)
		glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
	else if (num_task == 2)
		glBufferData(GL_ARRAY_BUFFER, sizeof(cube), cube, GL_STATIC_DRAW);

	checkOpenGLerror(); //������ ������� ���� � ������������
}

void Init(int num_task) {
	// �������
	InitShader(num_task);
	// ��������� �����
	InitVBO(num_task);

	glEnable(GL_DEPTH_TEST);
}

void Draw(int num_task) {

	glUseProgram(Program); // ������������� ��������� ��������� �������

	glUniform1f(Unif_xmove, moveX);
	glUniform1f(Unif_ymove, moveY);
	glUniform1f(Unif_zmove, moveZ);

	glEnableVertexAttribArray(0);
	glEnableVertexAttribArray(1);

	glBindBuffer(GL_ARRAY_BUFFER, VBO);


	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)0);

	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));

	if (num_task == 1) {
		glDrawArrays(GL_TRIANGLES, 0, 9);
	}
	else if (num_task == 2) {

		glDrawArrays(GL_QUADS, 0, 12);
	}


	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glUseProgram(0);
	checkOpenGLerror();
}


// ������������ ������
void ReleaseVBO() {
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDeleteBuffers(1, &VBO);
}

// ������������ ��������
void ReleaseShader() {
	// ��������� ����, �� ��������� ��������� ���������
	glUseProgram(0);
	// ������� ��������� ���������
	glDeleteProgram(Program);
}


void Release() {
	// �������
	ReleaseShader();
	// ��������� �����
	ReleaseVBO();
}

void WindowWork(int num_task) {
	sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
	window.setVerticalSyncEnabled(true);
	window.setActive(true);
	glewInit();
	Init(num_task);

	bool work = true;
	while (work) {
		sf::Event event;
		while (window.pollEvent(event)) {
			if (event.type == sf::Event::Closed) { work = false; }
			else if (event.type == sf::Event::Resized)
			{
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