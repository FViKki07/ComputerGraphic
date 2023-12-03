#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>
#include <array>
#define _USE_MATH_DEFINES
#include "math.h"

#define deg2rad M_PI /180.0

// ID шейдерной программы
GLuint Program;
// ID атрибута
GLint Attrib_vertex;
// ID атрибута цвета
GLint Attrib_color;
// ID Vertex Buffer Object
GLuint VBO;

GLint Unif_xmove;
GLint Unif_zmove;
GLint Unif_ymove;

GLint Unif_xscale;
GLint Unif_yscale;

//GLuint texture1;
//GLuint texture2;
sf::Texture texture1;
sf::Texture texture2;
GLuint Unif_texture1;
GLuint Unif_texture2;
GLuint Unif_reg;

GLint UniformColor;
GLboolean two_text;

const int circleVertexCount = 360;

struct Vertex {
	GLfloat x;
	GLfloat y;
	GLfloat r;
	GLfloat g;
	GLfloat b;
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


// Исходный код вершинного шейдера
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
    vertexColor = color; // Передача цвета во фрагментный шейдер
}
)";

// Исходный код фрагментного шейдера для градиентного закрашивания
const char* FragShaderSource_Gradient = R"(
#version 330 core
in vec3 vertexColor; // Получаем цвет от вершинного шейдера
out vec4 color;
void main() {
    color = vec4(vertexColor, 1.0); // Используем цвет от вершины
}
)";

//cube with texture
const char* VertexShaderSource_WithTex2 = R"(
#version 330 core
layout (location = 0) in vec3 position;
layout (location = 1) in vec3 color;
layout (location = 2) in vec2 texCoord;

out vec2 TexCoord;
out vec3 ourColor;

void main() {
	gl_Position = vec4(position, 1.0f);
	 TexCoord = vec2(texCoord.x, 1.0 - texCoord.y);
	ourColor = color;
}
)";

//cube with texture
const char* FragShaderSource_WithTex2 = R"(
#version 330 core
in vec2 TexCoord;
in vec3 ourColor; 
out vec4 ColorMix;

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform float reg;
uniform bool two_text;

void main() {

	vec4 texColor1 = texture(texture1, TexCoord); // Цвет из первой текстуры
    vec4 texColor2 = texture(texture2, TexCoord); // Цвет из второй текстуры
    // Смешиваем цвета из двух текстур
	if(two_text)
		ColorMix = mix(texColor1, texColor2, reg);
	else ColorMix = mix(vec4(ourColor, 1.0), texColor1, reg); 
}

)";

// Circle
const char* VertexShaderSource_Circle = R"(
    #version 330 core
    layout (location = 0) in vec2 coord;
    layout (location = 1) in vec4 color;

    uniform float x_scale;
    uniform float y_scale;
    
    out vec4 vert_color;

    void main() {
        vec3 position = vec3(coord, 1.0) * mat3(x_scale, 0, 0,
                                                0, y_scale, 0,
                                                0,    0,    1);
        gl_Position = vec4(position[0],position[1], 0.0, 1.0);
        vert_color = color;
    }
)";

