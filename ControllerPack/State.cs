using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using VectorGraphicsEditor.ControllerPack;
using VectorGraphicsEditor.ItemStuff;
using VectorGraphicsEditor.Model;

namespace VectorGraphicsEditor.Controller
{
    internal abstract class State
    {
        internal EventHandler eventHandler;
        public State(EventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        abstract public void MouseMove(int x, int y);
        abstract public void LeftMouseUp(int x, int y);
        abstract public void LeftMouseDown(int x, int y);
        abstract public void Delete();
        virtual public void Escape()
        {
            eventHandler.model.selectionController.SkipSelections();
            eventHandler.model.Repaint();
            eventHandler.ActivateState(StateType.EmptyState);
        }
        abstract public void CtrlMouseUp(int x, int y);
        abstract public void Group();
        abstract public void UnGroup();
        abstract public StateType stateType { get; }
    }
    public enum StateType
    {
        CreateState,
        DragState,
        SingleSelect,
        MultiSelect,
        EmptyState
    }
    internal class CreateState : State
    {
        public CreateState(EventHandler eventHandler) : base(eventHandler)
        {
        }

        public override StateType stateType { get { return StateType.CreateState; } }

        public override void CtrlMouseUp(int x, int y)
        {
            
        }

        public override void Delete()
        {
            
        }

        public override void Escape()
        {
            
        }

        public override void Group()
        {
            
        }

        public override void LeftMouseDown(int x, int y)
        {
            ((Model.Model)eventHandler.model).CreateAndGrabItem(x, y);
            List<Item> items = new List<Item>();
            items.Add(eventHandler.model.GetLastCreatedItem());
            eventHandler.model.UndoRedoController.AddAction(ActionType.Create, items);
            eventHandler.ActivateState(StateType.DragState);
            return;
        }

        public override void LeftMouseUp(int x, int y)
        {
        }

        public override void MouseMove(int x, int y)
        {
        }

        public override void UnGroup()
        {
           
        }
    }
    internal class DragState : State
    {
        public DragState(EventHandler eventHandler) : base(eventHandler)
        {
        }

        public override StateType stateType { get { return StateType.DragState; } }

        public override void CtrlMouseUp(int x, int y)
        {
            
        }

        public override void Delete()
        {
            
        }

        public override void Escape()
        {
            
        }

        public override void Group()
        {
            
        }

        public override void LeftMouseDown(int x, int y)
        {
            var select = eventHandler.model.selectionController.selectionStore.TryGrab(x, y);
            if (select is null)
            {
                eventHandler.model.selectionController.SkipSelections();
                eventHandler.model.Repaint();
            }

        }

        public override void LeftMouseUp(int x, int y)
        {
            eventHandler.model.selectionController.ReleaseActiveSelection();
            eventHandler.ActivateState(StateType.SingleSelect);
            /*eventHandler.model.selectionController.TryDragActiveSelection(x, y);
            //((Model.Model)model).selectionController.selectionStore.ActiveSelection.TryDragTo(x, y);
            eventHandler.model.Repaint();*/
        }

        public override void MouseMove(int x, int y)
        {
            if(!eventHandler.model.selectionController.TryDragActiveSelection(x, y)) { return; }
            
            //((Model.Model)model).selectionController.selectionStore.ActiveSelection.TryDragTo(x, y);
            eventHandler.model.Repaint();
        }

        public override void UnGroup()
        {
            
        }
    }
    internal class SingleSelect : State
    {
        public SingleSelect(EventHandler eventHandler) : base(eventHandler)
        {
        }

        public override StateType stateType => StateType.SingleSelect;

        public override void CtrlMouseUp(int x, int y)
        {
            if (eventHandler.model.selectionController.TryGrab(x, y, true))
            {
                eventHandler.ActivateState(StateType.MultiSelect);
            }
            eventHandler.model.Repaint();
        }

        public override void Delete()
        {
            eventHandler.model.UndoRedoController.AddAction(ActionType.Delete,eventHandler.model.selectionController.DeleteSelections());
            Escape();
        }

        /*public override void Escape()
        {
            eventHandler.model.selectionController.SkipSelections();
            eventHandler.model.Repaint();
            eventHandler.ActivateState(StateType.EmptyState);
        }*/

