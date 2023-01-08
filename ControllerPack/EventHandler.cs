using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorGraphicsEditor.ItemStuff;

namespace VectorGraphicsEditor.Controller
{
    internal class EventHandler : IEventHandler
    {
        public IModel model;
        State state;
        StateStore stateStore;
        public EventHandler(IModel model)
        {
            this.model = model;
            stateStore = new StateStore(this);
        }
        public void LeftMouseDown(int x, int y)
        {
            state?.LeftMouseDown(x, y);
        }
        public void LeftMouseUp(int x, int y)
        {
            state?.LeftMouseUp(x, y);
        }
        public void LeftMouseMove(int x, int y)
        {
            state?.MouseMove(x, y);
        }
        public void Delete()
        {
            state?.Delete();    
        }
        public void Escape()
        {
            state?.Escape();
        }
        public void CtrlMouseUp(int x, int y)
        {
            state?.CtrlMouseUp(x, y);
        }
        public void Group()
        {
            state?.Group();
        }
        public void UnGroup()
        {
            state?.UnGroup();
        }
        public void Undo()
        {
            Escape();
            List<Item> changedItems = model.UndoRedoController.Undo();
            GrabList(changedItems);
            model.Repaint();
        }
        public void Redo()
        {
            Escape();
            List<Item> changedItems = model.UndoRedoController.Redo();
            GrabList(changedItems);
            model.Repaint();
        }
        public void GrabList(List<Item> items)
        {
            if(items is null || items.Count == 0) { return; }
            else if (items.Count == 1)
            {
                ActivateState(StateType.SingleSelect);
            }
            else 
            {
                ActivateState(StateType.MultiSelect);
            }
            model.selectionController.GrabList(items);
            
        }

        public void ActivateState(StateType stateType)
        {
            state = stateStore[stateType];
        }
    }
}
