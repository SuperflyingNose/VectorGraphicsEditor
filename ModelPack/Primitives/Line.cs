using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.Model;

namespace VectorGraphicsEditor.Primitives
{
    internal class Line : Primitive
    {
        public Line(Frame frame, PropList propList) : base(frame, propList)
        {
        }

        public override VectorGraphicsEditor.Model.Selection CreateSelection()
        {
            
            return new VectorGraphicsEditor.Model.LineSelection(this); 
        }

        public override void DrawGeometry(DrawSystem drawSystem)
        {
            drawSystem.DrawLine(PropList, Frame);
        }
        public override bool TryGrab(int x, int y)
        {
            double k = (double)(Frame.y2 - Frame.y1) / (Frame.x2 - Frame.x1);
            double b = Frame.y2 - k * Frame.x2;
            
            if (y <= k * x + b + 5 && y >= k * x + b - 5)
            {
                return true;
            }
            return false;
        }
        /*public override Frame RelativeFrame(Frame frame)
        {
            return new Frame(this.Frame.x1/frame.x1, this.Frame.y1 / frame.y1, this.Frame.width / frame.width, this.Frame.length / frame.length);
        }*/
    }
}
