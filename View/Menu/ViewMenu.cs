using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace View.Menu
{
    /// <summary>
    /// Базовое представление главного меню
    /// </summary>
    public abstract class ViewMenu : View
    {
        /// <summary>
        /// Модель главного меню
        /// </summary>
        private Model.Menu.MenuScreen _menuScreen = null;

        /// <summary>
        /// Представления кнопок
        /// </summary>
        private Dictionary<int, ViewControlItem> _menu = null;

        /// <summary>
        /// Представления текстовых полей (заголовка игры)
        /// </summary>
        private List<ViewPassiveItem> _title = null;

        /// <summary>
        /// Представления кнопок
        /// </summary>
        protected ViewControlItem[] Menu => _menu.Values.ToArray();

        /// <summary>
        /// Представления текстовых полей (заголовка игры)
        /// </summary>
        protected ViewPassiveItem[] Title => _title.ToArray();

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
                return _menu[parId];
            }
        }

        /// <summary>
        /// Конструктор представления главного меню
        /// </summary>
        /// <param name="parMenu">Модель главного меню</param>
        public ViewMenu(Model.Menu.MenuScreen parMenu)
        {
            _menuScreen = parMenu;
            _menu = new Dictionary<int, ViewControlItem>();
            _title = new List<ViewPassiveItem>();

            foreach (Model.Items.PassiveItem elMenuTitle in parMenu.PassiveItems)
            {
                _title.Add(CreatePassiveItem(elMenuTitle));
            }

            foreach (Model.Items.ControlItem elMenuItem in parMenu.ControlItems)
            {
                _menu.Add(elMenuItem.ID, CreateControlItem(elMenuItem));
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
