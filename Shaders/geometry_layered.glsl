#version 440

#define MAX_LAYERS 32

layout(triangles) in;
layout(triangle_strip, max_vertices = 3) out;

in vec2                         vs_texcoord[];
in uint                         vs_texlayer[];

out vec2                        gs_texcoord;

void main()
{
    for(int i = 0; i < 3; i++)
    {
            gl_Position = gl_in[i].gl_Position;
            gs_texcoord = vs_texcoord[i];
            gl_Layer = int(vs_texlayer[i]);
            EmitVertex();
    }
    EndPrimitive();
}