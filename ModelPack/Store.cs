using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;

namespace VectorGraphicsEditor
{
    internal class Store: List<Item>
    {
        public Item TryGrab(int x, int y)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].TryGrab(x, y))
                {
                    return this[i];
                }
            }
            return null;
        }
    }
}
