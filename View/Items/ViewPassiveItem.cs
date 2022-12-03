using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Items;

namespace View.Items
{
    public abstract class ViewPassiveItem : View
    {

        private PassiveItem _item = null;

        protected PassiveItem Item
        {
            get
            {
                return this._item;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewPassiveItem(PassiveItem parPassiveItem)
        {
            _item = parPassiveItem;
        }
    }
}