        public override void Group()
        {
            //eventHandler.model.selectionController.Group();
        }

        public override void LeftMouseDown(int x, int y)
        {
            var select = eventHandler.model.selectionController.selectionStore.TryGrab(x, y);
            if(select != null)
            {
                eventHandler.model.UndoRedoController.AddAction(ActionType.Change, eventHandler.model.selectionController.GetSelected());
                
                eventHandler.ActivateState(StateType.DragState);
            }
            else if(eventHandler.model.selectionController.TryGrab(x, y, false))
            {
                eventHandler.model.Repaint();
            }
            else
            {
                eventHandler.model.selectionController.SkipSelections();
                eventHandler.model.Repaint();
                eventHandler.ActivateState(StateType.EmptyState);
            }
        }

        public override void LeftMouseUp(int x, int y)
        {
            
        }

        public override void MouseMove(int x, int y)
        {
            
        }

        public override void UnGroup()
        {
            eventHandler.model.UndoRedoController.AddAction(ActionType.Ungroup, eventHandler.model.selectionController.GetSelected());
            eventHandler.model.selectionController.UnGroup();
            
            eventHandler.ActivateState(StateType.MultiSelect);
            eventHandler.model.Repaint();
        }
    }
    internal class MultiSelect : State
    {
        public MultiSelect(EventHandler eventHandler) : base(eventHandler)
        {
        }

        public override StateType stateType => StateType.MultiSelect;

        public override void CtrlMouseUp(int x, int y)
        {
            eventHandler.model.selectionController.TryGrab(x, y, true);
            eventHandler.model.Repaint();
        }

        public override void Delete()
        {
            eventHandler.model.UndoRedoController.AddAction(ActionType.Delete, eventHandler.model.selectionController.DeleteSelections());
            Escape();
        }

        /*public override void Escape()
        {
            eventHandler.model.selectionController.SkipSelections();
            eventHandler.model.Repaint();
            eventHandler.ActivateState(StateType.EmptyState);
        }*/

        public override void Group()
        {
            eventHandler.model.selectionController.Group();
            eventHandler.model.UndoRedoController.AddAction(ActionType.Group, eventHandler.model.selectionController.GetSelected());
            eventHandler.ActivateState(StateType.SingleSelect);
            eventHandler.model.Repaint();
        }

        public override void LeftMouseDown(int x, int y)
        {
            var select = eventHandler.model.selectionController.selectionStore.TryGrab(x, y);
            if (select != null)
            {
                eventHandler.model.selectionController.TryGrab(x, y, false);
                eventHandler.ActivateState(StateType.DragState);
                eventHandler.model.Repaint();
            }
            else
            {
                Escape();
            }

        }

        public override void LeftMouseUp(int x, int y)
        {
            
        }

        public override void MouseMove(int x, int y)
        {
            
        }

        public override void UnGroup()
        {
            
        }
    }
    internal class EmptyState : State
    {
        public EmptyState(EventHandler eventHandler) : base(eventHandler)
        {
        }

        public override StateType stateType => StateType.EmptyState;

        public override void CtrlMouseUp(int x, int y)
        {
            
        }

        public override void Delete()
        {
            
        }

        public override void Escape()
        {
            
        }

        public override void Group()
        {
            
        }

        public override void LeftMouseDown(int x, int y)
        {
            if(eventHandler.model.selectionController.TryGrab(x, y, false))
            {
                eventHandler.ActivateState(StateType.SingleSelect);
                eventHandler.model.Repaint();
            }
        }

        public override void LeftMouseUp(int x, int y)
        {
            
        }

        public override void MouseMove(int x, int y)
        {
            
        }

        public override void UnGroup()
        {
            
        }
    }
    internal class StateStore: List<State>
    {

        public StateStore(EventHandler eventHandler)
        {
            Add(new CreateState(eventHandler));
            Add(new DragState(eventHandler));
            Add(new SingleSelect(eventHandler));
            Add(new MultiSelect(eventHandler));
            Add(new EmptyState(eventHandler));
        }
        public State this[StateType state] { get { return this.First(x => x.stateType == state); } }
        void MouseMove(int x, int y) { }
        void LeftMouseDown(int x, int y) { }
    }
}
