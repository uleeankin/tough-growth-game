using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Items;

namespace View.Items
{
    /// <summary>
    /// Представление элемента управления (кнопки)
    /// </summary>
    public abstract class ViewControlItem : View
    {
        /// <summary>
        /// Элемент управления (кнопка)
        /// </summary>
        private ControlItem _item = null;

        /// <summary>
        /// Элемент управления (кнопка)
        /// </summary>
        public ControlItem Item
        {
            get
            {
                return _item;
            }
        }

        /// <summary>
        /// Координата X кнопки
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y кнопки
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина кнопки
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Высота кнопки
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Конструктор представления кнопки
        /// </summary>
        /// <param name="parItem">Объект кнопки</param>
        public ViewControlItem(ControlItem parItem)
        {
            _item = parItem;
            _item.RedrawItem += RedrawItem;
        }

        /// <summary>
        /// Базовый обработчик события перерисовки кнопки
        /// </summary>
        protected abstract void RedrawItem();
    }
}
