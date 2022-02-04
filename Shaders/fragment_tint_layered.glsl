#version 440
#define MAX_LAYERS 32

in vec2 	 					gs_texcoord;

out vec4 						fs_color;

uniform sampler2DArray          uTex2dArray;
uniform vec4                    uTintColors[MAX_LAYERS];

void main()
{
    vec4 clr = texture(uTex2dArray, vec3(gs_texcoord, gl_Layer));
    vec4 tintClr = uTintColors[gl_Layer];

    if(tintClr.a >= 0.f)
    {
        vec3 mixColor = clr.rgb * tintClr.rgb;
        fs_color   = vec4( mixColor.rgb, clr.a);
    }

    else
    {
        fs_color = clr;
    }
}