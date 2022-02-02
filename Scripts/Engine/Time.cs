using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GSEngine
{
    public class Time
    {
        public static float DeltaTime
        {
            get
            {
                return GetDeltaTime_Native();
            }
        }
        public static int FPS
        {
            get
            {
                return GetFPS_Native();
            }
        }
        public static float GameTime
        {
            get
            {
                return GetGameTime_Native();
            }
        }
        public static float CurrentTime
        {
            get
            {
                return GetCurrentTime_Native();
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern float GetDeltaTime_Native();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int GetFPS_Native();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern float GetGameTime_Native();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern float GetCurrentTime_Native();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void PauseDT();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void UnPauseDT();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsDTPaused();

    }
}
