#version 330 core
layout (location = 0) in vec3 vertexPosition;
layout (location = 1) in vec3 normals;
layout (location = 2) in vec2 textPosition;

out vec2 TexCoord;

uniform mat4 projection;
uniform mat4 view;
uniform mat4 model;
uniform float rotationY;

void main() 
{
     vec3 position = mat3(
            cos(rotationY),  0, sin(rotationY),
            0,               1, 0,
            -sin(rotationY), 0, cos(rotationY)) 
        * mat3(
            1, 0,          0,
            0, cos(1.6),  -sin(1.6),
            0, sin(1.6),  cos(1.6))
            * vec3(vertexPosition.x,vertexPosition.y,vertexPosition.z) ;
    gl_Position = projection * view * model * vec4(position, 1.0f); 
    TexCoord = vec2(textPosition.x, 1.0 - textPosition.y);
}