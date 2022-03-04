#version 440

#define MAX_LIGHTS 250
#define FLT_EPSILON 0.0001f

in vec2                         gs_texcoord;
in vec4 						gs_sprite_color;
in vec4 						gs_position;
flat in uint 					gs_texture_slot;

out vec4 						fs_color;

struct GlobalLight
{
	vec3 clr;
	float intensity;
};

struct PointLight
{	
	vec4 pos;
	vec4 clr;
	float inner_radius;
	float outer_radius;
	float fall_off_intensity;
	float intensity;
	float rotation;
	float inner_angle;
	float outer_angle;
	float padding;
};

uniform int uNumLights;
uniform vec2 uWindowSize;
uniform sampler2D textureSamples[31];
uniform sampler2DArray uTexSpriteLights;
uniform GlobalLight uGlobalLight;

layout(std140) uniform PointLightArray
{
	PointLight lights[MAX_LIGHTS];
} uPointLights;

mat2 rotation (float angleDeg)
{
	float c = cos(radians(angleDeg));
	float s = sin(radians(angleDeg));
	return mat2 (c, s, -s, c);
}

void main()
{
	vec4 col = texture(textureSamples[gs_texture_slot], gs_texcoord);
	if (col.a < 0.05f)
		discard;

	vec4 ptLightFactor = {0.0f, 0.0f, 0.0f, 0.0f};

	for (int i = 0; i < uNumLights; ++i)
	{
		if (uPointLights.lights[i].pos.z - gs_position.z > FLT_EPSILON) 
			continue;
		vec4 curLightFactor = {0.0f, 0.0f, 0.0f, 0.0f};
		vec4 dis_from_light =  gs_position - uPointLights.lights[i].pos;
		
		float sq_dist = dot(dis_from_light, dis_from_light);

		if (sq_dist > uPointLights.lights[i].outer_radius * 
			uPointLights.lights[i].outer_radius)
			continue;

		curLightFactor = 
			uPointLights.lights[i].clr * uPointLights.lights[i].intensity;

		if (sq_dist > uPointLights.lights[i].inner_radius * 
			uPointLights.lights[i].inner_radius)
			{
				float distanceFactor = 
					1.0f - 
						(sqrt(sq_dist) - uPointLights.lights[i].inner_radius) / 
							(uPointLights.lights[i].outer_radius - 
								uPointLights.lights[i].inner_radius);
			
				curLightFactor *= distanceFactor;	
			}
		
		// if (uPointLights.lights[i].inner_angle > FLT_EPSILON)
		// {
			vec2 dir = 
				normalize(gs_position.xy - uPointLights.lights[i].pos.xy);
			vec2 center = 
				rotation(uPointLights.lights[i].rotation) * vec2(0.0f, 1.0f);
			float angle = abs(degrees(acos(dot(dir, center)))) * 2.0f;

			if (uPointLights.lights[i].inner_angle < angle && 
				angle <= uPointLights.lights[i].outer_angle)
			{
				float angleFactor = 
					1.0f - 
						(angle - uPointLights.lights[i].inner_angle) / 
							(uPointLights.lights[i].outer_angle - 
								uPointLights.lights[i].inner_angle);
					
				curLightFactor *= angleFactor;
			}

			else if (angle > uPointLights.lights[i].outer_angle)
			{
				curLightFactor *= 0.0f;
			}
		// }
		// else
		// {
		// 	curLightFactor *= 0.0f;
		// }

		ptLightFactor += curLightFactor;
	}
	
	vec4 globalLightFactor = 
		vec4(uGlobalLight.clr * uGlobalLight.intensity, 1.0f);

	vec2 spriteUV = 
		vec2(gl_FragCoord.x / uWindowSize.x, gl_FragCoord.y / uWindowSize.y);
	vec4 spriteLightFactor =
		texture(uTexSpriteLights, vec3(spriteUV, gl_Layer));
	vec4 totalLightFactor = 
		globalLightFactor + ptLightFactor + spriteLightFactor;
	totalLightFactor.rgb *= totalLightFactor.a;
	col *= gs_sprite_color;
	col.rgb *= col.a;
	fs_color =  clamp((col) * totalLightFactor, 0.0f, 1.0f);
}