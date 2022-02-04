#version 440

layout(triangles) in;
layout(triangle_strip, max_vertices=3) out;

in vec2                         vs_texcoord[];
in vec4                         vs_sprite_color[];
in vec4                         vs_position[];
flat in uint                    vs_texture_slot[];
flat in uint                    vs_texture_layer[];

out vec2                        gs_texcoord;
out vec4                        gs_sprite_color;
out vec4                        gs_position;
flat out uint                   gs_texture_slot;

void main()
{
    for(int i=0; i<3; i++)
    {
        gl_Position = gl_in[i].gl_Position;
        gs_texcoord = vs_texcoord[i];
        gs_sprite_color = vs_sprite_color[i];
        gs_texture_slot = vs_texture_slot[i];
        gs_position = vs_position[i];
        gl_Layer = int(vs_texture_layer[i]);
        EmitVertex();
    }
    EndPrimitive();

}  