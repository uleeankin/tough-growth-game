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
    /// <summary>
    /// Окно окончания игры
    /// </summary>
    public class EndGameScreen : MenuScreen
    {
        /// <summary>
        /// Число игроков (увеличивается, если игрок не задал имя)
        /// </summary>
        private int _playersNumber = 0;

        /// <summary>
        /// Имя игрока
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// Количество смертей игрока
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
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

        /// <summary>
        /// Удаляет последний символ строки имени
        /// </summary>
        public void RemoveLastSymbol()
        {
            this.InputItems[0].ChangeText(this.InputItems[0].Text.Remove(this.InputItems[0].Text.Length - 1));
        }

        /// <summary>
        /// Добавляет символ в строку имени
        /// </summary>
        /// <param name="parLetterCode"></param>
        public void AddSymbol(int parLetterCode)
        {
            this.InputItems[0].ChangeText(this.InputItems[0].Text += (char)parLetterCode);
        }

        /// <summary>
        /// Сохраняет рекорд в файл
        /// </summary>
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
