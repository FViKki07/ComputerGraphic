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

//GLuint texture1;
//GLuint texture2;
sf::Texture texture1;
sf::Texture texture2;
GLuint Unif_texture1;
GLuint Unif_texture2;
GLuint Unif_reg;

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

struct VertexT {
	GLfloat x;
	GLfloat y;
	GLfloat z;
	GLfloat r;
	GLfloat g;
	GLfloat b;
	GLfloat S;
	GLfloat T;
};

struct VertexT2 {
	GLfloat x;
	GLfloat y;
	GLfloat z;
	GLfloat r;
	GLfloat g;
	GLfloat b;
	GLfloat S1;
	GLfloat T1;
	GLfloat S2;
	GLfloat T2;
};

// �������� ��� ���������� �������
const char* VertexShaderSource = R"(
#version 330 core
layout (location = 0) in vec3 coord;
layout (location = 1) in vec3 color; 

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

//cube with color and texture
const char* VertexShaderSource_WithTex = R"(
#version 330 core
layout (location = 0) in vec3 position;
layout (location = 1) in vec3 color;
layout (location = 2) in vec2 texCoord;

out vec3 ourColor;
out vec2 TexCoord;

void main() {
	gl_Position = vec4(position, 1.0f);
	ourColor = color;
	TexCoord = texCoord;
}
)";


//cube with color and texture
const char* FragShaderSource_WithTex = R"(
#version 330 core
in vec3 ourColor;
in vec2 TexCoord;

out vec4 ColorMix;

uniform sampler2D texture1;
uniform float reg;

void main() {
	ColorMix = mix(vec4(ourColor, 1.0), texture(texture1, TexCoord), reg); 
}

)";

//cube with 2 texture
const char* VertexShaderSource_WithTex2 = R"(
#version 330 core
layout (location = 0) in vec3 position;
layout (location = 2) in vec2 texCoord1;
layout (location = 3) in vec2 texCoord2;

out vec2 TexCoord1;
out vec2 TexCoord2;

void main() {
	gl_Position = vec4(position, 1.0f);
	 TexCoord1 = vec2(texCoord1.x, 1.0 - texCoord1.y);
     TexCoord2 = vec2(texCoord2.x, 1.0 - texCoord2.y);
}
)";

//cube with  2texture
const char* FragShaderSource_WithTex2 = R"(
#version 330 core
in vec2 TexCoord1;
in vec2 TexCoord2;

out vec4 ColorMix;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float reg;

void main() {

	vec4 texColor1 = texture(texture1, TexCoord1); // ���� �� ������ ��������
    vec4 texColor2 = texture(texture2, TexCoord2); // ���� �� ������ ��������
    // ��������� ����� �� ���� �������
    ColorMix = mix(texColor1, texColor2, reg);
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

float reg = 0.05;
// ������������� �������
void changeTexture(float r) {
	if (reg + r > 1 || reg + r < 0)
		return;
	reg += r;

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
	if(num_task == 1)
		glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	else if(num_task == 2) 
		glShaderSource(vShader, 1, &VertexShaderSource_WithTex, NULL);
	else if(num_task == 3)
		glShaderSource(vShader, 1, &VertexShaderSource_WithTex2, NULL);
	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	ShaderLog(vShader);

	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	if (num_task == 1)
		glShaderSource(fShader, 1, &FragShaderSource_Gradient, NULL);
	else if(num_task==2)
		glShaderSource(fShader, 1, &FragShaderSource_WithTex, NULL);
	else if(num_task==3)
		glShaderSource(fShader, 1, &FragShaderSource_WithTex2, NULL);
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
	if (Attrib_vertex == -1 && num_task == 1) {
		std::cout << "could not bind attrib " << attr_name << std::endl;
		return;
	}

	// ���������� ID �������
	const char* unif_name = "x_move";
	Unif_xmove = glGetUniformLocation(Program, unif_name);
	if (Unif_xmove == -1 && num_task == 1 )
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}

	unif_name = "y_move";
	Unif_ymove = glGetUniformLocation(Program, unif_name);
	if (Unif_ymove == -1 && num_task == 1)
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}

	unif_name = "z_move";
	Unif_zmove = glGetUniformLocation(Program, unif_name);
	if (Unif_zmove == -1 && num_task == 1)
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}

	Unif_reg = glGetUniformLocation(Program, "reg");
	if (Unif_reg == -1 && num_task != 1)
	{
		std::cout << "could not bind uniform " << "reg" << std::endl;
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

	// ��� � ������ � ���������
	VertexT cube[] = {
		// �������� �����
	  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f,0.0f, 0.0f }, // ����� ���
	  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f, 1.0f, 0.0f }, // ������ ���
	  { 0.25f, 0.5f, 0.5f, 0.0f, 1.0f, 0.0f, 1.0f, 1.0f }, // ������ �����
	  { -0.5f, 0.25f, 0.5f, 0.0f, 0.0f, 1.0f,0.0f, 1.0f }, // ����� �����

	  // ������ �����
	  { 0.5f, -0.25f, -0.5f, 1.0f, 1.0f, 0.0f,0.0f, 0.0f  }, // ����� ���
	  { 0.25f, 0.5f, -0.5f, 0.0f, 1.0f, 0.0f,0.0f, 1.0f  }, // ����� �����
	  { 0.5f, 0.5f, -0.5f, 0.1f, 0.6f, 0.4f, 1.0f, 1.0f }, // ������ �����
	  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f, 1.0f, 0.0f }, // ������ ���

	  // ������ �����
	  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f,0.0f, 0.0f }, // ����� ��� 
	  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f,0.0f, 1.0f }, // ����� �����
	  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f, 1.0f, 1.0f }, // ������ �����
	  { 0.0f, -0.5f, -0.5f, 1.0f, 1.0f, 0.0f, 1.0f, 0.0f }, // ������ ���

	};

	// ��� � 2 ���������� � ������
	VertexT2 cube2[] = {
		// �������� �����
	  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f,0.0f, 0.0f ,0.0f,0.0f}, // ����� ���
	  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f, 1.0f, 0.0f,1.0f, 0.0f }, // ������ ���
	  { 0.25f, 0.5f, 0.5f, 0.0f, 1.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f }, // ������ �����
	  { -0.5f, 0.25f, 0.5f, 0.0f, 0.0f, 1.0f,0.0f, 1.0f,0.0f, 1.0f }, // ����� �����

	  // ������ �����
	  { 0.5f, -0.25f, -0.5f, 1.0f, 1.0f, 0.0f,0.0f, 0.0f,0.0f, 0.0f  }, // ����� ���
	  { 0.25f, 0.5f, -0.5f, 0.0f, 1.0f, 0.0f,0.0f, 1.0f,0.0f, 1.0f }, // ����� �����
	  { 0.5f, 0.5f, -0.5f, 0.1f, 0.6f, 0.4f, 1.0f, 1.0f,1.0f, 1.0f }, // ������ �����
	  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f, 1.0f, 0.0f ,1.0f, 0.0f}, // ������ ���

	  // ������ �����
	  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f,0.0f, 0.0f, 0.0f, 0.0f }, // ����� ��� 
	  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f,0.0f, 1.0f,0.0f, 1.0f }, // ����� �����
	  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f, 1.0f, 1.0f,1.0f, 1.0f }, // ������ �����
	  { 0.0f, -0.5f, -0.5f, 1.0f, 1.0f, 0.0f, 1.0f, 0.0f,1.0f, 0.0f }, // ������ ���

	};



	// �������� ������� � �����
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	if (num_task == 1)
		glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
	else if (num_task == 2)
		glBufferData(GL_ARRAY_BUFFER, sizeof(cube), cube, GL_STATIC_DRAW);
	else if(num_task == 3)
		glBufferData(GL_ARRAY_BUFFER, sizeof(cube2), cube2, GL_STATIC_DRAW);

	checkOpenGLerror(); //������ ������� ���� � ������������
}

