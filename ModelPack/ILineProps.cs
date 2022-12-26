using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor
{
    internal interface ILineProps
    {
        int Width { get; set; }
        Color Color { get; set; }
    }
}
