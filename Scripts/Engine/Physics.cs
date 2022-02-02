using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    class Physics
    {
        public static GameObject RayCast2D(Vector2 Position, Vector2 Direction)
        {
            return new GameObject(RayCast2D_Native(ref Position, ref Direction));
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ulong RayCast2D_Native(ref Vector2 Position, ref Vector2 Direction);

    }
}
