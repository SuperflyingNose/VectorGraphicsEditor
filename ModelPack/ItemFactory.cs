using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.ModelPack.Primitives;
using VectorGraphicsEditor.Primitives;
using VectorGraphicsEditor.Props;

namespace VectorGraphicsEditor
{
    internal class Factory
    {
        Store store;
        public ItemType itemType { get; set; }
        LineProps lineProps { get; } = new LineProps(System.Drawing.Color.Black, 0);
        FillProps fillProps { get; } = new FillProps(System.Drawing.Color.Empty);
        
        
        public Factory(Store store)
        {
            this.store = store;
        }
        public Item CreateItem(int x, int y)
        {
            Frame frame;
            PropList propList;
            switch (itemType)
            {
                case ItemType.itLine:
                    frame = new Frame(x, y, 50, 50);
                    propList = new PropList();
                    propList.Proreties.Add(lineProps.Copy());
                    var line = new Line(frame, propList);
                    store.Add(line);
                    return line;
                    break;
                case ItemType.itRectangle:
                    frame = new Frame(x, y, 50, 50);
                    propList = new PropList();
                    propList.Proreties.Add(lineProps.Copy());
                    propList.Proreties.Add(fillProps.Copy());
                    var rectangle = new Rectangle(frame, propList);
                    store.Add(rectangle);
                    return rectangle;
                    break;
                case ItemType.itEllipse:
                    frame = new Frame(x, y, 50, 50);
                    propList = new PropList();
                    propList.Proreties.Add(lineProps.Copy());
                    propList.Proreties.Add(fillProps.Copy());
                    var ellipse = new Ellipse(frame, propList);
                    store.Add(ellipse);
                    return ellipse;
                    break;
            }
            return null;
        }
        public Item CreateGroup(List<Item> items)
        {
            Item group = new Group(items);
            for (int i = 0; i < items.Count; i++)
            {
                store.Remove(items[i]);
            }
            return group;
        }
        public void ApplyProps(ILineProps lineProps, IFillProps fillProps)
        {
            this.lineProps.Color = lineProps.Color;
            this.lineProps.Width = lineProps.Width;

            this.fillProps.Color = fillProps.Color;

        }
    }
}
