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

        public ConsoleViewEndGame(EndGameScreen parEndGameScreen) : base(parEndGameScreen)
        {

        }

        public override void Draw()
        {
            Info[1].Item.Text += EndScreen.Score.ToString();
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
