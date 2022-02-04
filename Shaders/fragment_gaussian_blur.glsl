#version 440
#define PI 3.14159265359
#define E 2.71828182846

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform int 					uPassNumber;
uniform int 					uSamples;
uniform float 					uStandardDeviation;
uniform float 					uBlurSize;
uniform float 					uTexWidth;
uniform float 					uTexHeight;

uniform sampler2D				uTex2d;

void main()
{	
	vec4 clr = texture(uTex2d, vs_texcoord);
	if(clr.a < 0.05f)
		discard;
		
	vec4 oColor;
	float sum = 0;
	for (float index = 0; index < uSamples; index++)
	{
		float offset;
		vec2 uv;

		if (uPassNumber == 1)
		{
			offset = (index / (uSamples - 1) - 0.5) * uBlurSize;
			uv = vs_texcoord + vec2(0, offset);
		}

		else if (uPassNumber == 2)
		{
			offset = (index / (uSamples - 1) - 0.5) * uBlurSize * 
				uTexHeight / uTexWidth;
			uv = vs_texcoord + vec2(offset, 0);
		}

		float stDevSquared = uStandardDeviation * uStandardDeviation;
		float gauss = (1 / sqrt(2 * PI * stDevSquared)) * 
			pow(E, - ((offset * offset) / (2 * stDevSquared)));
		sum += gauss;
		oColor += texture(uTex2d, uv) * gauss;
	}
	oColor = oColor / sum;
	fs_color = oColor;
}