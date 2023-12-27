#ifndef CAMERA_H
#define CAMERA_H

#include "Headers.h"

class Camera
{
public:
    glm::vec3 Position;
    glm::vec3 Front;
    glm::vec3 Up;
    glm::vec3 Right;
    glm::vec3 WorldUp;

    float Yaw;
    float Pitch;

    float MovementSpeed;
    float MouseSensitivity;


    Camera(glm::vec3 position = glm::vec3(0.0f, 0.0f, 70.0f), glm::vec3 up = glm::vec3(0.0f, 1.0f, 0.0f), float yaw = YAW, float pitch = PITCH) : Front(glm::vec3(0.0f, 0.0f, -1.0f)), MovementSpeed(SPEED), MouseSensitivity(SENSITIVITY)
    {
        Position = position;
        WorldUp = up;
        Yaw = yaw;
        Pitch = pitch;
        updateCameraVectors();
    }
    glm::mat4 GetViewMatrix()
    {
        return glm::lookAt(Position, Position + Front, Up);
    }

    void ProcessKeyboard(Camera_Movement direction, float deltaTime)
    {
        float velocity = MovementSpeed * deltaTime;
        if (direction == FORWARD)
            Position += Front * velocity;
        if (direction == BACKWARD)
            Position -= Front * velocity;
        if (direction == LEFT)
            Position -= Right * velocity;
        if (direction == RIGHT)
            Position += Right * velocity;
        if (direction == UP)
            Position += Up * velocity;
        if (direction == DOWN)
            Position -= Up * velocity;
        if (direction == LROTATION)
        {
            Yaw -= 1.0f;
            updateCameraVectors();
        }
        if (direction == RROTATION)
        {
            Yaw += 1.0f;
            updateCameraVectors();
        }
        if (direction == UPROTATION)
        {
            Pitch += 1.0f;
            if (Pitch > 89.0f)
                Pitch = 89.0f;
            updateCameraVectors();
        }
        if (direction == DOWNROTATION)
        {
            Pitch -= 1.0f;
            if (Pitch < -89.0f)
                Pitch = -89.0f;
            updateCameraVectors();
        }
    }

    void ProcessMouseScroll(float yoffset)
    {
        float velocity = MovementSpeed * yoffset;
        Position += Front * velocity;
    }

    void OnMouseMove(glm::vec2 offset, GLboolean constrainPitch = true)
    {
        offset *= MouseSensitivity;

        Yaw += offset.x;
        Pitch -= offset.y;

        if (constrainPitch)
        {
            if (Pitch > 89.0f) Pitch = 89.0f;
            if (Pitch < -89.0f) Pitch = -89.0f;
        }

        updateCameraVectors();
    }
private:

    void updateCameraVectors()
    {
        glm::vec3 front;
        front.x = cos(glm::radians(Yaw)) * cos(glm::radians(Pitch));
        front.y = sin(glm::radians(Pitch));
        front.z = sin(glm::radians(Yaw)) * cos(glm::radians(Pitch));
        Front = glm::normalize(front);
        Right = glm::normalize(glm::cross(Front, WorldUp));
        Up = glm::normalize(glm::cross(Right, Front));
    }
};
#endif
