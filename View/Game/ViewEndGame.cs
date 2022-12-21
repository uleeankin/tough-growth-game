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

        /// <summary>
        /// Модель окна окончания игры
        /// </summary>
        protected Model.Game.EndGameScreen EndScreen { get; set; }

        /// <summary>
        /// Координата X на представлении
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Координата Y на представлении
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Ширина окна на представлении
        /// </summary>
        public int Width { get; protected set; }
        /// <summary>
        /// Высота окна на предствлении
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Представление кнопки по заданному коду
        /// </summary>
        /// <param name="parId">Код кнопки</param>
        /// <returns></returns>
        public ViewControlItem this[int parId]
        {
            get
            {
                return _backToMenu[parId];
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parEndGame">Модель окна окончания игры</param>
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

        /// <summary>
        /// Абстрактный обработчик события перерисовки окна
        /// </summary>
        protected abstract void Redraw();

        /// <summary>
        /// Создает представление кнопки
        /// </summary>
        /// <param name="parControlItem">Кнопка</param>
        /// <returns>Представление кнопки</returns>
        protected abstract ViewControlItem CreateControlItem(Model.Items.ControlItem parControlItem);

        /// <summary>
        /// Создает представление текстового поля
        /// </summary>
        /// <param name="parPassiveItem">Текстовое поле</param>
        /// <returns>Представление текстового поля</returns>
        protected abstract ViewPassiveItem CreatePassiveItem(Model.Items.PassiveItem parPassiveItem);

        /// <summary>
        /// Создает представление поля ввода
        /// </summary>
        /// <param name="parInputItem">Поле ввода</param>
        /// <returns>Представление поля ввода</returns>
        protected abstract ViewInputItem CreateInputItem(Model.Items.InputItem parInputItem);
    }
}
