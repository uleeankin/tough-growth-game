using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Items
{
    /// <summary>
    /// Представление элемента управления (поля ввода)
    /// </summary>
    public abstract class ViewInputItem : View
    {
        /// <summary>
        /// Поле ввода
        /// </summary>
        private InputItem _item = null;

        /// <summary>
        /// Поле ввода
        /// </summary>
        public InputItem Item
        {
            get
            {
                return _item;
            }
        }

        /// <summary>
        /// Координата X поля ввода
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y поля ввода
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина поля ввода
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Высота поля ввода
        /// </summary>
        public int Height { get; protected set; }


        /// <summary>
        /// Конструктор представления поля ввода
        /// </summary>
        /// <param name="parItem">Объект поля ввода</param>
        public ViewInputItem(InputItem parItem)
        {
            _item = parItem;
            _item.RedrawItem += RedrawItem;
        }

        /// <summary>
        /// Базовый обработчик события перерисовки поля ввода
        /// </summary>
        protected abstract void RedrawItem();
    }
}
