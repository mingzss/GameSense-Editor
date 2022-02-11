#version 440

#define EPSILON 1e-10

in vec2 	 					gs_texcoord;
in vec4		 					gs_sprite_color;
flat in uint 					gs_texture_slot;
flat in uint 					gs_texture_layer;

out vec4 						fs_color;

uniform sampler2D 				textureSamples[32];

void main()
{
	vec4 col = texture(textureSamples[gs_texture_slot], gs_texcoord);
	if (col.a < EPSILON)
		discard;
	fs_color = gs_sprite_color;
}