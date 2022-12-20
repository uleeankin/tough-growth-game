using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace ConsoleView.Items
{
    public class ConsoleViewInputItem : ViewInputItem
    {
        private const int WIDTH = 20;

        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public ConsoleViewInputItem(InputItem parInputItem) : base(parInputItem)
        {
            Width = WIDTH;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
        }

        protected override void RedrawItem()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            _output.OutputString(new StringBuilder().Insert(0, " ", WIDTH).ToString(), X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            _output.OutputString(Item.Text, X, Y);
        }
    }
}
