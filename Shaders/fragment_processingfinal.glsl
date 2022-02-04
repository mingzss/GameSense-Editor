#version 440

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform sampler2D    			uTex2d;

void main()
{    
    vec4 clr = texture(uTex2d, vs_texcoord);
	if (clr.a < 0.05f)
		discard;
    fs_color = clr;
    fs_color.rgb *= fs_color.a;
}