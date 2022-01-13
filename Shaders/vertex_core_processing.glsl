#version 440
layout (location = 0) in vec3 vertex_position; 
layout (location = 1) in vec2 vertex_texcoord;
layout (location = 2) in vec4 vertex_color;

out vec2 vTexCoord;

void main()
{
    gl_Position = vec4(vertex_position.xyz, 1.0f);
    vTexCoord = vertex_texcoord;
}