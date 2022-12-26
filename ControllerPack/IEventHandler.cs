using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorGraphicsEditor.Controller
{
    internal interface IEventHandler
    {
        void LeftMouseDown(int x, int y);
        void LeftMouseUp(int x, int y);
        void LeftMouseMove(int x, int y);
        void Delete();
        void Escape();
        void CtrlMouseUp(int x, int y);
        void Group();
        void UnGroup();
        void ActivateState(StateType stateType);
    }
}
