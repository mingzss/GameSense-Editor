#version 440
layout (location = 0) in vec3   vertex_position; 
layout (location = 1) in vec2   vertex_texcoord;
layout (location = 2) in vec4   vertex_color;
layout (location = 3) in uint   vertex_textureslot;
layout (location = 4) in uint   vertex_texturelayer;
layout (location = 5) in float  vertex_intensity;
layout (location = 6) in float  vertex_radius;

out vec2                        vs_texcoord;
out vec4                        vs_sprite_color;
out vec4                        vs_position;
flat out uint                   vs_texture_slot;
flat out uint                   vs_texture_layer;
flat out float                  vs_intensity;
flat out float                  vs_radius;

uniform mat4                    ProjectionMatrix;

void main()
{
    gl_Position = ProjectionMatrix * vec4(vertex_position.xyz, 1.0f);

    vs_texcoord = vertex_texcoord.xy;
    vs_sprite_color = vertex_color;
    vs_texture_slot = vertex_textureslot;
    vs_texture_layer = vertex_texturelayer;
    vs_intensity = vertex_intensity; 
    vs_radius = vertex_radius;
    vs_position = vec4(vertex_position, 1.0f); 
}