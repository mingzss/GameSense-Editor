#version 440

#define MAX_LAYERS 32

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform sampler2DArray 			uTex2dArray;

void main()
{
	fs_color = vec4 (0.0f, 0.0f, 0.0f, 0.0f);
	for (int i = 0; i < MAX_LAYERS; ++i)
	{
		vec4 layer_color = texture(uTex2dArray, vec3(vs_texcoord.xy, i));
		if (layer_color.a < 0.01) continue;
		fs_color.rgb = fs_color.rgb * (1 -  layer_color.a) + 
						layer_color.rgb * layer_color.a; 
		
		fs_color.a = max(fs_color.a, layer_color.a);
	}
}