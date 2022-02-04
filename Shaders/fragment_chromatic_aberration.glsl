#version 440

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform float 					uAberrationAmount;
uniform sampler2D 				uTex2d;

void main()
{	
	vec4 clr = texture(uTex2d, vs_texcoord);
	if (clr.a < 0.05f)
		discard;
	vec4 oColor = vec4(0, 0, 0, clr.a);

	oColor.r = texture(uTex2d, 
		vec2(vs_texcoord.x + uAberrationAmount,vs_texcoord.y)).r;
    oColor.g = clr.g;
    oColor.b = texture(uTex2d, 
		vec2(vs_texcoord.x - uAberrationAmount,vs_texcoord.y)).b;
	fs_color = oColor;
}