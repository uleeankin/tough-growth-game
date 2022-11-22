using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Items
{
    public class PassiveItem
    {
        public string Text { get; private set; }

        public PassiveItem(string parText)
        {
            Text = parText;
        }
    }
}
