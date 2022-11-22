using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using View.Items;
using Model.Items;
using ConsoleView.Items;

namespace ConsoleView.Menu
{
    public class ConsoleViewMenu : ViewMenu
    {

        public int WIDTH = 120;
        public int HEIGHT = 30;

        private ConsoleView.Utils.CastomOutput _output = new Utils.CastomOutput();

        public ConsoleViewMenu(MenuScreen parMenu) : base(parMenu)
        {
            
        }

        public override void Draw()
        {
            Init();
            Console.Clear();
            _output.PrintGameTitle(WIDTH);
            foreach (ViewControlItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

        protected override ViewControlItem CreateControlItem(ControlItem parMenuItem)
        {
            return new ConsoleViewControlItem(parMenuItem);
        }

        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parMenuTitle)
        {
            return new ConsoleViewPassiveItem(parMenuTitle);
        }

        protected override void Redraw()
        {
            //this.Draw();
        }

        private void Init()
        {
            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;

            Console.SetBufferSize(WIDTH, HEIGHT);

            Console.CursorVisible = false;

            ViewControlItem[] menu = Menu;
            Height = menu.Length;
            Width = menu.Max(x => x.Width);

            X = Console.WindowWidth / 2;
            Y = Console.WindowHeight / 2 - Width / 4;

            int y = Y;

            for (int i = 0; i < menu.Length; i++)
            {
                menu[i].X = X;
                menu[i].Y = y + (3 * i);
                y++;
            }
        }
    }
}
