using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor.Props
{
    internal class LineProps : Prop, ILineProps
    {
        public int Width { get; set; }
        public Color Color { get; set; }
        
        public LineProps(Color color, int Width)
        {
            Color = color;
            this.Width = Width;
        }

        

        public override void Apply(DrawSystem drawSystem)
        {
            drawSystem.ApplyLineColor(Color);
            drawSystem.ApplyLineWidth(Width);
        }
        public LineProps Copy()
        {
            return new LineProps(Color, Width); 
        }
    }
}
