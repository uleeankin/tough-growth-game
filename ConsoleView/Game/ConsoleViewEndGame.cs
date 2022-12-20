using ConsoleView.Items;
using Model.Game;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;
using View.Items;

namespace ConsoleView.Game
{
    public class ConsoleViewEndGame : ViewEndGame
    {

        public int WIDTH = 120;
        public int HEIGHT = 30;

        public int BUTTON_WIDTH = 120;
        public int BUTTON_HEIGHT = 30;

        public ConsoleViewEndGame(EndGameScreen parEndGameScreen) : base(parEndGameScreen)
        {
            Init();
        }

        public override void Draw()
        {
            Info[1].Item.Text += EndScreen.Score.ToString();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                elPassiveItem.Draw();
            }
            foreach (ViewControlItem elViewControlItem in BackToMenu)
            {
                elViewControlItem.Draw();
            }

            foreach (ViewInputItem elInputItem in Input)
            {
                elInputItem.Draw();
            }
        }

        private void Init()
        {
            int y = 2;
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                elPassiveItem.Y = y;
                elPassiveItem.X = WIDTH / 2
                    - elPassiveItem.Item.Text.Length / 2;
                y += 2;
            }

            foreach (ViewInputItem elInputItem in Input)
            {
                elInputItem.X = WIDTH / 2 - elInputItem.Width / 2;
                elInputItem.Y = HEIGHT / 2;
            }

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

        protected override ViewControlItem CreateControlItem(ControlItem parControlItem)
        {
            return new ConsoleViewControlItem(parControlItem);
        }

        protected override ViewInputItem CreateInputItem(InputItem parInputItem)
        {
            return new ConsoleViewInputItem(parInputItem);
        }

        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parPassiveItem)
        {
            return new ConsoleViewPassiveItem(parPassiveItem);
        }

        protected override void Redraw()
        {
            
        }
    }
}
