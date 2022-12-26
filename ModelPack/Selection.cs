using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;

namespace VectorGraphicsEditor.Model
{
    abstract internal class Selection
    {
        internal int margin = 3;

        public Item item;


        protected int startGrabX = -1;
        protected int startGrabY = -1;
        protected List<Rectangle> points = new List<Rectangle>();

        protected ChangeType changeType;
        protected int activeNode;
        abstract public void Draw(DrawSystem drawSystem);
        virtual public int TryGrab(int x, int y)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Contains(x, y))
                {
                    changeType = ChangeType.Resize;
                    activeNode = i;
                    return 1;
                }
            }
            activeNode = -1;

            if (item.TryGrab(x, y))
            {
                changeType = ChangeType.Move;
                startGrabX = x;
                startGrabY = y;
                return 2;
            }
            return 0;
        }
        abstract public bool TryDragTo(int x, int y);
    }
    enum ChangeType
    {
        Resize,
        Move
    }
    internal class LineSelection : Selection
    {
        /*List<Rectangle> points = new List<Rectangle>();

        ChangeType changeType;
        int activeNode;*/
        public LineSelection(Item item)
        {
            this.item = item;
            points.Add(new Rectangle(item.Frame.x1 - margin, item.Frame.y1 - margin, margin*2, margin * 2));
            points.Add(new Rectangle(item.Frame.x2 - margin, item.Frame.y2 - margin, margin * 2, margin * 2));
        }
        public override void Draw(DrawSystem drawSystem)
        {
            drawSystem.DrawSelect(points);
            drawSystem.DrawFrame(item.Frame);
        }

        public override bool TryDragTo(int x, int y)
        {
            int px = x - margin;
            int py = y - margin;


            switch (changeType)
            {
                case ChangeType.Resize:
                    if(activeNode == -1) { return false; }
                    Rectangle r = points[activeNode];
                    r.X = px;
                    r.Y = py;
                    points[activeNode] = r;
                    item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[1].Y - points[0].Y);

                    
                    return true;
                    break;
                case ChangeType.Move:
                    for (int i = 0; i < points.Count; i++)
                    {
                        var p = points[i];
                        p.X += x - startGrabX;
                        p.Y += y - startGrabY;
                        points[i] = p;
                    }
                    item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[1].Y - points[0].Y);
                    startGrabX = x;
                    startGrabY = y;
                    return true;
            }
            return false;
        }

        
    }
    internal class RectSelection : Selection
    {
        
        public RectSelection(Item item)
        {
            this.item = item;
            points.Add(new Rectangle(item.Frame.x1 - margin, item.Frame.y1 - margin, margin * 2, margin * 2));
            points.Add(new Rectangle(item.Frame.x1 + item.Frame.width - margin, item.Frame.y1 - margin, margin * 2, margin * 2));
            points.Add(new Rectangle(item.Frame.x1 + item.Frame.width - margin, item.Frame.y1 + item.Frame.length - margin, margin * 2, margin * 2));
            points.Add(new Rectangle(item.Frame.x1 - margin, item.Frame.y1 + item.Frame.length - margin, margin * 2, margin * 2));
        }
        public override void Draw(DrawSystem drawSystem)
        {
            drawSystem.DrawSelect(points);
            drawSystem.DrawFrame(item.Frame);
        }

        public override bool TryDragTo(int x, int y)
        {
            int px = x - margin;
            int py = y - margin;

            
            switch (changeType)
            {
                case ChangeType.Resize:
                    if (activeNode == -1) { return false; }
                    Rectangle r = points[activeNode];
                    r.X = px;
                    r.Y = py;
                    points[activeNode] = r;
                    switch (activeNode)
                    {
                        case 0:
                            r = points[1];
                            r.Y = py;
                            points[1] = r;
                            r = points[3];
                            r.X = px;
                            points[3] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                        case 1:
                            r = points[0];
                            r.Y = py;
                            points[0] = r;
                            r = points[2];
                            r.X = px;
                            points[2] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                        case 2:
                            r = points[3];
                            r.Y = py;
                            points[3] = r;
                            r = points[1];
                            r.X = px;
                            points[1] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                        case 3:
                            r = points[2];
                            r.Y = py;
                            points[2] = r;
                            r = points[0];
                            r.X = px;
                            points[0] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                    }
                    
                    
                    return true;
                    break;
                case ChangeType.Move:
                    for (int i = 0; i < points.Count; i++)
                    {
                        var p = points[i];
                        p.X += x - startGrabX;
                        p.Y += y - startGrabY;
                        points[i] = p;
                    }
                    item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                    startGrabX = x;
                    startGrabY = y;
                    return true;
            }
            return false;
        }
        

        
    }
    internal class EllipseSelection : RectSelection
    {
        public EllipseSelection(Item item) : base(item)
        {
        }
    }
    internal class GroupSelection : Selection
    {
        List<Frame> relativeFrames = new List<Frame>();
        public GroupSelection(Item group)
        {
            this.item = group;
            points.Add(new Rectangle(item.Frame.x1 - margin, item.Frame.y1 - margin, margin * 2, margin * 2));
            points.Add(new Rectangle(item.Frame.x1 + item.Frame.width - margin, item.Frame.y1 - margin, margin * 2, margin * 2));
            points.Add(new Rectangle(item.Frame.x1 + item.Frame.width - margin, item.Frame.y1 + item.Frame.length - margin, margin * 2, margin * 2));
            points.Add(new Rectangle(item.Frame.x1 - margin, item.Frame.y1 + item.Frame.length - margin, margin * 2, margin * 2));
            
        }
        public override void Draw(DrawSystem drawSystem)
        {
            drawSystem.DrawFrame(item.Frame);
            drawSystem.DrawSelect(points);
        }

        public override bool TryDragTo(int x, int y)
        {
            int px = x - margin;
            int py = y - margin;


            switch (changeType)
            {
                case ChangeType.Resize:
                    if (activeNode == -1) { return false; }
                    Rectangle r = points[activeNode];
                    r.X = px;
                    r.Y = py;
                    points[activeNode] = r;
                    switch (activeNode)
                    {
                        case 0:
                            r = points[1];
                            r.Y = py;
                            points[1] = r;
                            r = points[3];
                            r.X = px;
                            points[3] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                        case 1:
                            r = points[0];
                            r.Y = py;
                            points[0] = r;
                            r = points[2];
                            r.X = px;
                            points[2] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                        case 2:
                            r = points[3];
                            r.Y = py;
                            points[3] = r;
                            r = points[1];
                            r.X = px;
                            points[1] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                        case 3:
                            r = points[2];
                            r.Y = py;
                            points[2] = r;
                            r = points[0];
                            r.X = px;
                            points[0] = r;
                            item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                            break;
                    }
                    
                    item.Frame.SetToNormal();
                    ((Group)item).ChangeItems();
                    return true;
                    break;
                case ChangeType.Move:
                    for (int i = 0; i < points.Count; i++)
                    {
                        var p = points[i];
                        p.X += x - startGrabX;
                        p.Y += y - startGrabY;
                        points[i] = p;
                    }
                    item.Frame = new Frame(points[0].X + margin, points[0].Y + margin, points[1].X - points[0].X, points[2].Y - points[1].Y);
                    startGrabX = x;
                    startGrabY = y;
                    ((Group)item).ChangeItems();
                    return true;
            }
            return false;
        }

        
    }
    internal class SelectionStore: List<Selection>
    {
        public void Draw(DrawSystem drawSystem)
        {
            foreach(var selection in this)
            {
                selection.Draw(drawSystem);
            }
        }
        public Selection TryGrab(int x, int y)
        {
            foreach (var select in this)
            {
                if(select.TryGrab(x, y) != 0)
                {
                    ActiveSelection = select;
                    return select;
                }
            }
            return null;
        }
        public Selection ActiveSelection { get; private set; }
        public void ReleaseActiveSelection()
        {
            ActiveSelection = null;
        }
        public void SkipActiveSelection()
        {
            ActiveSelection = null;

            Clear();
        }
    }
    interface ISelections
    {
        SelectionStore selectionStore { get; set; }
        Store store { get; set; }
        Factory factory { get; set; }
        bool TryDragActiveSelection(int x, int y);
        void ReleaseActiveSelection();
        void SkipSelections();//убирает выделение 
        void DeleteSelections();
        bool TryGrab(int x, int y, bool adder);
        bool Group();
        bool UnGroup();
        int Count { get; }
    }
    internal class SelController : ISelections
    {
        public SelectionStore selectionStore { get; set; }
        public Store store { get; set; }    
        public Factory factory { get; set; }    
        public int Count { get { return selectionStore.Count; } }
        public SelController(SelectionStore selStore, Store store, Factory factory)
        {
            selectionStore = selStore;
            this.store = store;
            this.factory = factory;
        }
        public void ReleaseActiveSelection()
        {
            selectionStore.ReleaseActiveSelection();
        }

        public void SkipSelections()
        {
            selectionStore.SkipActiveSelection();

        }
        public void DeleteSelections()
        {
            for (int i = 0; i < selectionStore.Count; i++)
            {
                store.Remove(selectionStore[i].item);
            }
        }
        public bool TryGrab(int x, int y, bool adder)
        {
            var grabbedItem = store.TryGrab(x, y);
            if (!adder) { SkipSelections(); }
            if(grabbedItem != null)
            {
                selectionStore.Add(grabbedItem.CreateSelection());
                return true;
            }
            return false;
        }

        public bool Group()
        {
            if(Count > 1)
            {
                List<Item> items = new List<Item>();
                for (int i = 0; i < Count; i++)
                {
                    selectionStore[i].item.Frame.SetToNormal();
                    items.Add(selectionStore[i].item);
                }
                Item group = factory.CreateGroup(items);
                
                selectionStore.Clear();
                selectionStore.Add(group.CreateSelection());
                store.Add(group);
                return true;
            }
            return false;
        }
        public bool UnGroup()
        {
            if(Count == 1 && selectionStore[0].item is Group)
            {
                List<Item> items = ((Group)selectionStore[0].item).Destroy();
                store.Remove(selectionStore[0].item);
                selectionStore.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    store.Add(items[i]);
                    selectionStore.Add(items[i].CreateSelection());
                }
                return true;
            }
            return false;
        }

        public bool TryDragActiveSelection(int x, int y)
        {
            if(selectionStore.ActiveSelection is null) { return false; }
            return selectionStore.ActiveSelection.TryDragTo(x, y);
        }
    }
}
