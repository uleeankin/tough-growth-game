using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using View.Items;
using ConsoleView.Items;

namespace ConsoleView.Menu
{
    public class ConsoleViewRecords : ViewRecords
    {
        public int BUTTON_WIDTH = 120;
        public int BUTTON_HEIGHT = 30;

        //изменить в базовом классе на MenuScreen
        public ConsoleViewRecords(Model.Menu.MenuScreen parRecords) : base(parRecords)
        {
            Init();
        }

        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            /*foreach (ViewPassiveItem elViewPassiveItem in Records)
            {
                elViewPassiveItem.Draw();
            }*/

            BackToMenu[0].Draw();
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
            
        }

        private void Init()
        {
            Console.WindowHeight = BUTTON_HEIGHT;
            Console.WindowWidth = BUTTON_WIDTH;

            Console.CursorVisible = false;

            //Init button
            ViewControlItem[] button = BackToMenu;
            Height = button.Length;
            Width = button.Max(x => x.Width);

            button[0].X = Console.WindowWidth / 2;
            button[0].Y = Console.WindowHeight - Height * 4;
        }
    }
}
