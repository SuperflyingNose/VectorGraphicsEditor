using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.Props;

namespace VectorGraphicsEditor
{
    internal class GrParams : IGrParams
    {
        public ILineProps lineProps { get; } = new LineProps(Color.Black, 0);

        public IFillProps fillProps { get; } = new FillProps(Color.Empty);
        Factory factory;

        public GrParams(Factory factory)
        {
            this.factory = factory;
        }

        public void ApplyChanges()
        {
            factory.ApplyProps(lineProps, fillProps);
        }
    }
}
