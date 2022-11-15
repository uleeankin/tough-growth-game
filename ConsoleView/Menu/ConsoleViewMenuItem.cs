using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView.Menu
{
    public class ConsoleViewMenuItem : View.Menu.ViewMenuItem
    {
        public const int HEIGHT = 3;
        public const int WIDTH = 20;

        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public ConsoleViewMenuItem(Model.Menu.MenuItem parMenuItem) : base(parMenuItem)
        {
            Height = HEIGHT;
            Width = WIDTH;
        } 

        public override void Draw()
        {
            _output.OutputButton(Item.Name,
                X - Item.Name.Length / 2,
                Y, Item.State);
            
        }

        protected override void RedrawItem()
        {
            Draw();
        }
    }
}
