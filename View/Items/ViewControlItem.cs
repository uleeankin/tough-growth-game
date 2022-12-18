using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Items;

namespace View.Items
{
    public abstract class ViewControlItem : View
    {
        private ControlItem _item = null;

        public ControlItem Item
        {
            get
            {
                return _item;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewControlItem(ControlItem parItem)
        {
            _item = parItem;
            _item.RedrawItem += RedrawItem;
        }

        protected abstract void RedrawItem();
    }
}
