#version 440
in vec2 vs_texcoord;
in vec4 vs_sprite_color;
flat in uint vs_texture_slot;

out vec4 fs_color;

uniform sampler2D textureSamples[32];

void main()
{
	fs_color = vs_sprite_color;
}