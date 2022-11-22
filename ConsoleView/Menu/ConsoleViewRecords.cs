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
        public ConsoleViewRecords(Model.Menu.Records parRecords) : base(parRecords)
        {
            Init();
            Draw();
        }

        public override void Draw()
        {
            Console.Clear();

            foreach (ViewPassiveItem elViewPassiveItem in Records)
            {
                elViewPassiveItem.Draw();
            }

            foreach (ViewControlItem elViewControlItem in BackToMenu)
            {
                elViewControlItem.Draw();
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
            
        }

        private void Init()
        {
            Console.WindowHeight = BUTTON_HEIGHT;
            Console.WindowWidth = BUTTON_WIDTH;

            Console.CursorVisible = false;

            ViewControlItem[] button = BackToMenu;
            Height = button.Length;
            Width = button.Max(x => x.Width);

            X = Console.WindowWidth / 2;
            Y = Console.WindowHeight - Width - Width / 2;

            int y = Y;

            for (int i = 0; i < button.Length; i++)
            {
                button[i].X = X;
                button[i].Y = y + (3 * i);
                y++;
            }
        }
    }
}
