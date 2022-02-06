#version 440
#define MAX_LAYERS 32
#define PI 3.14159265359
#define E 2.71828182846
#define LUMINANCE_PRESERVATION 0.75
#define EPSILON 1e-10

in vec2 	 					gs_texcoord;

out vec4 						fs_color;

uniform int 					uPassNumber;
uniform int                     uToColorGrade[MAX_LAYERS];
uniform int                     uToGreyscale[MAX_LAYERS];
uniform float 					uTexWidth;
uniform float 					uTexHeight;
uniform vec3                    uTemperatureSettings[MAX_LAYERS];
uniform vec4                    uHSBC[MAX_LAYERS];
uniform vec4					uBlurAmounts[MAX_LAYERS];
uniform vec4                    uTintColors[MAX_LAYERS];
uniform vec4                    uGraceTintColors[MAX_LAYERS];
uniform sampler2DArray          uTex2dArray;

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

    fs_color = texture(uTex2dArray, vec3(gs_texcoord, gl_Layer));

	if(fs_color.a < EPSILON)
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

    if (uPassNumber == 2)
    {
        if (bool(uToColorGrade[gl_Layer]))
        {
            vec4 hsbc = uHSBC[gl_Layer];
            fs_color = applyHSBEffect(fs_color, hsbc);
        }

        vec3 tempSettings = uTemperatureSettings[gl_Layer];

        if (tempSettings.z >= 0.0f)
        {
            float factor = saturate(tempSettings.y * 2.0);
            float colorTempK = mix(1000.0, 40000.0, tempSettings.x);

            vec3 colorTempRGB = ColorTemperatureToRGB(colorTempK);
        
            float originalLuminance = Luminance(fs_color.rgb);
            
            vec3 blended = 
                mix(fs_color.rgb, fs_color.rgb * colorTempRGB, factor);
            vec3 resultHSL = RGBtoHSL(blended);
        
            vec3 luminancePreservedRGB = HSLtoRGB(
                    vec3(resultHSL.x, resultHSL.y, originalLuminance));
            
            fs_color = 
                vec4(mix(blended, luminancePreservedRGB, 
                    LUMINANCE_PRESERVATION), 1.0);
        }

        if (bool(uToGreyscale[gl_Layer])) 
        {
            float grey_value = (fs_color.r + fs_color.g + fs_color.b) / 3.0;
            fs_color = vec4(grey_value, grey_value, grey_value, 1.0);
        }

        vec4 tintClr = uTintColors[gl_Layer];

        if (tintClr.a >= 0.f)
        {
            vec3 mixColor = fs_color.rgb * tintClr.rgb;
            fs_color = vec4( mixColor.rgb, fs_color.a);
        }

        vec4 graceTintClr = uGraceTintColors[gl_Layer];
        if (graceTintClr.a >= 0.f)
        {
            vec3 baseHSL = RGBtoHSL(fs_color.rgb);
            vec3 blendHSL = RGBtoHSL(graceTintClr.rgb);
            vec3 outHSL = vec3(blendHSL.rg, baseHSL.b);
            fs_color.rgb = HSLtoRGB(outHSL);
        }
    }
}