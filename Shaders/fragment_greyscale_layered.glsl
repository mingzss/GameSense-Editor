#version 440
#define MAX_LAYERS 32

in vec2 	 					gs_texcoord;

out vec4 						fs_color;

uniform sampler2DArray          uTex2dArray;
uniform int                     uToGreyscale[MAX_LAYERS];

void main()
{
    vec4 clr = texture(uTex2dArray, vec3(gs_texcoord, gl_Layer));
    if (clr.a < 0.05f)
     	discard;

    if (bool(uToGreyscale[gl_Layer])) 
    {
        float grey_value = (clr.r + clr.g + clr.b) / 3.0;
        fs_color = vec4(grey_value, grey_value, grey_value, 1.0);
    }

    else
    {
        fs_color = clr;
    }
}