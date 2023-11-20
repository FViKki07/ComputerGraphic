#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>

// ID шейдерной программы
GLuint Program;
// ID атрибута
GLint Attrib_vertex;
// ID Vertex Buffer Object
GLuint VBO;

GLint UniformColor;

struct Vertex {
	GLfloat x;
	GLfloat y;
};

// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
#version 330 core
in vec2 coord;
void main() {
gl_Position = vec4(coord, 0.0, 1.0);
}
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
#version 330 core
out vec4 color;
void main() {
color = vec4(1, 0.643, 0.455, 1);
}
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource_Uniform = R"(
#version 330 core
out vec4 color;
uniform vec4 objectColor; // uniform-переменная для передачи цвета
void main() {
    color = objectColor; // Используем переданный цвет
}
)";



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
	if (num_task == 2) {
		glShaderSource(fShader, 1, &FragShaderSource, NULL);
	}
	else if (num_task == 3) {
		glShaderSource(fShader, 1, &FragShaderSource_Uniform, NULL);
	}
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
	}// Вытягиваем ID атрибута из собранной программы
	const char* attr_name = "coord"; //имя в шейдере
	Attrib_vertex = glGetAttribLocation(Program, attr_name);
	if (Attrib_vertex == -1) {
		std::cout << "could not bind attrib " << attr_name << std::endl;
		return;
	}


	//UniformColor = glGetUniformLocation(Program, "objectColor");
	//if (UniformColor == 0) {
	//	glUniform4f(UniformColor, 0.5, 0.5, 0.1, 0.1);
	//}

	checkOpenGLerror();
}

void InitVBO() {
	glGenBuffers(1, &VBO);
	// Вершины нашего треугольника
	Vertex triangle[15] = {
		// Квадрат
		{ -0.85f, 0.1f },
		{ -0.15f, 0.1f },
		{ -0.15f, 0.9f },
		{ -0.85f, 0.9f },
		// Веер
		{ 0.5f, 0.2f },
		{ 0.0f, 0.65f },
		{ 0.25f, 0.8f },
		{ 0.5f, 0.85f },
		{ 0.75f, 0.8f },
		{ 1.0f, 0.65f },
		// Правильный пятиуголник
		{ -0.365f, -1.0f },
		{ -0.6f, -0.3f },
		{ 0.0f, 0.1f },
		{ 0.6f, -0.3f },
		{ 0.365f, -1.0f },
	};
	// Передаем вершины в буфер
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
	checkOpenGLerror(); //Пример функции есть в лабораторной
}

void Init(int num_task) {
	// Шейдеры
	InitShader(num_task);
	// Вершинный буфер
	InitVBO();
}

void Draw(int num_task) {

	glUseProgram(Program); // Устанавливаем шейдерную программу текущей

	if (num_task == 3)
		glUniform4f(UniformColor, 0.5, 0.5, 0.75, 0.75);

	glEnableVertexAttribArray(Attrib_vertex);
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	// Указывая pointer 0 при подключенном буфере, мы указываем что данные в VBO
	glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0);
	glBindBuffer(GL_ARRAY_BUFFER, 0); // Отключаем VBO
	glDrawArrays(GL_QUADS, 0, 4);

	// Веер
	glDrawArrays(GL_TRIANGLE_FAN, 4, 6);

	// Пятиугольник
	glDrawArrays(GL_TRIANGLE_FAN, 10, 5);

	glDisableVertexAttribArray(Attrib_vertex);
	glUseProgram(0);
	checkOpenGLerror();
}


// Освобождение буфера
void ReleaseVBO() {
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDeleteBuffers(1, &VBO);
}

// Освобождение шейдеров
void ReleaseShader() {
	// Передавая ноль, мы отключаем шейдерную программу
	glUseProgram(0);
	// Удаляем шейдерную программу
	glDeleteProgram(Program);
}


void Release() {
	// Шейдеры
	ReleaseShader();
	// Вершинный буфер
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
			else if (event.type == sf::Event::Resized) { glViewport(0, 0, event.size.width, event.size.height); }
		}
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		Draw(num_task);
		window.display();
	}
	Release();
	window.close();

}

int main() {
	int num_task = 0;
	while (true) {
		std::cout << "Enter task: ";
		std::cin >> num_task;
		if (num_task == 4 || num_task == 2 || num_task == 3)
			WindowWork(num_task);
	}
	return 0;
}