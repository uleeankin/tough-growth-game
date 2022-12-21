using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Items;

namespace View.Items
{
    /// <summary>
    /// Элемент управления (текстовое поле)
    /// </summary>
    public abstract class ViewPassiveItem : View
    {
        /// <summary>
        /// Текстовое поле
        /// </summary>
        private PassiveItem _item = null;

        /// <summary>
        /// Текстовое поле
        /// </summary>
        public PassiveItem Item
        {
            get
            {
                return this._item;
            }
        }

        /// <summary>
        /// Координата X текстового поля
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y текстового поля
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина текстового поля
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота текстового поля
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Конструктор представления  текстового поля
        /// </summary>
        /// <param name="parPassiveItem">Текстовое поле</param>
        public ViewPassiveItem(PassiveItem parPassiveItem)
        {
            _item = parPassiveItem;
        }
    }
}
