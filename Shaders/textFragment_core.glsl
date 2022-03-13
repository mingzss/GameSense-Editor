#version 440
in vec2 gs_texcoord;
in vec4 gs_sprite_color;
flat in uint gs_texture_slot;

out vec4 fs_color;

uniform sampler2D textureSamples[32];
uniform float outlineWidth;
uniform vec4 outlineColor;

void main()
{
	fs_color = vec4(1.f, 1.f, 1.f, texture(textureSamples[gs_texture_slot], gs_texcoord).r) * gs_sprite_color;
}