// Circle
const char* FragShaderSource_Circle = R"(
    #version 330 core
    in vec4 vert_color;

    out vec4 color;
    void main() {
        color = vert_color;
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
// регулирование текстур
void changeTexture(float r) {
	if (reg + r > 1 || reg + r < 0)
		return;
	reg += r;

}

float scaleX = 1.0;
float scaleY = 1.0;
// масштабирование круга
void changeScale(float scaleXinc, float scaleYinc) {
	scaleX += scaleXinc;
	scaleY += scaleYinc;
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
	if (num_task == 1)
		glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	else if (num_task == 3 || num_task == 2)
		glShaderSource(vShader, 1, &VertexShaderSource_WithTex2, NULL);
	else if (num_task == 4)
		glShaderSource(vShader, 1, &VertexShaderSource_Circle, NULL);


	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	ShaderLog(vShader);

	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	if (num_task == 1)
		glShaderSource(fShader, 1, &FragShaderSource_Gradient, NULL);
	else if (num_task == 3 || num_task == 2)
		glShaderSource(fShader, 1, &FragShaderSource_WithTex2, NULL);
	else if (num_task == 4)
		glShaderSource(fShader, 1, &FragShaderSource_Circle, NULL);


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

	// Вытягиваем ID атрибута из собранной программы
	const char* attr_name = "coord"; //имя в шейдере
	Attrib_vertex = glGetAttribLocation(Program, attr_name);
	if (Attrib_vertex == -1 && num_task == 1) {
		std::cout << "could not bind attrib " << attr_name << std::endl;
		return;
	}

	// Вытягиваем ID юниформ
	const char* unif_name = "x_move";
	Unif_xmove = glGetUniformLocation(Program, unif_name);
	if (Unif_xmove == -1 && num_task == 1)
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
	if (Unif_reg == -1 && num_task != 1 && num_task != 4)
	{
		std::cout << "could not bind uniform " << "reg" << std::endl;
		return;
	}

	unif_name = "x_scale";
	Unif_xscale = glGetUniformLocation(Program, unif_name);
	if (Unif_xscale == -1 && num_task == 4)
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}

	unif_name = "y_scale";
	Unif_yscale = glGetUniformLocation(Program, unif_name);
	if (Unif_yscale == -1 && num_task == 4)
	{
		std::cout << "could not bind uniform " << unif_name << std::endl;
		return;
	}

	checkOpenGLerror();
}


std::array<float, 4> HSV2RGB(float hue, float saturation = 1.0, float value = 1.0)
{
	int hi = (int)floor(hue / 60) % 6;
	float f = hue / 60 - hi;
	float p = value * (1 - saturation);
	float q = value * (1 - f * saturation);
	float t = value * (1 - (1 - f) * saturation);
	switch (hi)
	{
	case 0: return { value, t,  p, 1.0 };
	case 1: return { q,  value,  p, 1.0 };
	case 2: return { p,  value,  t, 1.0 };
	case 3: return { p,  q,  value, 1.0 };
	case 4: return { t,  p,  value, 1.0 };
	case 5: return { value,  p,  q, 1.0 };
	default: return { 0, 0, 0, 0 };
	}
}

