using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSEngine
{
    public class Utility
    {
        //Timer has to be between 0-1, 0 is start, 1 is end
        public static float Lerp(float startValue, float endValue, float timer)
        {
            return startValue + (endValue - startValue) * timer;
        }
    }
}
