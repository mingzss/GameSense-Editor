using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSEngine
{
    public static class GlobalResource<T>
    {
        private static Dictionary<string, T> m_resources = new Dictionary<string, T>();

        public static bool AddResource(string r_name, T value)
        {
            if (m_resources.ContainsKey(r_name))
            {
                return false;
            }

            m_resources.Add(r_name, value);
            return true;
        }

        public static bool GetResource(string r_name, ref T value)
        {
            if (m_resources.ContainsKey(r_name))
            {
                value = m_resources[r_name];
                return true;
            }
            return false;
        }

        public static bool UpdateResource(string r_name, T value)
        {
            if (m_resources.ContainsKey(r_name))
            {
                m_resources[r_name] = value;
                return true;
            }
            return false;
        }

        public static void ClearResource(string r_name)
        {
            m_resources.Remove(r_name);
        }

        public static void ClearAllResources()
        {
            m_resources.Clear();
        }
    }
}
