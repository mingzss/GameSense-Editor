#version 440

in vec2 vTexCoord;
out vec4 fFragColor;

uniform sampler2D uTex2d;
uniform float uHue;
uniform float uSaturation;
uniform float uBrightness;
uniform float uContrast;

vec3 applyHue(vec3 aColor, float aHue)
{
    float angle = radians(aHue);
    vec3 k = vec3(0.57735, 0.57735, 0.57735);
    float cosAngle = cos(angle);
    return aColor * cosAngle + cross(k, aColor) * sin(angle) + 
        k * dot(k, aColor) * (1 - cosAngle);
}
 
vec4 applyHSBEffect(vec4 startColor, vec4 hsbc)
{
    float _Hue = 360 * hsbc.r;
    float _Saturation = hsbc.g * 2;
    float _Brightness = hsbc.b * 2 - 1;
    float _Contrast = hsbc.a * 2;
 
    vec4 outputColor = startColor;
    outputColor.rgb = applyHue(outputColor.rgb, _Hue);
    outputColor.rgb = (outputColor.rgb - 0.5f) * (_Contrast) + 0.5f;
    outputColor.rgb = outputColor.rgb + _Brightness;
    
    float intensity_val = dot(outputColor.rgb, vec3(0.299,0.587,0.114));
    vec3 intensity = vec3(intensity_val, intensity_val, intensity_val);
    outputColor.rgb = mix(intensity, outputColor.rgb, _Saturation);
 
    return outputColor;
}

void main()
{
    vec4 hsbc = vec4(uHue, uSaturation, uBrightness, uContrast);
    fFragColor = applyHSBEffect(texture(uTex2d, vTexCoord), hsbc);
}