void InitTextures() {


	if (!texture1.loadFromFile("tex2.png")) {
		std::cout << "could not find texture " << std::endl;
		return; // ������ �������� ��������
	}

	if (!texture2.loadFromFile("tex1.png")) {
		std::cout << "could not find texture " << std::endl;
		return; // ������ �������� ��������
	}

	Unif_texture1 = glGetUniformLocation(Program, "texture1");
	if (Unif_texture1 == -1)
	{
		std::cout << "could not bind uniform ourTexture1" << std::endl;
		return;
	}

	Unif_texture2 = glGetUniformLocation(Program, "texture2");
	if (Unif_texture2 == -1)
	{
		std::cout << "could not bind uniform ourTexture2" << std::endl;
		return;
	}
}


void Init(int num_task) {
	// �������
	InitShader(num_task);
	// ��������� �����
	InitVBO(num_task);
	if(num_task == 2 || num_task == 3)
		InitTextures();

	glEnable(GL_DEPTH_TEST);
}

void Draw(int num_task) {

	glUseProgram(Program); // ������������� ��������� ��������� �������

	glUniform1f(Unif_xmove, moveX);
	glUniform1f(Unif_ymove, moveY);
	glUniform1f(Unif_zmove, moveZ);

	glEnableVertexAttribArray(0);
	glEnableVertexAttribArray(1);
	glEnableVertexAttribArray(2);
	glEnableVertexAttribArray(3);

	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	if (num_task == 1) {
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)0);

		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	}
	else if (num_task == 2) {

		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
		// ������� � ������
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
		// ������� � ����������� ������������
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));

		glActiveTexture(GL_TEXTURE0);
		sf::Texture::bind(&texture1);
		glUniform1i(Unif_texture1, 0);

		glUniform1f(Unif_reg, reg);
	}
	else if (num_task == 3) {
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 10 * sizeof(GLfloat), (GLvoid*)0);
		// ������� � ����������� ������������
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, 10 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));
		glVertexAttribPointer(3, 2, GL_FLOAT, GL_FALSE, 10 * sizeof(GLfloat), (GLvoid*)(8 * sizeof(GLfloat)));

		glActiveTexture(GL_TEXTURE0);
		sf::Texture::bind(&texture1);
		glUniform1i(Unif_texture1, 0);

		glActiveTexture(GL_TEXTURE1);
		sf::Texture::bind(&texture2);
		glUniform1i(Unif_texture2, 1);

		glUniform1f(Unif_reg, reg);
	}


	if (num_task == 1) {
		glDrawArrays(GL_TRIANGLES, 0, 9);
	}
	else if (num_task == 2 || num_task ==3) {

		glDrawArrays(GL_QUADS, 0, 12);
		sf::Texture::bind(NULL);
	}


	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(2);
	glDisableVertexAttribArray(3);
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
				case (sf::Keyboard::Z): changeTexture(-0.05); break;
				case (sf::Keyboard::X): changeTexture(0.05); break;
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