#version 440

#define EPSILON 1e-10

in vec2 	 					vs_texcoord;

out vec4 						fs_color;

uniform vec3                    uTintColor;
uniform sampler2D               uTex2d;


vec3  saturate(vec3  v) { return clamp(v, vec3(0.0), vec3(1.0)); }

vec3 HUEtoRGB(float H)
{
    float R = abs(H * 6.0 - 3.0) - 1.0;
    float G = 2.0 - abs(H * 6.0 - 2.0);
    float B = 2.0 - abs(H * 6.0 - 4.0);
    return saturate(vec3(R,G,B));
}

vec3 HSLtoRGB(vec3 HSL)
{
    vec3 RGB = HUEtoRGB(HSL.x);
    float C = (1.0 - abs(2.0 * HSL.z - 1.0)) * HSL.y;
    return (RGB - 0.5) * C + vec3(HSL.z);
}
 
vec3 RGBtoHCV(vec3 RGB)
{
    vec4 P = (RGB.g < RGB.b) 
        ? vec4(RGB.bg, -1.0, 2.0/3.0) 
        : vec4(RGB.gb, 0.0, -1.0/3.0);
    vec4 Q = (RGB.r < P.x) ? vec4(P.xyw, RGB.r) : vec4(RGB.r, P.yzx);
    float C = Q.x - min(Q.w, Q.y);
    float H = abs((Q.w - Q.y) / (6.0 * C + EPSILON) + Q.z);
    return vec3(H, C, Q.x);
}

vec3 RGBtoHSL(vec3 RGB)
{
    vec3 HCV = RGBtoHCV(RGB);
    float L = HCV.z - HCV.y * 0.5;
    float S = HCV.y / (1.0 - abs(L * 2.0 - 1.0) + EPSILON);
    return vec3(HCV.x, S, L);
}

void main()
{
    fs_color = texture(uTex2d, vs_texcoord);
    if(fs_color.a < EPSILON)
        discard;
    vec3 baseHSL = RGBtoHSL(fs_color.rgb);
    vec3 blendHSL = RGBtoHSL(uTintColor);
    vec3 outHSL = vec3(blendHSL.rg, baseHSL.b);
    fs_color = vec4(HSLtoRGB(outHSL), fs_color.a);
}