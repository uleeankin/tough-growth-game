﻿using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Items
{
    public abstract class ViewInputItem : View
    {
        private InputItem _item = null;

        public InputItem Item
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

        public ViewInputItem(InputItem parItem)
        {
            _item = parItem;
            _item.RedrawItem += RedrawItem;
        }

        protected abstract void RedrawItem();
    }
}
