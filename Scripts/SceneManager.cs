using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GSEngine
{
    class SceneManager
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string GetCurrentSceneName();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ChangeScene(string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void PreloadScene(string name, uint sleepDelay = 100);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float GetPreloadingScene_LoadPercentage(string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern float GetPreloadingScene_InitPercentage(string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool GetPreloadingScene_Completed(string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void QuitGame();

    }
}
