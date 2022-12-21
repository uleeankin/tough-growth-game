using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace View.Game
{
    /// <summary>
    /// Базовое представление окна окончания игры
    /// </summary>
    public abstract class ViewEndGame : View
    {
        /// <summary>
        /// Представления кнопок
        /// </summary>
        private Dictionary<int, ViewControlItem> _backToMenu = null;
        /// <summary>
        /// Представления тестовых полей
        /// </summary>
        private List<ViewPassiveItem> _info = null;
        /// <summary>
        /// Представления полей ввода
        /// </summary>
        private List<ViewInputItem> _input = null;

        /// <summary>
        /// Представления кнопок
        /// </summary>
        protected ViewControlItem[] BackToMenu => _backToMenu.Values.ToArray();
        /// <summary>
        /// Представления текстовых полей
        /// </summary>
        protected ViewPassiveItem[] Info => _info.ToArray();
        /// <summary>
        /// Представления полей ввода
        /// </summary>
        protected ViewInputItem[] Input => _input.ToArray();
        protected Model.Game.EndGameScreen EndScreen { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewControlItem this[int parId]
        {
            get
            {
                return _backToMenu[parId];
            }
        }

        public ViewEndGame(Model.Game.EndGameScreen parEndGame)
        {
            EndScreen = parEndGame;
            _backToMenu = new Dictionary<int, ViewControlItem>();
            _info = new List<ViewPassiveItem>();
            _input = new List<ViewInputItem>();

            foreach (Model.Items.PassiveItem elPassiveItem in parEndGame.PassiveItems)
            {
                _info.Add(CreatePassiveItem(elPassiveItem));
            }

            foreach (Model.Items.ControlItem elControlItem in parEndGame.ControlItems)
            {
                _backToMenu.Add(elControlItem.ID, CreateControlItem(elControlItem));
            }

            foreach (Model.Items.InputItem elInputItem in parEndGame.InputItems)
            {
                _input.Add(CreateInputItem(elInputItem));
            }
        }

        protected abstract void Redraw();
        protected abstract ViewControlItem CreateControlItem(Model.Items.ControlItem parControlItem);
        protected abstract ViewPassiveItem CreatePassiveItem(Model.Items.PassiveItem parPassiveItem);
        protected abstract ViewInputItem CreateInputItem(Model.Items.InputItem parInputItem);
    }
}
