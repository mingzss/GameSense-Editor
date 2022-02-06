#version 440

#define EPSILON 1e-10

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform sampler2D               uTex2d;

void main()
{    
    vec4 clr = texture(uTex2d, vs_texcoord);
	if (clr.a < EPSILON)
		discard;
    fs_color = clr;
}