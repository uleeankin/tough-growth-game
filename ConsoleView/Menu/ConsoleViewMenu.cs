using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;

namespace ConsoleView.Menu
{
    public class ConsoleViewMenu : ViewMenu
    {

        public int WIDTH = 120;
        public int HEIGHT = 30;

        public ConsoleViewMenu(Model.Menu.Menu parMenu) : base(parMenu)
        {
            Init();
            Draw();
        }

        public override void Draw()
        {
            Console.Clear();
            foreach (ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

        protected override ViewMenuItem CreateItem(MenuItem parMenuItem)
        {
            return new ConsoleViewMenuItem(parMenuItem);
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

            ViewMenuItem[] menu = Menu;
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
