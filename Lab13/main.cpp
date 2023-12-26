#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <glm/gtc/matrix_transform.hpp>

#include <iostream>

#include "Shader.h"
#include "Mesh.h"
#include "SceneObject.h"
#include "Scene.h"

// camera
Camera camera(glm::vec3(0.0f, 0.0f, -3.0f));
float lastX = SCREEN_WIDTH / 2.0f;
float lastY = SCREEN_HEIGHT / 2.0f;
bool firstMouse = true;
bool isCamActive = false;
bool isCamTouched = false;
glm::vec2 mousePos;
glm::vec2 mouseDelta;

int main()
{
    sf::Window window(sf::VideoMode(SCREEN_WIDTH, SCREEN_HEIGHT), "Lab13", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);
    window.setActive(true);
    glewInit();
    glEnable(GL_DEPTH_TEST);

    Shader ourShader = Shader("Shaders\\sun.vs","Shaders\\sun.frag");
    Shader planetShader = Shader("Shaders\\planet.vs", "Shaders\\sun.frag");

    Mesh mesh = Mesh("meshes\\jaguar.obj", "meshes\\jaguar.jpg");
    SceneObject sun = SceneObject(&mesh, &ourShader);
    sun.scale = sun.scale * 0.55f;
    sun.rotation.x += 90;

    Mesh meshPlanet = Mesh("meshes\\bird.obj", "meshes\\bird.jpg", 6);
    SceneObject planet = SceneObject(&meshPlanet, &planetShader);

    Scene mainScene = Scene();
    mainScene.AddSceneObject(sun);
    mainScene.AddSceneObject(planet);
    mainScene.AddShaderProgram(ourShader);
    mainScene.AddShaderProgram(planetShader);

    sf::Time elapsedTime;
    sf::Clock clock;
    GLfloat rotationAngle = 0.0f;
    bool running = true;
    while (running)
    {
        sf::Event event;
        while (window.pollEvent(event))
        {
            if (event.type == sf::Event::Closed)
            {
                running = false;
            }
            else if (event.type == sf::Event::Resized)
            {
                // Изменён размер окна, надо поменять и размер области Opengl отрисовки
                glViewport(0, 0, event.size.width, event.size.height);
            }
            else if (event.type == sf::Event::KeyPressed)
            {
                switch (event.key.code) {
                case (sf::Keyboard::W): mainScene.camera.ProcessKeyboard(FORWARD, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::S): mainScene.camera.ProcessKeyboard(BACKWARD, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::A): mainScene.camera.ProcessKeyboard(LEFT, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::D): mainScene.camera.ProcessKeyboard(RIGHT, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::R): mainScene.camera.ProcessKeyboard(UP, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::F): mainScene.camera.ProcessKeyboard(DOWN, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::J): mainScene.camera.ProcessKeyboard(LROTATION, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::L): mainScene.camera.ProcessKeyboard(RROTATION, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::I): mainScene.camera.ProcessKeyboard(UPROTATION, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::K): mainScene.camera.ProcessKeyboard(DOWNROTATION, elapsedTime.asSeconds()); break;
                default: break;
                }
                elapsedTime = clock.restart();
            }
        }
        elapsedTime = clock.getElapsedTime();
        if (elapsedTime > sf::milliseconds(5))
        {
            rotationAngle += 0.01f;
            if (rotationAngle > 360)
                rotationAngle = 360.0f;
            elapsedTime = clock.restart();
        }
        //glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        mainScene.Draw(rotationAngle);

        window.display();



    }
    window.close();
    return 0;
}
