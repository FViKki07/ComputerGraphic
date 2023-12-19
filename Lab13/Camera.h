#include <GL\glew.h>
#include <SFML\OpenGL.hpp>
#include <glm.hpp>
#include <gtc/matrix_transform.hpp>
#include <SFML/Graphics.hpp>

class Camera{
public: 

	glm::vec3 cameraPos;
	glm::vec3 cameraTarget;
	glm::vec3 cameraDirection = glm::normalize(cameraPos - cameraTarget);
	glm::vec3 up = glm::vec3(0.0f, 1.0f, 0.0f);
	glm::vec3 cameraRight = glm::normalize(glm::cross(up, cameraDirection));
	glm::vec3 cameraUp = glm::cross(cameraDirection, cameraRight);

	Camera(glm::vec3 pos, glm::vec3 target) {
		cameraPos = glm::vec3(0.0f, 0.0f, 3.0f);
		cameraTarget = glm::vec3(0.0f, 0.0f, 0.0f);
	}

	glm::mat4 getLookAt() {
		return glm::lookAt(cameraPos, cameraTarget, cameraUp);
	}


};