void InitVBO(int num_task) {
	glGenBuffers(1, &VBO);
	//тетраэдр
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

	// куб с цветом и текстурой
		//Передняя грань
	VertexT cube[] = {
		-0.5f, -0.5f, -0.5f,   1.0f, 0.0f, 0.0f,  0.0f, 0.0f,
		 0.5f, -0.5f, -0.5f,   0.0f, 1.0f, 0.0f,  1.0f, 0.0f,
		 0.5f,  0.5f, -0.5f,   1.0f, 1.0f, 0.0f,  1.0f, 1.0f,
		 0.5f,  0.5f, -0.5f,   1.0f, 1.0f, 0.0f,  1.0f, 1.0f,
		-0.5f,  0.5f, -0.5f,   0.0f, 0.0f, 1.0f,  0.0f, 1.0f,
		-0.5f, -0.5f, -0.5f,   1.0f, 0.0f, 0.0f,  0.0f, 0.0f,

		//Задняя грань 
		-0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  0.0f, 0.0f,
		 0.5f, -0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 0.0f,
		 0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 0.0f,  1.0f, 1.0f,
		 0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 0.0f,  1.0f, 1.0f,
		-0.5f,  0.5f,  0.5f,   0.0f, 1.0f, 0.0f,  0.0f, 1.0f,
		-0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  0.0f, 0.0f,

		//Левая грань
		-0.5f,  0.5f,  0.5f,   0.0f, 1.0f, 0.0f,  1.0f, 0.0f,
		-0.5f,  0.5f, -0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		-0.5f, -0.5f, -0.5f,   1.0f, 0.0f, 0.0f,  0.0f, 1.0f,
		-0.5f, -0.5f, -0.5f,   1.0f, 0.0f, 0.0f,  0.0f, 1.0f,
		-0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  0.0f, 0.0f,
		-0.5f,  0.5f,  0.5f,   0.0f, 1.0f, 0.0f,  1.0f, 0.0f,

		//Правая грань
		 0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 0.0f,  1.0f, 0.0f,
		 0.5f,  0.5f, -0.5f,   1.0f, 1.0f, 0.0f,  1.0f, 1.0f,
		 0.5f, -0.5f, -0.5f,   0.0f, 1.0f, 0.0f,  0.0f, 1.0f,
		 0.5f, -0.5f, -0.5f,   0.0f, 1.0f, 0.0f,  0.0f, 1.0f,
		 0.5f, -0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  0.0f, 0.0f,
		 0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 0.0f,  1.0f, 0.0f,

		 //Верхняя грань 
		-0.5f, -0.5f, -0.5f,   1.0f, 0.0f, 0.0f,  0.0f, 1.0f,
		 0.5f, -0.5f, -0.5f,   0.0f, 1.0f, 0.0f,  1.0f, 1.0f,
		 0.5f, -0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 0.0f,
		 0.5f, -0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 0.0f,
		-0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  0.0f, 0.0f,
		-0.5f, -0.5f, -0.5f,   1.0f, 0.0f, 0.0f,  0.0f, 1.0f,

		//Нижняя грань
		-0.5f,  0.5f, -0.5f,   0.0f, 0.0f, 1.0f,  0.0f, 1.0f,
		 0.5f,  0.5f, -0.5f,   1.0f, 1.0f, 0.0f,  1.0f, 1.0f,
		 0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 0.0f,  1.0f, 0.0f,
		 0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 0.0f,  1.0f, 0.0f,
		-0.5f,  0.5f,  0.5f,   0.0f, 1.0f, 0.0f,  0.0f, 0.0f,
		-0.5f,  0.5f, -0.5f,   0.0f, 0.0f, 1.0f,  0.0f, 1.0f

	};

	//VertexT cube[] = {
	//	// Передняя грань
	//  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f,0.0f, 0.0f }, // левая низ
	//  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f, 1.0f, 0.0f }, // правая низ
	//  { 0.25f, 0.5f, 0.5f, 0.0f, 1.0f, 0.0f, 1.0f, 1.0f }, // правая вверх
	//  { -0.5f, 0.25f, 0.5f, 0.0f, 0.0f, 1.0f,0.0f, 1.0f }, // левая вверх

	//  // Правая грань
	//  { 0.5f, -0.25f, -0.5f, 1.0f, 1.0f, 0.0f,0.0f, 0.0f  }, // левая низ
	//  { 0.25f, 0.5f, -0.5f, 0.0f, 1.0f, 0.0f,0.0f, 1.0f  }, // левая вверх
	//  { 0.5f, 0.5f, -0.5f, 0.1f, 0.6f, 0.4f, 1.0f, 1.0f }, // правая вверх
	//  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f, 1.0f, 0.0f }, // правая низ

	//  // Нижняя грань
	//  { -0.25f, -0.5f, 0.5f, 1.0f, 0.0f, 0.0f,0.0f, 0.0f }, // левая низ 
	//  { 0.5f, -0.25f, 0.5f, 1.0f, 1.0f, 0.0f,0.0f, 1.0f }, // левая вверх
	//  { 0.75f, -0.25f, -0.5f, 0.90f, 0.50f, 0.70f, 1.0f, 1.0f }, // правая вверх
	//  { 0.0f, -0.5f, -0.5f, 1.0f, 1.0f, 0.0f, 1.0f, 0.0f }, // правая низ

	//};

	//круг 
	Vertex circle[circleVertexCount * 3] = {};

	for (int i = 0; i < circleVertexCount; i++) {
		circle[i * 3] = { 0.8f * (float)cos(i * (360.0 / circleVertexCount) * deg2rad), 0.8f * (float)sin(i * (360.0 / circleVertexCount) * deg2rad), HSV2RGB(i % 360).at(0), HSV2RGB(i % 360).at(1), HSV2RGB(i % 360).at(2) };
		circle[i * 3 + 1] = { 0.8f * (float)cos((i + 1) * (360.0 / circleVertexCount) * deg2rad), 0.8f * (float)sin((i + 1) * (360.0 / circleVertexCount) * deg2rad), HSV2RGB((i + 1) % 360).at(0), HSV2RGB((i + 1) % 360).at(1),HSV2RGB((i + 1) % 360).at(2) };
		circle[i * 3 + 2] = { 0.0f, 0.0f, 1.0, 1.0, 1.0 };
	}

	// Передаем вершины в буфер
	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	if (num_task == 1)
		glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
	else if (num_task == 2 || num_task == 3)
		glBufferData(GL_ARRAY_BUFFER, sizeof(cube), cube, GL_STATIC_DRAW);
	else if (num_task == 4) {
		glBufferData(GL_ARRAY_BUFFER, sizeof(circle), circle, GL_STATIC_DRAW);
	}

	checkOpenGLerror(); //Пример функции есть в лабораторной
}

