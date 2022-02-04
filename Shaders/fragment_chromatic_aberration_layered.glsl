#version 440
#define MAX_LAYERS 32

in vec2 	 					gs_texcoord;

out vec4 						fs_color;

uniform sampler2DArray			uTex2dArray;
uniform vec2 					uAberrationAmounts[MAX_LAYERS];

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
			texture(uTex2dArray, vec3(gs_texcoord.x + aberrationAmount.x, 
										gs_texcoord.y, gl_Layer)).r;
	    oColor.g = clr.g;
	    oColor.b = 
			texture(uTex2dArray, vec3(gs_texcoord.x - aberrationAmount.x,
										gs_texcoord.y, gl_Layer)).b;
		fs_color = oColor;
	}

	else
	{
		fs_color = clr;
	}
}