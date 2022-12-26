using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor.Props
{
    internal class FillProps : Prop, IFillProps
    {
        public Color Color { get; set; }
        public FillProps(Color color)
        {
            Color = color;
        }

        

        public override void Apply(DrawSystem drawSystem)
        {
            drawSystem.ApplyFillColor(Color);
        }
        public FillProps Copy()
        {
            return new FillProps(Color);
        }
    }
}
