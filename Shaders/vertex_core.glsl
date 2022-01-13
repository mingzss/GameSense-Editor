#version 440
layout (location = 0) in vec3 vertex_position; 
layout (location = 1) in vec2 vertex_texcoord;
layout (location = 2) in vec4 vertex_color;
layout (location = 3) in uint vertex_textureslot;

out vec2 vs_texcoord;
out vec4 sprite_color;
flat out uint texture_slot;

uniform mat4 ProjectionMatrix;

void main()
{
    gl_Position =   ProjectionMatrix * vec4(vertex_position.xyz, 1.0f);

    vs_texcoord = vec2(vertex_texcoord.x, vertex_texcoord.y);
    sprite_color = vertex_color;
    texture_slot = vertex_textureslot;
}