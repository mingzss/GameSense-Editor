#version 440
in vec2 vs_texcoord;
in vec4 sprite_color;
flat in uint texture_slot;

out vec4 fs_color;

uniform sampler2D textureSamples[32];

void main()
{
	vec4 col = texture(textureSamples[texture_slot], vs_texcoord);
	if (col.a < 0.05f)
		discard;
	fs_color =  col *  sprite_color;
	fs_color.rgb *= fs_color.a;
}