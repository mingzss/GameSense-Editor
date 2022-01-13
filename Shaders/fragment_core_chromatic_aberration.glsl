#version 440

in vec2 vTexCoord;
out vec4 fFragColor;

uniform float uAberrationAmount;
uniform sampler2D uTex2d;

void main()
{	
	vec4 clr = texture(uTex2d, vTexCoord);
	if (clr.a < 0.05f)
		discard;
	vec4 oColor = vec4(0, 0, 0, clr.a);

	oColor.r = texture(uTex2d, 
		vec2(vTexCoord.x + uAberrationAmount,vTexCoord.y)).r;
    oColor.g = clr.g;
    oColor.b = texture(uTex2d, 
		vec2(vTexCoord.x - uAberrationAmount,vTexCoord.y)).b;
	fFragColor = oColor;
}