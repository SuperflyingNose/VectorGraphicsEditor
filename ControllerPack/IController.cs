using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor.Controller
{
    internal interface IController
    {
        IEventHandler eventHandler { get; }
        void SetItemCreationRegime(ItemType itemType);
        IModel model { get; set; }
    }
}
