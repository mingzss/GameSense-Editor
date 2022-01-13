#version 440

#define LUMINANCE_PRESERVATION 0.75
#define EPSILON 1e-10

in vec2 vTexCoord;
out vec4 fFragColor;

uniform float uTemperatureSaturation;
uniform float uTemperature;

uniform sampler2D uTex2d;

float saturate(float v) { return clamp(v, 0.0,       1.0);       }
vec2  saturate(vec2  v) { return clamp(v, vec2(0.0), vec2(1.0)); }
vec3  saturate(vec3  v) { return clamp(v, vec3(0.0), vec3(1.0)); }
vec4  saturate(vec4  v) { return clamp(v, vec4(0.0), vec4(1.0)); }

vec3 ColorTemperatureToRGB(float temperature)
{
	vec3 oColor;
    temperature = clamp(temperature, 1000.0, 40000.0) / 100.0;
    
    if (temperature <= 66.0)
    {
        oColor.r = 1.0;
        oColor.g = saturate(0.39008157876901960784 * 
            log(temperature) - 0.63184144378862745098);
    }
    else
    {
    	float t = temperature - 60.0;
        oColor.r = saturate(1.29293618606274509804 * pow(t, -0.1332047592));
        oColor.g = saturate(1.12989086089529411765 * pow(t, -0.0755148492));
    }
    
    if (temperature >= 66.0)
        oColor.b = 1.0;
    else if(temperature <= 19.0)
        oColor.b = 0.0;
    else
        oColor.b = saturate(0.54320678911019607843 * 
            log(temperature - 10.0) - 1.19625408914);

    return oColor;
}

float Luminance(vec3 color)
{
    float fmin = min(min(color.r, color.g), color.b);
	float fmax = max(max(color.r, color.g), color.b);
	return (fmax + fmin) / 2.0;
}

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
    float factor = saturate(uTemperatureSaturation * 2.0);
    float colorTempK = mix(1000.0, 40000.0, uTemperature);
    
    vec4 image = texture(uTex2d, vTexCoord);
    if (image.a < 0.05f)
        discard;
    vec3 colorTempRGB = ColorTemperatureToRGB(colorTempK);
    
    float originalLuminance = Luminance(image.rgb);
        
    vec3 blended = mix(image.rgb, image.rgb * colorTempRGB, factor);
    vec3 resultHSL = RGBtoHSL(blended);
    
    vec3 luminancePreservedRGB = 
		HSLtoRGB(vec3(resultHSL.x, resultHSL.y, originalLuminance));        
        
    fFragColor = 
		vec4(mix(blended, luminancePreservedRGB, LUMINANCE_PRESERVATION), 1.0);
    
}