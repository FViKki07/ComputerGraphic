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

    Shader jaguar_shader = Shader("Shaders\\jaguar.vs","Shaders\\all.frag");
    Shader parrot_Shader = Shader("Shaders\\parrot.vs", "Shaders\\all.frag");

    Mesh mesh = Mesh("meshes\\jaguar.obj", "meshes\\jaguar.jpg");
    SceneObject jaguar = SceneObject(&mesh, &jaguar_shader);
    jaguar.scale = jaguar.scale * 1.5f;
    //sun.rotation.x += 90;
    //sun.position.x += 15;

    Mesh meshbird = Mesh("meshes\\bird.obj", "meshes\\bird.jpg", 6);
    SceneObject bird = SceneObject(&meshbird, &parrot_Shader);

    Scene mainScene = Scene();
    mainScene.AddSceneObject(jaguar);
    mainScene.AddSceneObject(bird);
    mainScene.AddShaderProgram(jaguar_shader);
    mainScene.AddShaderProgram(parrot_Shader);

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
            else if (event.type == sf::Event::MouseWheelMoved)
            {
                mainScene.camera.ProcessMouseScroll(event.mouseWheel.delta);
            }
            else if (event.type == sf::Event::MouseButtonPressed) {

                switch (event.mouseButton.button)
                {
                case sf::Mouse::Right:
                    isCamActive = true;
                    break;
                default:
                    break;
                }
            }
            else if (event.type == sf::Event::MouseMoved)
            {
                auto newMousePos = glm::vec2(event.mouseMove.x, event.mouseMove.y);
                mouseDelta = newMousePos - mousePos;
                mousePos = newMousePos;
                if (isCamActive)
                    mainScene.camera.OnMouseMove(mouseDelta);
            }
            else if (event.type == sf::Event::MouseButtonReleased) {
                switch (event.mouseButton.button)
                {
                case sf::Mouse::Right:
                    isCamActive = false;
                    break;
                default:
                    break;
                }
            }
            else if (event.type == sf::Event::KeyPressed)
            {
                switch (event.key.code) {
                case (sf::Keyboard::A): mainScene.camera.ProcessKeyboard(LEFT, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::D): mainScene.camera.ProcessKeyboard(RIGHT, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::W): mainScene.camera.ProcessKeyboard(UP, elapsedTime.asSeconds()); break;
                case (sf::Keyboard::S): mainScene.camera.ProcessKeyboard(DOWN, elapsedTime.asSeconds()); break;
              
                default: break;
                }
               // elapsedTime = clock.restart();
            }
        }
        elapsedTime = clock.getElapsedTime();
        if (elapsedTime > sf::milliseconds(5))
        {
            rotationAngle += 0.02f;
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
