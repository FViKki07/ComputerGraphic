#ifndef MESH_H
#define MESH_H

#include "Camera.h"
#include <vector>
#include <iostream>
#include <fstream>
#include <sstream>

struct Vertex
{
    glm::vec3 Position;
    glm::vec3 Normal;
    glm::vec2 TexCoords;
};

class Mesh {

    std::vector<Vertex> vertices;
    std::vector<GLint> polygons;

    Mesh(std::string pathfile) {

       
    }

};

void ParseStr(const std::string& st, std::vector<float>& values) {
    std::istringstream iss(st);
    std::string val;
    while (iss >> val) {
        values.emplace_back(std::stof(val));
    }
}

void Parser(std::string pathfile) {
    std::vector<std::vector<float>> points;
    std::vector<std::vector<float>> normals;
    std::vector<std::vector<float>> texture;
  
    std::vector<Vertex> vertices;
    std::vector<std::vector<int>> polygons;

    std::ifstream file(pathfile);

    if (!file.is_open()) {
        std::cerr << "Unable to open the file" << std::endl;
        return;
    }

    std::string line;

    while (std::getline(file, line)) {
        line.erase(line.find_last_not_of(" \t\r\n") + 1);  // Trim whitespace

        if (line.empty()) {
            continue;
        }

        std::istringstream iss(line);
        std::string type;
        iss >> type;
        std::vector<float> values;
        ParseStr(type.substr(3), values);

        if (type == "v") points.emplace_back(values);
        else if (type == "vt") texture.emplace_back(values);
        else if (type == "vn") normals.emplace_back(values);
        else if (type == "f") {

        }

        /*
        switch (line[1]) {
        case 'v': {
            std::string x, y, z;
            iss >> x >> y >> z;
            x.replace(x.find_first_of('.'),1, ",");
            y.replace(x.find_first_of('.'), 1, ",");
            z.replace(x.find_first_of('.'), 1, ",");
            if (line[2] == 't') {
                texture.push_back({ stod(x), stod(y), stod(z) });
                texture.emplace_back(stod(x), stod(y), stod(z));
            }
            else {
                if(line[2] == 'n')
                    normals.emplace_back(stod(x), stod(y), stod(z));
                else points.emplace_back(stod(x), stod(y), stod(z));
            }
            break;
        }
        case 'f': {
            std::vector<int> polygon;
            char* vertexIdx;
            while (iss >> vertexIdx) {
                auto p = strtok(vertexIdx, "/");
                Vertex vert ={ points[p[0]],
                    normals[p[2]],
                    texture[p[1]] } ;
                vertices.push_back(vert);
            }
            polygons.push_back(polygon);
            break;
        }
        default:
            break;
        }*/
    }

    return;

}
#endif
