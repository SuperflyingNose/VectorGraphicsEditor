using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor.Props
{
    internal abstract class Prop
    {
        abstract public void Apply(DrawSystem drawSystem);
    }
}
