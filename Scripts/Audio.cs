using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    class Audio
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void StopAll();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void StopAll_SoundGroup(SOUND_GROUP sg);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SetVolume_SoundGroup(SOUND_GROUP sg, float perc);
    }
}