void InitTextures() {
	if (!texture1.loadFromFile("tex2.png")) {
		std::cout << "could not find texture " << std::endl;
		return; // Ошибка загрузки текстуры
	}

	if (!texture2.loadFromFile("1.png")) {
		std::cout << "could not find texture " << std::endl;
		return; // Ошибка загрузки текстуры
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
	// Шейдеры
	InitShader(num_task);
	// Вершинный буфер
	InitVBO(num_task);
	if (num_task == 2 || num_task == 3)
		InitTextures();
	if (num_task == 2)
		two_text = false;
	else two_text = true;
	glEnable(GL_DEPTH_TEST);
}

void Draw(int num_task) {

	glUseProgram(Program); // Устанавливаем шейдерную программу текущей

	glUniform1f(Unif_xmove, moveX);
	glUniform1f(Unif_ymove, moveY);
	glUniform1f(Unif_zmove, moveZ);
	glUniform1f(Unif_xscale, scaleX);
	glUniform1f(Unif_yscale, scaleY);

	glEnableVertexAttribArray(0);
	glEnableVertexAttribArray(1);
	glEnableVertexAttribArray(2);

	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	if (num_task == 1) {
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)0);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 6 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
	}

	else if (num_task == 3 || num_task == 2) {
		glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
		// Атрибут с текстурными координатами
		glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));
		//glVertexAttribPointer(3, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));

		glActiveTexture(GL_TEXTURE0);
		sf::Texture::bind(&texture1);
		glUniform1i(Unif_texture1, 0);

		glActiveTexture(GL_TEXTURE1);
		sf::Texture::bind(&texture2);
		glUniform1i(Unif_texture2, 1);

		glUniform1f(Unif_reg, reg);

		glUniform1i(glGetUniformLocation(Program, "two_text"), two_text);
	}

	else if (num_task == 4) {
		glVertexAttribPointer(0, 2, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (GLvoid*)0);
		glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (GLvoid*)(2 * sizeof(GLfloat)));
	}

	if (num_task == 1) {
		glDrawArrays(GL_TRIANGLES, 0, 9);
	}
	else if (num_task == 2 || num_task == 3) {

		glDrawArrays(GL_TRIANGLES, 0, 36);
		sf::Texture::bind(NULL);
	}
	else if (num_task == 4) {
		glDrawArrays(GL_TRIANGLES, 0, circleVertexCount * 3);
	}

	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(2);

	glBindBuffer(GL_ARRAY_BUFFER, 0);

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
				case (sf::Keyboard::Up): changeScale(0, 0.1); break;
				case (sf::Keyboard::Down): changeScale(0, -0.1); break;
				case (sf::Keyboard::Left): changeScale(-0.1, 0); break;
				case (sf::Keyboard::Right): changeScale(0.1, 0); break;
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



