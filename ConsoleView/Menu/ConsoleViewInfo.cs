using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using View.Items;
using Model.Items;
using ConsoleView.Items;
using Model.Menu;

namespace ConsoleView.Menu
{
    public class ConsoleViewInfo : ViewInfo
    {
        public int WIDTH = 120;
        public int HEIGHT = 30;

        public ConsoleViewInfo(MenuScreen parInfo) : base(parInfo)
        {
            Init();
        }

        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (ViewPassiveItem elViewPassiveItem in Rules)
            {
                elViewPassiveItem.Draw();
            }
            BackToMenu[0].Draw();
        }

        protected override ViewControlItem CreateControlItem(ControlItem parControlItem)
        {
            return new ConsoleViewControlItem(parControlItem);
        }

        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parPassiveItem)
        {
            return new ConsoleViewPassiveItem(parPassiveItem);
        }

        protected override void Redraw()
        {
            
        }

        private void Init()
        {
            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;

            Console.CursorVisible = false;

            //Init rules
            X = 0;
            Y = 4;
            int y = Y;
            foreach(ViewPassiveItem elViewPassiveItem in Rules)
            {
                elViewPassiveItem.X = X;
                elViewPassiveItem.Y = y;
                y = Console.CursorTop + 1;
            } 

            //Init button
            ViewControlItem[] button = BackToMenu;
            Height = button.Length;
            Width = button.Max(x => x.Width);

            button[0].X = Console.WindowWidth / 2;
            button[0].Y = Console.WindowHeight - Height * 4;
            
        }
    }
}
