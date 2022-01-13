#version 440

in vec2 vTexCoord;
out vec4 fFragColor;

uniform sampler2D uTex2d;

void main()
{    
    vec4 clr = texture(uTex2d, vTexCoord);
	if (clr.a < 0.05f)
		discard;
    fFragColor = clr;
    fFragColor.rgb *= fFragColor.a;
}