using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalHotKey
{
    class KeyPair : HashSet<Keys>
    {
        public KeyPair() : base() { }
        public KeyPair(KeyPair pair_old) : base(pair_old) {
        }

        public KeyPair(Keys[] keys): base(keys) { }
        public override int GetHashCode()
        {
            Keys[] array = new Keys[base.Count];
            base.CopyTo(array);
            Array.Sort(array,delegate(Keys key1, Keys key2) {
                return (int)key1 - (int)key2;
            });
            int hc = array.Length;
            for (int i = 0; i < array.Length; ++i)
            {
                hc = unchecked(hc * 314159 + (int)array[i]);
            }
            return hc;
        }

        public override bool Equals(object obj)
        {
            return base.GetHashCode() == obj.GetHashCode();
        }
    }
}
