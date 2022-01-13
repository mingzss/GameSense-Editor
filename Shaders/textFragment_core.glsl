#version 440
in vec2 vs_texcoord;
in vec4 sprite_color;
flat in uint texture_slot;

out vec4 fs_color;

uniform sampler2D textureSamples[32];
uniform float outlineWidth;
uniform vec4 outlineColor;

void main()
{
	fs_color = vec4(1.f, 1.f, 1.f, texture(textureSamples[texture_slot], vs_texcoord).r) *  sprite_color;
}