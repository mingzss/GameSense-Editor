#version 440
#define PI 3.14159265359
#define E 2.71828182846
#define MAX_LAYERS 32

in vec2 	 					gs_texcoord;

out vec4 						fs_color;

uniform int 					uPassNumber;
uniform float 					uTexWidth;
uniform float 					uTexHeight;
uniform vec4					uBlurAmounts[MAX_LAYERS];

uniform sampler2DArray 			uTex2dArray;

void main()
{	
	vec4 clr = texture(uTex2dArray, vec3(gs_texcoord, gl_Layer));

	if(clr.a < 0.05f)
		discard;
		
	vec4 blurAmount = uBlurAmounts[gl_Layer];
	if (blurAmount.a >= 0.0f)
	{
		vec4 oColor;
		float sum = 0;
		for (float index = 0; index < blurAmount.z; index++)
		{
			float offset;
			vec2 uv;

			if (uPassNumber == 1)
			{
				offset = (index / (blurAmount.z - 1) - 0.5) * blurAmount.x;
				uv = gs_texcoord + vec2(0, offset);
			}

			else if (uPassNumber == 2)
			{
				offset = (index / (blurAmount.z - 1) - 0.5) * blurAmount.x * 
					uTexHeight / uTexWidth;
				uv = gs_texcoord + vec2(offset, 0);
			}

			float stDevSquared = blurAmount.y * blurAmount.y;
			float gauss = (1 / sqrt(2 * PI * stDevSquared)) * 
				pow(E, - ((offset * offset) / (2 * stDevSquared)));
			sum += gauss;
			oColor += texture(uTex2dArray, vec3(uv, gl_Layer)) * gauss;
		}
		oColor = oColor / sum;
		fs_color = oColor;
	}

	else
	{
		fs_color = clr;
	}
}