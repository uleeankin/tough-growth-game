using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;
using Model.Items;

namespace ConsoleView.Items
{
    public class ConsoleViewPassiveItem : ViewPassiveItem
    {

        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public ConsoleViewPassiveItem(PassiveItem parPassiveItem) : base(parPassiveItem)
        {
        }

        public override void Draw()
        {
            _output.OutputString(Item.Text, X, Y);
        }
    }
}
