using Model.Enums;
using Model.Items;
using Model.Menu;
using Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game
{
    public class EndGameScreen : MenuScreen
    {

        private int _playersNumber = 0;

        public string PlayerName { get; set; }
        public int Score { get; set; }

        public EndGameScreen() : base()
        {
            PlayerName = "";
            this.AddPassiveItem(new PassiveItem(Properties.Resources.EndGame));
            this.AddPassiveItem(new PassiveItem(Properties.Resources.Score));
            this.AddPassiveItem(new PassiveItem(Properties.Resources.InputPhrase));
            this.AddInputItem(new InputItem());
            this.AddControlItem(new ControlItem((int)ControlItemCode.MainMenu,
                            Properties.Resources.MainMenuControlItem));
            this.FocusItemById((int)ControlItemCode.MainMenu);
        }

        public void RemoveLastSymbol()
        {
            this.InputItems[0].ChangeText(this.InputItems[0].Text.Remove(this.InputItems[0].Text.Length - 1));
        }

        public void AddSymbol(int parLetterCode)
        {
            this.InputItems[0].ChangeText(this.InputItems[0].Text += (char)parLetterCode);
        }

        public void SaveRecord()
        {
            _playersNumber++;
            if (this.InputItems[0].Text.Length == 0)
            {
                PlayerName = $"Player{_playersNumber}";
            } else
            {
                PlayerName = this.InputItems[0].Text;
            }

            string record = $"{PlayerName} {Score}\n";
            FileIO.FileWriter(Properties.Resources.RecordsFileName, record);
        }

    }
}
