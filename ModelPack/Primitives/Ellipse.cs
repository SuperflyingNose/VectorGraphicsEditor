using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.Model;
using VectorGraphicsEditor.Primitives;

namespace VectorGraphicsEditor.ModelPack.Primitives
{
    internal class Ellipse : Primitive
    {
        public Ellipse(Frame frame, PropList propList) : base(frame, propList)
        {
        }

        public override Selection CreateSelection()
        {
            return new VectorGraphicsEditor.Model.EllipseSelection(this);
        }
        public override bool TryGrab(int x, int y)
        {
            Frame.SetToNormal();
            if(y - Frame.y1 <= Math.Sqrt(1-Math.Pow((x - Frame.x1)-Frame.width/2 , 2)/ Math.Pow(Frame.width / 2, 2)) * Frame.length/2 + Frame.length / 2 &&
                y - Frame.y1 >= -Math.Sqrt(1 - Math.Pow((x - Frame.x1) - Frame.width / 2, 2) / Math.Pow(Frame.width / 2, 2)) * Frame.length / 2 + Frame.length / 2)
            {
                return true;
            }
            return false;
        }
        public override void DrawGeometry(DrawSystem drawSystem)
        {
            drawSystem.DrawEllipse(PropList, Frame);
        }

        public override Item Copy()
        {
            return new Ellipse(Frame, PropList);
        }
    }
}
