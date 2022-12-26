using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;

namespace VectorGraphicsEditor.Primitives
{
    internal abstract class Primitive: Item
    {
        
        public PropList PropList;
        public Primitive(Frame frame, PropList propList): base(frame)
        {
            PropList = propList;
        }

        public override void Draw(DrawSystem drawSystem)
        {
            PropList.Apply(drawSystem);
            DrawGeometry(drawSystem);
        }
        
        public abstract void DrawGeometry(DrawSystem drawSystem);
        /*public abstract Frame RelativeFrame(Frame frame);*/
    }
}
