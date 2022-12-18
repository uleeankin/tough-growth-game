using Model.Enums;
using Model.Items;
using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game
{
    public class EndGameScreen : MenuScreen
    {

        public int Score { get; set; }

        public EndGameScreen() : base()
        {
            this.AddPassiveItem(new PassiveItem(Properties.Resources.EndGame));
            this.AddPassiveItem(new PassiveItem(Properties.Resources.Score));
            this.AddPassiveItem(new PassiveItem(Properties.Resources.InputPhrase));
            this.AddInputItem(new InputItem());
            this.AddControlItem(new ControlItem((int)ControlItemCode.MainMenu,
                            Properties.Resources.MainMenuControlItem));
            this.FocusItemById((int)ControlItemCode.MainMenu);
        }



    }
}
