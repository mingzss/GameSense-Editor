#version 440
#define MAX_LAYERS 32

in vec2 	 					gs_texcoord;

out vec4 						fs_color;

uniform sampler2DArray			uTex2dArray;
uniform vec2 					uAberrationAmounts[MAX_LAYERS];
uniform int                     uToGreyscale[MAX_LAYERS];
uniform vec4                    uTintColors[MAX_LAYERS];

void main()
{	
	vec4 clr = texture(uTex2dArray, vec3(gs_texcoord, gl_Layer));
	vec2 aberrationAmount = uAberrationAmounts[gl_Layer];

	if (clr.a < 0.05f)
		discard;

	if (aberrationAmount.y >= 0.0f) 
	{
		vec4 oColor = vec4(0, 0, 0, clr.a);
	
		oColor.r = 
			texture(uTex2dArray, vec3(
				clamp(gs_texcoord.x - aberrationAmount.x, 0.0, 1.0),
										gs_texcoord.y, gl_Layer)).r;
	    oColor.g = clr.g;
	    oColor.b = 
			texture(uTex2dArray, vec3(
				clamp(gs_texcoord.x - aberrationAmount.x, 0.0, 1.0),
										gs_texcoord.y, gl_Layer)).b;
		fs_color = oColor;
	}

	else
	{
		fs_color = clr;
	}

	if (bool(uToGreyscale[gl_Layer])) 
    {
        float grey_value = (fs_color.r + fs_color.g + fs_color.b) / 3.0;
        fs_color = vec4(grey_value, grey_value, grey_value, 1.0);
    }

	vec4 tintClr = uTintColors[gl_Layer];

    if(tintClr.a >= 0.f)
    {
        vec3 mixColor = fs_color.rgb * tintClr.rgb;
        fs_color = vec4( mixColor.rgb, fs_color.a);
    }
}