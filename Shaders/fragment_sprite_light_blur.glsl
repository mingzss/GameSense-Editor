#version 440
#define MAX_LAYERS 32
#define PI 3.14159265359
#define E 2.71828182846
#define EPSILON 1e-10

in vec2 	 					gs_texcoord;

out vec4 						fs_color;

uniform float 					uTexWidth;
uniform float 					uTexHeight;
uniform int 					uPassNumber;
uniform sampler2DArray          uTex2dArray;

void main()
{
	// float weight[5] = 
	// 	float[] (0.227027, 0.1945946, 0.1216216, 0.054054, 0.016216);

    fs_color = texture(uTex2dArray, vec3(gs_texcoord, gl_Layer));
		
//     vec2 tex_offset = 1.0 / textureSize(uTex2dArray, 0).xz;

// 	vec4 result = fs_color * weight[0];
// 	if (uPassNumber == 1)
//     {
//         for(int i = 0; i < 5; ++i)
//         {
//             result += 
// 				texture(uTex2dArray, vec3(gs_texcoord + 
// 					vec2(tex_offset.x * i, 0.0), float(gl_Layer))) * weight[i];
//             result += 
// 				texture(uTex2dArray, vec3(gs_texcoord - 
// 					vec2(tex_offset.x * i, 0.0), float(gl_Layer))) * weight[i];
//         }
//     }
//     else
//     {
//         for(int i = 0; i < 5; ++i)
//         {
//             result += 
// 				texture(uTex2dArray, vec3(gs_texcoord + 
// 					vec2(0.0, tex_offset.y * i), float(gl_Layer))) * weight[i];
//             result += 
// 				texture(uTex2dArray, vec3(gs_texcoord - 
// 					vec2(0.0, tex_offset.y * i), float(gl_Layer))) * weight[i];
//         }
//     }
//     fs_color = result;
	
// 	if(fs_color.a < EPSILON)
// 		discard;
// }
	vec3 blurAmount = vec3(0.1, 0.01, 30.0);
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

	if(fs_color.a < EPSILON)
		discard;
}