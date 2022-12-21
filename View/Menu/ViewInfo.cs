using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace View.Menu
{
    /// <summary>
    /// Базовое представление справки
    /// </summary>
    public abstract class ViewInfo : View
    {
        /// <summary>
        /// Модель справки
        /// </summary>
        private Model.Menu.MenuScreen _info = null;

        /// <summary>
        /// Представления кнопок
        /// </summary>
        private Dictionary<int, ViewControlItem> _backToMenu = null;

        /// <summary>
        /// Представления правил
        /// </summary>
        private List<ViewPassiveItem> _rules = null;

        /// <summary>
        /// Представления кнопок
        /// </summary>
        protected ViewControlItem[] BackToMenu => _backToMenu.Values.ToArray();

        /// <summary>
        /// Представления правил
        /// </summary>
        protected ViewPassiveItem[] Rules => _rules.ToArray();

        /// <summary>
        /// Координата X окна
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y окна
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина окна
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Высота окна
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
        /// Конструктор представления справки
        /// </summary>
        /// <param name="parInfo">Объект справки</param>
        public ViewInfo(Model.Menu.MenuScreen parInfo)
        {
            _info = parInfo;
            _backToMenu = new Dictionary<int, ViewControlItem>();
            _rules = new List<ViewPassiveItem>();

            foreach (Model.Items.PassiveItem elMenuTitle in parInfo.PassiveItems)
            {
                _rules.Add(CreatePassiveItem(elMenuTitle));
            }

            foreach (Model.Items.ControlItem elMenuItem in parInfo.ControlItems)
            {
                _backToMenu.Add(elMenuItem.ID, CreateControlItem(elMenuItem));
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

    }
}
