using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.Model;

namespace VectorGraphicsEditor.ItemStuff
{
    internal class Group : Item
    {
        List<Item> items;
        
        public Group(List<Item> items) : base(GetFrame(items))
        {
            this.items = items;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].SetRelativeFrame(Frame);
            }
            ChangeItems();
        }
        static private Frame GetFrame(List<Item> items)
        {
            if (!items.Any())
            {
                return new Frame();
            }
            Frame frame = new Frame(items[0].Frame.GetFrame());
            for (int i = 1; i < items.Count; i++)
            {
                frame.Add(items[i].Frame);
            }
            return frame;
        }
        /*public override Frame GetRelativeFrame(Frame frame)
        {
            throw new NotImplementedException();
        }*/
        public override bool TryGrab(int x, int y)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].TryGrab(x, y))
                {
                    return true;
                }
            }
            return false;
        }
        public List<Item> Destroy()
        {
            return items;
        }
        public override VectorGraphicsEditor.Model.Selection CreateSelection()
        {
            return new VectorGraphicsEditor.Model.GroupSelection(this);
        }
        public void ChangeItems()
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].ChangeFrameToRelative(Frame);
            }
        }
        public override void ChangeFrameToRelative(Frame relFrame)
        {
            base.ChangeFrameToRelative(relFrame);
            ChangeItems();
        }
        public override void Draw(DrawSystem drawSystem)
        {
            foreach(Item item in items)
            {
                item.Draw(drawSystem);
            }
        }
    }
}
