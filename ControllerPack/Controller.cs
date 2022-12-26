using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorGraphicsEditor.Controller
{
    internal class Controller : IController
    {
        public IEventHandler eventHandler { get; }

        public IModel model { get; set; }

        public Controller(IModel model)
        {
            this.model = model;
            eventHandler = new EventHandler(model);
        }

        public void SetItemCreationRegime(ItemType itemType)
        {
            model.CreatingItemType = itemType;
        }
    }
}
