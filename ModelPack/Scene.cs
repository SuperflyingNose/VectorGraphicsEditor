using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.Model;

namespace VectorGraphicsEditor
{
    internal class Scene
    {
        Store store;
        public SelectionStore selectionStore;
        public DrawSystem drawSystem;
        public Scene(Store store, DrawSystem drawSystem) {
            this.store = store;
            this.drawSystem = drawSystem;
            selectionStore = new SelectionStore();
        }
        public void Repaint()
        {
            drawSystem.Clear();
            foreach (var item in store)
            {
                item.Draw(drawSystem);
            }
        }
    }
}
