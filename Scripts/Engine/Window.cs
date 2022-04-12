using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    public class Window
    {
        public static Vector2 GetCenterOfScreen()
        {
            GetCenterOfScreen_Native(out Vector2 result);
            return result;
        }

        public static void ChangeGameDimensions(Vector2 inDims)
        {
            ChangeGameDimensions_Native(ref inDims);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void ChangeGameDimensions_Native(ref Vector2 inDims);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetFullScreen(bool fullscreen);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetWidth();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int GetHeight();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool IsFocused();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetShowCursor(bool show);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void GetCenterOfScreen_Native(out Vector2 outCenter);
    }
}
