#version 440
layout (location = 0) in vec3   vertex_position; 
layout (location = 1) in vec2   vertex_texcoord;
layout (location = 2) in vec4   vertex_color;
layout (location = 3) in uint   vertex_textureslot;
layout (location = 4) in uint   vertex_texturelayer;

out vec2                        vs_texcoord;
out vec4                        vs_sprite_color;
flat out uint                   vs_texture_layer;
flat out uint                   vs_texture_slot;

uniform mat4 ProjectionMatrix;

void main()
{
    gl_Position =   ProjectionMatrix * vec4(vertex_position.xyz, 1.0f);

    vs_texcoord = vec2(vertex_texcoord.x, vertex_texcoord.y);
    vs_texture_layer = vertex_texturelayer;
    vs_sprite_color = vertex_color;
    vs_texture_slot = vertex_textureslot;
}