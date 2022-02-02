using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace GSEngine
{
    public class ScriptBase
    {
        public GameObject gameobject;
        
        public virtual void Start() { }
        public virtual void Update() { }

        public ScriptBase(ulong e)
        {
            gameobject = new GameObject(e);
        }

    }

}
