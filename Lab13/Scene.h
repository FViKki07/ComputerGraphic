#ifndef SCENE_H
#define SCENE_H

#include "Shader.h"
#include "Mesh.h"
#include "SceneObject.h"
#include "Camera.h";


class Scene
{
	sf::Time deltaTime;
	sf::Clock clock;
	sf::Clock unstopClock;

public:
	std::vector<Shader*> shaders;
	std::vector<SceneObject*> sceneObjects;
	Camera camera;

	Scene()
	{
		camera = Camera(glm::vec3(0.0f, 0.0f, 70.0f));

	}

	void AddShaderProgram(Shader& sp)
	{
		shaders.push_back(&sp);
	}

	void AddSceneObject(SceneObject& so)
	{
		sceneObjects.push_back(&so);
	}

	void Draw(float rotationAngle)
	{
	
		glm::mat4 projection = glm::perspective(glm::radians(45.0f), (float)800 / (float)800, 0.1f, 1000.0f);

		for (auto& shader : shaders)
		{
			shader->Use();
			shader->SetUniformMat4("projection", projection);
			shader->SetUniformMat4("view", camera.GetViewMatrix());
			glUseProgram(0);
		}

		for (auto& sceneObject : sceneObjects)
		{
			sceneObject->rotation.y = rotationAngle;
			sceneObject->Draw();
		}
	}
	float getDeltaTime()
	{
		return deltaTime.asSeconds();
	}
private:
	std::vector<Mesh> meshes;
};


#endif
