using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Items
{
    /// <summary>
    /// Элемент управление (кнопка)
    /// </summary>
    public class ControlItem : Item
    {
        /// <summary>
        /// Делегат на нажатие
        /// </summary>
        public delegate void dSelected();
        /// <summary>
        /// Делегат на перерисовку
        /// </summary>
        public delegate void dRedrawItem();

        /// <summary>
        /// Событие на нажатие
        /// </summary>
        public event dSelected Selected = null;
        /// <summary>
        /// Событие на перерисовку
        /// </summary>
        public event dRedrawItem RedrawItem = null;
       
        /// <summary>
        /// Состояние кнопки
        /// </summary>
        private States _state = States.Normal;

        /// <summary>
        /// Состояние кнопки
        /// </summary>
        public States State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                if (_state == States.Selected)
                {
                    _state = States.Focused;
                    Selected?.Invoke();
                } 
                else
                {
                    RedrawItem?.Invoke();
                }
            }
        }

        /// <summary>
        /// Тип окна для перехода
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parId">Тип окна для перехода</param>
        /// <param name="parName">Текст кнопки</param>
        public ControlItem(int parId, string parName) : base(parName)
        {
            ID = parId;
            State = States.Normal;
        }
    }
}
