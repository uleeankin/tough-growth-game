using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Items
{
    public abstract class Item
    {

        public string Text { get; set; }

        public Item(string parText)
        {
            Text = parText;
        }
    }
}
