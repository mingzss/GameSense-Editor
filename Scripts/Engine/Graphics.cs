using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    public class Graphics
    {
        public class Global
        {
            public static Vector3 Light_Color
            {
                get
                {
                    GetGlobal_Light_Color_Native(out Vector3 result);
                    return result;
                }
                set
                {
                    SetGlobal_Light_Color_Native(ref value);
                }
            }
            public static float Light_Intensity
            {
                get
                {
                    return GetGlobal_Light_Intensity_Native();
                }
                set
                {
                    SetGlobal_Light_Intensity_Native(value);
                }
            }

            public class PostProcessingEffects
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern string GetCurrentMode();

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetCurrentMode(string modeName);

                public class Tint
                {
                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern bool IsEnabled(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Disable(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void GetColor(string modename, out Vector3 outcolor);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetColor(string modename, ref Vector3 incolor);
                }

                public class GraceTint
                {
                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern bool IsEnabled(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Disable(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void GetColor(string modename, out Vector4 outcolor);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetColor(string modename, ref Vector4 incolor);
                }

                public class ChromaticAberration
                {
                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern bool IsEnabled(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Disable(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetValue(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetValue(string modename, float value);
                }

                public class ColorGrading
                {
                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern bool IsEnabled(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Disable(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetHue(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetHue(string modename, float value);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetSaturation(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetSaturation(string modename, float value);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetBrightness(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetBrightness(string modename, float value);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetContrast(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetContrast(string modename, float value);

                }

                public class Temperature
                {
                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern bool IsEnabled(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Disable(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern int GetValue(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetValue(string modename, int value);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetSaturation(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetSaturation(string modename, float value);

                }

                public class GaussianBlur
                {
                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern bool IsEnabled(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Disable(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetAmount(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetAmount(string modename, float value);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern float GetStandardDeviation(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetStandardDeviation(string modename, float value);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern int GetSamples(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void SetSamples(string modename, int value);

                }

                public class GreyScale
                {
                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern bool IsEnabled(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Enable(string modename);

                    [MethodImpl(MethodImplOptions.InternalCall)]
                    public static extern void Disable(string modename);
                }
            }

            [MethodImpl(MethodImplOptions.InternalCall)]
            private static extern void GetGlobal_Light_Color_Native(out Vector3 outGlobalColor);

            [MethodImpl(MethodImplOptions.InternalCall)]
            private static extern void SetGlobal_Light_Color_Native(ref Vector3 inGlobalColor);

            [MethodImpl(MethodImplOptions.InternalCall)]
            private static extern float GetGlobal_Light_Intensity_Native();

            [MethodImpl(MethodImplOptions.InternalCall)]
            private static extern void SetGlobal_Light_Intensity_Native(float inglobalintensity);

        }

        public class LayerPostProcessingEffects
        {

            [MethodImpl(MethodImplOptions.InternalCall)]
            public static extern string GetCurrentMode(string layer);

            [MethodImpl(MethodImplOptions.InternalCall)]
            public static extern void SetCurrentMode(string layer, string modeName);

            public class Tint
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern bool IsEnabled(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Disable(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void GetColor(string layername, string modename, out Vector3 outcolor);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetColor(string layername, string modename, ref Vector3 incolor);
            }

            public class GraceTint
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern bool IsEnabled(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Disable(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void GetColor(string layername, string modename, out Vector4 outcolor);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetColor(string layername, string modename, ref Vector4 incolor);
            }

            public class ChromaticAberration
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern bool IsEnabled(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Disable(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetValue(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetValue(string layername, string modename, float value);
            }

            public class ColorGrading
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern bool IsEnabled(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Disable(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetHue(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetHue(string layername, string modename, float value);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetSaturation(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetSaturation(string layername, string modename, float value);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetBrightness(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetBrightness(string layername, string modename, float value);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetContrast(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetContrast(string layername, string modename, float value);

            }

            public class Temperature
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern bool IsEnabled(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Disable(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern int GetValue(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetValue(string layername, string modename, int value);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetSaturation(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetSaturation(string layername, string modename, float value);
            }

            public class GaussianBlur
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern bool IsEnabled(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Disable(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetAmount(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetAmount(string layername, string modename, float value);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern float GetStandardDeviation(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetStandardDeviation(string layername, string modename, float value);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern int GetSamples(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void SetSamples(string layername, string modename, int value);
            }

            public class GreyScale
            {
                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern bool IsEnabled(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Enable(string layername, string modename);

                [MethodImpl(MethodImplOptions.InternalCall)]
                public static extern void Disable(string layername, string modename);
            }
        }
    }
}
