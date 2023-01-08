using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;

namespace VectorGraphicsEditor.ControllerPack
{
    interface IUndoRedoController
    {
        void AddAction(ActionType actionType, List<Item> items);
        List<Item> Undo();
        List<Item> Redo();
    }
    public enum ActionType
    {
        Create,
        Delete,
        Group,
        Ungroup,
        Change
    }
    internal class UndoRedoController : IUndoRedoController
    {
        List<Action> UndoList = new List<Action>();
        List<Action> RedoList = new List<Action>();
        Store store;
        public UndoRedoController(Store store)
        {
            this.store = store;
        }

        public void AddAction(ActionType actionType, List<Item> items)
        {
            RedoList.Clear();
            Action action = CreateAction(actionType, items);
            UndoList.Add(action);
        }

        public List<Item> Redo()
        {
            if(RedoList.Count == 0) { return null; }
            Action action = RedoList[RedoList.Count - 1];
            RedoList.RemoveAt(RedoList.Count - 1);
            List<Item> changedItem = action.Redo();
            UndoList.Add(action);
            return changedItem;
        }

        public List<Item> Undo()
        {
            if(UndoList.Count == 0) { return null ; }
            Action action = UndoList[UndoList.Count - 1];
            UndoList.RemoveAt(UndoList.Count - 1);
            List<Item> changedItem = action.Undo();
            RedoList.Add(action);
            return changedItem;
        }
        private Action CreateAction(ActionType action, List<Item> items)
        {
            switch (action)
            {
                case ActionType.Create:
                    return new ActionCreate(store, items);
                case ActionType.Delete:
                    return new ActionDelete(store, items);
                case ActionType.Group:
                    return new ActionGroup(store, items);
                case ActionType.Ungroup:
                    return new ActionUngroup(store, items);
                case ActionType.Change:
                    return new ActionChange(store, items);
            }
            return null;
        }
    }
    internal abstract class Action 
    {
        protected List<Item> items;
        protected Store store;
        public Action(Store store, List<Item> items)
        {
            this.store = store;
            this.items = items;
        }
        public abstract List<Item> Undo();
        public abstract List<Item> Redo();
    }
    internal class ActionCreate : Action
    {
        public ActionCreate(Store store, List<Item> items) : base(store, items)
        {
        }

        public override List<Item> Redo()
        {
            store.AddRange(items);
            return items;
        }

        public override List<Item> Undo()
        {
            for (int i = 0; i < items.Count; i++)
            {
                store.Remove(items[i]);
            }
            return null;
        }
    }
    internal class ActionDelete: Action
    {
        public ActionDelete(Store store, List<Item> items) : base(store, items)
        {
        }
        public override List<Item> Redo()
        {
            for (int i = 0; i < items.Count; i++)
            {
                store.Remove(items[i]);
            }
            return null;
        }

        public override List<Item> Undo()
        {
            store.AddRange(items);
            return items;
        }
    }
    internal class ActionGroup: Action
    {
        public ActionGroup(Store store, List<Item> items) : base(store, items)
        {
            if(items.Count>1 || ! (items[0] is Group)) { throw new Exception("items must contain only group"); }
        }
        public override List<Item> Redo()
        {
            var itemsInGroup = ((Group)items[0]).Destroy();
            for (int i = 0; i < itemsInGroup.Count; i++)
            {
                store.Remove(itemsInGroup[i]);
            }
            store.Add(items[0]);
            return items;
        }

        public override List<Item> Undo()
        {
            store.Remove(items[0]);
            var itemsInGroup = ((Group)items[0]).Destroy();
            store.AddRange(itemsInGroup);
            return itemsInGroup;
        }
    }
    internal class ActionUngroup : Action
    {
        Item group;
        public ActionUngroup(Store store, List<Item> items) : base(store, items)
        {
            group = items[0];
            this.items = ((Group)group).Destroy();
        }
        public override List<Item> Redo()
        {
            store.Remove(group);
            ;
            store.AddRange(items);
            return items;
        }

        public override List<Item> Undo()
        {
            
            for (int i = 0; i < items.Count; i++)
            {
                store.Remove(items[i]);
            }
            store.Add(group);
            List<Item> groupList = new List<Item>();
            groupList.Add(group);
            return groupList;
        }
    }
    internal class ActionChange : Action
    {
        List<Item> original = new List<Item>();
        public ActionChange(Store store, List<Item> items) : base(store, items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                original.Add(items[i].Copy());
            }
        }

        public override List<Item> Redo()
        {
            return Undo();
        }

        public override List<Item> Undo()
        {
            for (int i = 0; i < items.Count; i++)
            {
                var it = items[i].Copy();
                items[i].Frame = original[i].Frame;
                if (items[i] is Group)
                {
                    ((Group)items[i]).ChangeItems();
                }
                original[i] = it;
            }
            return items;
        }
    }
}
