using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace GSEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ComponentBase
    {
        public bool isDirty;

        public ComponentBase(bool dirty = true)
        {
            isDirty = dirty;
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        public float x;
        public float y;
        public Vector2(float x1, float y1)
        {
            x = x1;
            y = y1;
        }
        public Vector2(Vector2 v2)
        {
            x = v2.x;
            y = v2.y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x1, float y1, float z1)
        {
            x = x1;
            y = y1;
            z = z1;
        }
        public Vector3(Vector3 v2)
        {
            x = v2.x;
            y = v2.y;
            z = v2.z;
        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public float r 
        { 
            get 
            {
                return x;
            }
            set
            {
                x = value;
            } 
        }
        public float g
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public float b
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
        public float a
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }

        public Vector4(float x1, float y1, float z1, float w1)
        {
            x = x1;
            y = y1;
            z = z1;
            w = w1;
        }
        public Vector4(Vector4 v2)
        {
            x = v2.x;
            y = v2.y;
            z = v2.z;
            w = v2.w;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4
    {
        public float m00; public float m01; public float m02; public float m03; //1st Column
        public float m10; public float m11; public float m12; public float m13; //2nd Column
        public float m20; public float m21; public float m22; public float m23; //3rd Column
        public float m30; public float m31; public float m32; public float m33; //4th Column
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Transform
    {
        public Vector2 position;

        public float rotation;

        public Vector2 scale;

        private ComponentBase component_base;

        //more positive = further away from camera
        public string layer;

        public Transform(Vector2 pos = new Vector2(), float rot = 0, Vector2 scl = new Vector2(), string zd = "Default")
        {
            position = pos;
            rotation = rot;
            scale = scl;
            layer = zd;
            component_base = new ComponentBase();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct UITransform
    {
        public Vector2 position;

        public float rotation;

        public Vector2 scale;

        public Vector2 anchor;

        public int sortingorder;

        private ComponentBase component_base;

        public UITransform(Vector2 pos = new Vector2(), float rot = 0, Vector2 scl = new Vector2(), Vector2 ancr = new Vector2(), int sortOrder = 0)
        {
            position = pos;
            rotation = rot;
            scale = scl;
            anchor = ancr;
            sortingorder = sortOrder;
            component_base = new ComponentBase();
        }
    }

    public enum SHEAR_DIRECTION
    {
        X = 0, 
        Y = 1
    }

    public enum SHEARED_VERTICES
    {
        NONE = 0,
		TOP = 1,
		BOTTOM = 2,
		RIGHT = 3,
		LEFT = 4
    };


    [StructLayout(LayoutKind.Sequential)]
    public struct QuadShear
    {
        public SHEAR_DIRECTION direction;
        public float magnitude;
        public SHEARED_VERTICES shearedVertex;
        private ComponentBase component_base;
    }

    public enum RENDERING_MODE
    {
        NONE = 0,
        SHADED = 1,
        WIREFRAME = 2
    }
    public enum BLEND_MODE
    {
        ADD = 0,
		SUBTRACT = 1,
		REVERSE_SUBTRACT = 2,
		MIN = 3,
		MAX = 4
	};

    [StructLayout(LayoutKind.Sequential)]
    public struct DrawProperties
    {
        public RENDERING_MODE DrawMode;
        public BLEND_MODE BlendMode;
        public string Shader;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TextureData
    {
        public readonly uint id;
        public readonly int width;
        public readonly int height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpriteSheet
    {
        public int Columns;
        public int Rows;
        public int StartFrame;
        public int EndFrame;
        public int CurrentFrame;
        public float FrameDelay;
        public bool Loop;
        private readonly Vector4 UV;
        public readonly float AnimTimer;
        public readonly bool AnimComplete;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Texture
    {
        public readonly TextureData TextureData;

        public bool Enabled;

        public SpriteSheet SpriteSheet;

        public int Width;
        public int Height;

        public Vector4 Color;
        public int PixelsPerUnit;

        public bool IsFlippedX;
        public bool IsFlippedY;

        private readonly Vector4 CustomTexturePercent;
        private ComponentBase component_base;
        public DrawProperties DrawProperties;

        public string ImagePath;
    }

    public enum LeftAlignment
    {
        LEFT,
	    CENTER,
	    RIGHT
    };

    public enum TopAlignment
    {
        TOP,
	    CENTER,
	    BOTTOM
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct TextObject
    {
        public bool Enabled;
        private char[] Font;
        public LeftAlignment LeftAlignment;
        public TopAlignment TopAlignment;
        public float Scale;
        public bool AutoSize;
        public float Width;
        public float Height;
        public Vector4 TextColor;
        public int PixelsPerUnit;
        private ComponentBase component_base;
        public DrawProperties DrawProperties;
        public string FontPath;
        public string Text;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ShakeProperties
    {
        private float TimePassed;
        private float Speed;
        private float MaxMagnitude;
        private float NoiseMagnitude;
        private Vector2 Direction;
        private float Fade;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Camera
    {
        private float zNear;
        private float zFar;
        public float Zoom;
        public float MinZoom;
        public float MaxZoom;

        public Vector2 ViewportPosition;
        public Vector2 ViewportSize;

        public float Smoothness;
        public ulong GoFollowing;
        public bool FollowX;
        public bool FollowY;
        public bool ToRender;

        private Vector2 Up;
        private Vector2 Right;
        private bool ProjMatChanged;

        private ShakeProperties ShakeProperties;

        private Matrix4 ProjectionMatrix;
        private Matrix4 CameraMatrix;
        private Matrix4 UIProjectionMatrix;

        private int GameWidth;
        private int GameHeight;

        private float AspectRatio;
        private int ScreenWidth;
        private int ScreenHeight;

        private ComponentBase component_base;
    }

    public enum SOUND_GROUP
    {
        SFX = 0,
		MUSIC = 1,
        STEREO = 2,
        MASTER = 3
    };
    
    public enum EQ_GROUP
    {
        NORMAL = 0,
        LOW_PASS_FILTER = 1,
        ECHO = 2,
        DISTORTION = 3
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct AudioObject
    {
        private int ChannelID;
        private uint PlayCount;
        public bool Enabled;
        public bool Loop;
        public bool AutoPlay;
        public bool StereoSound;
        public float Volume;
        public EQ_GROUP EQGroup;
        public SOUND_GROUP SoundGroup;
        private ComponentBase component_base;

        public string SoundFile;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Material
    {
        float restituition;
        float friction;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RigidBody
    {
        Material material;
        Vector2 velocity;
        Vector2 gravity;
        float angular_velocity;
        float mass;
        float rotational_inertia;
        float linear_damping;
        float angular_damping;

        bool is_awake;
        bool fixed_rotation;
        bool is_static;

        private Vector2 forces;
        private float torque;
        private float inverse_mass;
        private float inverse_rotational_inertia;
        private float sleep_timer;

        private ComponentBase component_base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CircleCollider2D
    {
        public float radius;
        public bool enabled;
        public bool is_trigger;
        public bool was_triggered;
        public Vector2 offset;
        private ComponentBase component_base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BoxCollider2D
    {
        public Vector2 offset;
        public Vector2 size;

        public bool enabled;
        public bool is_trigger;
        private readonly bool was_triggered;
        private ComponentBase component_base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AnimController
    {
        public bool enabled;
        private bool nameUpdated;
        private ComponentBase component_base;
        public string controller_name;
    }
}
