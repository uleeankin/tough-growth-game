using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Items
{
    /// <summary>
    /// Элемент управления (отображения текста)
    /// </summary>
    public class PassiveItem : Item
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parText">Отображаемый текст</param>
        public PassiveItem(string parText) : base(parText)
        {

        }
    }
}
