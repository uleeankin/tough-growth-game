using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;
using Model.Items;

namespace Model.Menu
{
    /// <summary>
    /// Базовое окно
    /// </summary>
    public class MenuScreen : Screen
    {
        /// <summary>
        /// Текущая кнопка в фокусе
        /// </summary>
        private int _focusedItemIndex = -1;

        /// <summary>
        /// Кнопки
        /// </summary>
        private Dictionary<int, ControlItem> _controlItem = new Dictionary<int, ControlItem>();

        /// <summary>
        /// Текстовые поля
        /// </summary>
        private List<PassiveItem> _passiveItems = new List<PassiveItem>();

        /// <summary>
        /// Поля ввода
        /// </summary>
        private List<InputItem> _inputItems = new List<InputItem>();

        /// <summary>
        /// Текущая кнопка в фокусе
        /// </summary>
        public int FocusedItemIndex
        {
            get { return _focusedItemIndex; }
            protected set { _focusedItemIndex = value; }
        }

        /// <summary>
        /// Кнопки
        /// </summary>
        public ControlItem[] ControlItems
        {
            get
            {
                return _controlItem.Values.ToArray();
            }
        }

        /// <summary>
        /// Кнопка по коду её назначение
        /// </summary>
        /// <param name="parId">Код назначение</param>
        /// <returns>Кнопка с заданным кодом</returns>
        public ControlItem this[int parId]
        {
            get
            {
                return _controlItem[parId];
            }
        }

        /// <summary>
        /// Текстовые поля
        /// </summary>
        public PassiveItem[] PassiveItems
        {
            get
            {
                return _passiveItems.ToArray();
            }
        }

        /// <summary>
        /// Поля ввода
        /// </summary>
        public InputItem[] InputItems
        {
            get
            {
                return _inputItems.ToArray();
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public MenuScreen()
        {

        }

        /// <summary>
        /// Фокусирует кнопку с кодом больше текущей
        /// </summary>
        public void FocusNext()
        {
            int currentFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == ControlItems.Length - 1)
            {
                _focusedItemIndex = 0;
            }
            else
            {
                _focusedItemIndex++;
            }

            ControlItems[_focusedItemIndex].State = States.Focused;
            ControlItems[currentFocusedIndex].State = States.Normal;
        }

        /// <summary>
        /// Фокусирует кнопку с кодом меньше текущей
        /// </summary>
        public void FocusPrevious()
        {
            int currentFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == 0)
            {
                _focusedItemIndex = ControlItems.Length - 1;
            }
            else
            {
                _focusedItemIndex--;
            }

            ControlItems[_focusedItemIndex].State = States.Focused;
            ControlItems[currentFocusedIndex].State = States.Normal;
        }

        /// <summary>
        /// Фокусирует кнопку по коду
        /// </summary>
        /// <param name="parId">Код</param>
        public void FocusItemById(int parId)
        {
            int currentFocusedIndex = _focusedItemIndex;
            ControlItem menuItem = this[parId];
            _focusedItemIndex = new List<ControlItem>(ControlItems).IndexOf(menuItem);

            if (currentFocusedIndex != -1)
            {
                ControlItems[currentFocusedIndex].State = States.Normal;
            }
              
            ControlItems[_focusedItemIndex].State = States.Focused;
        }

        /// <summary>
        /// Выбирает кнопку, находящуюся в фокусе
        /// </summary>
        public void SelectFocusedItem()
        {
            ControlItems[_focusedItemIndex].State = States.Selected;
        }

        /// <summary>
        /// Добавляет кнопку
        /// </summary>
        /// <param name="parControlItem">Кнопка</param>
        protected void AddControlItem(ControlItem parControlItem)
        {
            _controlItem.Add(parControlItem.ID, parControlItem);
        }

        /// <summary>
        /// Добавляет текстовое поле
        /// </summary>
        /// <param name="parPassiveItem">Текстовое поле</param>
        protected void AddPassiveItem(PassiveItem parPassiveItem)
        {
            _passiveItems.Add(parPassiveItem);
        }

        /// <summary>
        /// Добавляет поле ввода
        /// </summary>
        /// <param name="parInputItem">Поле ввода</param>
        protected void AddInputItem(InputItem parInputItem)
        {
            _inputItems.Add(parInputItem);
        }

        /// <summary>
        /// Удаляет текстовые поля
        /// </summary>
        protected void DeletePassiveItems()
        {
            _passiveItems.Clear();
        }
    }
}
