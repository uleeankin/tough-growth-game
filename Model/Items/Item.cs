using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Items
{
    /// <summary>
    /// Базовый элемент управления
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// Текст элемента управления
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parText">Текст элемента управления</param>
        public Item(string parText)
        {
            Text = parText;
        }
    }
}
