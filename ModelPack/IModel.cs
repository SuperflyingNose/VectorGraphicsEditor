using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ControllerPack;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.Model;

namespace VectorGraphicsEditor
{
    internal interface IModel
    {
        IGrParams GrParams { get; }
        ItemType CreatingItemType { get; set; }

        ISelections selectionController { get; }
        IUndoRedoController UndoRedoController { get; }
        void SetGrPort(Graphics g, int Width, int Height);
        Item CreateItem(int x, int y);
        ItemStuff.Item GetLastCreatedItem();
        void Repaint();
    }
}
