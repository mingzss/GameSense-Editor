#version 440

in vec2 vTexCoord;
out vec4 fFragColor;

uniform sampler2D uTex2d;

void main()
{    
    vec4 clr = texture(uTex2d, vTexCoord);
    if (clr.a < 0.05f)
	  	discard;
    float grey_value = (clr.r + clr.g + clr.b) / 3.0;
    fFragColor = vec4(grey_value, grey_value, grey_value, 1.0);
}