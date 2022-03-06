using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    internal class Physics
    {
        public static GameObject RayCast2D(Vector2 Position, Vector2 Direction, ref float Distance_Out)
        {
            return new GameObject(RayCast2D_Native(ref Position, ref Direction, ref Distance_Out));
        }

        public static GameObject RayCast2D_Layered(Vector2 Position, Vector2 Direction, ref float Distance_Out, string Layer)
        {
            return new GameObject(RayCast2D_Layered_Native(ref Position, ref Direction, ref Distance_Out, Layer));
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ulong RayCast2D_Native(ref Vector2 Position, ref Vector2 Direction, ref float Distance_Out);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ulong RayCast2D_Layered_Native(ref Vector2 Position, ref Vector2 Direction, ref float Distance_Out, string Layer);
    }
}