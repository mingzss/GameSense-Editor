#version 450 core

in vec2 vTexCoord;
out vec4 fFragColor;

uniform vec3 uTintColor;
uniform sampler2D uTex2d;

void main()
{
    vec3 mixColor = texture(uTex2d, vTexCoord).rgb * uTintColor;
    fFragColor   = vec4( mixColor.rgb, texture(uTex2d, vTexCoord).a );
}