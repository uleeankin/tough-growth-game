using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Items
{
    public class InputItem : Item
    {
        public delegate void dRedrawItem();
        public event dRedrawItem RedrawItem = null;

        public InputItem() : base("")
        {

        }
    }
}
