using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    public class TCPManager
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool Connect(string ip_addr, int port);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Disconnect();

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool SendData(IntPtr data, uint size);
    }
}
