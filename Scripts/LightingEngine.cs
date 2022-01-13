using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    class LightingEngine
    {
        public static Vector3 Global_Color
        {
            get
            {
                GetGlobal_Color_Native(out Vector3 result);
                return result;
            }
            set
            {
                SetGlobal_Color_Native(ref value);
            }
        }
        public static float Global_Intensity
        {
            get
            {
                return GetGlobal_Intensity_Native();
            }
            set
            {
                SetGlobal_Intensity_Native(value);
            }
        }
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void GetGlobal_Color_Native(out Vector3 outGlobalColor);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetGlobal_Color_Native(ref Vector3 inGlobalColor);


        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern float GetGlobal_Intensity_Native();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void SetGlobal_Intensity_Native(float inglobalintensity);

    }
}
