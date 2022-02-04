#version 440
layout (location = 0) in vec3   vertex_position; 
layout (location = 1) in vec2   vertex_texcoord;
layout (location = 4) in uint   vertex_texlayer;

out vec2 	 					vs_texcoord;
out uint 	 					vs_texlayer;

void main()
{
    gl_Position = vec4(vertex_position.xyz, 1.0f);
    vs_texcoord = vertex_texcoord;
    vs_texlayer = vertex_texlayer;
}