#pragma once
#ifndef SCENE_OBJECT_H
#define SCENE_OBJECT_H

#include <glm/glm.hpp>

#include "Shader.h"
#include "Mesh.h"


class SceneObject
{
private:
	Mesh* mesh;
	Shader* shader;
	int i = 0;

public:
	glm::vec3 position{ 0.f, 0.f, 0.f };
	glm::vec3 rotation{ 0.f, 0.f, 0.f };
	glm::vec3 scale{ 1.f, 1.f, 1.f };

	SceneObject(Mesh* mesh, Shader* sp)
	{
		this->mesh = mesh;
		this->shader = sp;
	}

	void Draw()
	{

		glm::mat4 model = glm::rotate(glm::mat4(1.0f), glm::radians(-90.0f), glm::vec3(1.0f, 0.0f, 0.0f))
			* glm::translate(glm::mat4(1.f), position)
			* glm::scale(glm::mat4(1.f), scale);
		//rotation.x = 0;
		shader->Use();
		shader->SetUniformMat4("model", model);
		shader->SetUniformFloat("rotationY", rotation.y);
		mesh->Draw(*shader);
		glUseProgram(0);
	}


};

#endif
