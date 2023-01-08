using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.Model;

namespace VectorGraphicsEditor.Primitives
{
    internal class Rectangle : Primitive
    {
        public Rectangle(Frame frame, PropList propList) : base(frame, propList)
        {
        }

        public override VectorGraphicsEditor.Model.Selection CreateSelection()
        {
            return new VectorGraphicsEditor.Model.RectSelection(this);
        }
        public override bool TryGrab(int x, int y)
        {
            if(Frame.GetFrame().Contains(x, y))
            {
                return true;
            }
            return false;
        }

        public override void DrawGeometry(DrawSystem drawSystem)
        {
            drawSystem.DrawRectangle(PropList, Frame);
        }

        public override Item Copy()
        {
            return new Rectangle(Frame, PropList);
        }
    }
}
