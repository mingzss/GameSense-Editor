#version 440

#define EPSILON 1e-10

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform vec3                    uTintColor;
uniform sampler2D               uTex2d;

void main()
{
    fs_color = texture(uTex2d, vs_texcoord);
    if(fs_color.a < EPSILON)
		discard;

    vec3 mixColor = fs_color.rgb * uTintColor;
    fs_color = vec4( mixColor.rgb, fs_color.a );
}