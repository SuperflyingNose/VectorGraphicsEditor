using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.Props;

namespace VectorGraphicsEditor.ItemStuff
{
    internal class PropList
    {
        public List<Prop> Proreties = new List<Prop>();
        //public LineProps LineProps;
        //public FillProps FillProps;
        public void Apply(DrawSystem drawSystem)
        {
            foreach(Prop p in Proreties)
            {
                p.Apply(drawSystem);
            }
        }
    }
}
