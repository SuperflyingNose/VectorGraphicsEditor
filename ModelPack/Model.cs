using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.Primitives;

namespace VectorGraphicsEditor.Model
{
    internal class Model : IModel
    {
        public IGrParams GrParams {get; set;}
        public ItemType CreatingItemType { get; set; } = ItemType.itNone;
        public ISelections selectionController { get; set; }
        DrawSystem drawSystem;
        Store store;
        Factory factory;
        Scene scene;

        public Model()
        {
            store = new Store();
            factory = new Factory(store);
            factory.itemType = CreatingItemType;
            GrParams = new GrParams(factory);
            scene = new Scene(store, drawSystem);
            selectionController = new SelController(scene.selectionStore, store, factory);
        }
        public bool CreateAndGrabItem(int x, int y)
        {
            selectionController.SkipSelections();
            ItemStuff.Item item = CreateItem(x, y);
            if(item == null) { return false; }
            Selection s = item.CreateSelection();
            scene.selectionStore.Add(s);
            s.Draw(drawSystem);
            return scene.selectionStore.TryGrab(x, y) != null;
        }

        public ItemStuff.Item CreateItem(int x, int y)
        {
            factory.itemType = CreatingItemType;
            ItemStuff.Item item = factory.CreateItem(x, y);
            Repaint();
            return item;
        }

        

        public void Repaint()
        {
            scene.Repaint();
            scene.selectionStore.Draw(drawSystem);
        }

        public void SetGrPort(Graphics g, int Width, int Height)
        {
            drawSystem = new DrawSystem(g);
            scene.drawSystem = drawSystem;
        }
    }
}
