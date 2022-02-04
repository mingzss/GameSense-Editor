#version 440

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform sampler2D               uTex2d;

void main()
{    
    vec4 clr = texture(uTex2d, vs_texcoord);
    if (clr.a < 0.05f)
	  	discard;
    float grey_value = (clr.r + clr.g + clr.b) / 3.0;
    fs_color = vec4(grey_value, grey_value, grey_value, 1.0);
}