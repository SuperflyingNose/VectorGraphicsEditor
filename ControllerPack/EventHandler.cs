using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ActivateState(StateType stateType)
        {
            state = stateStore[stateType];
        }
    }
}
