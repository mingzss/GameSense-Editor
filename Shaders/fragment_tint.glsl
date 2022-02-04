#version 440

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform vec3                    uTintColor;
uniform sampler2D               uTex2d;

void main()
{
    vec3 mixColor = texture(uTex2d, vs_texcoord).rgb * uTintColor;
    fs_color   = vec4( mixColor.rgb, texture(uTex2d, vs_texcoord).a );
}