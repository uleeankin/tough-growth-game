using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Items
{
    /// <summary>
    /// Элемент управления (окно ввода)
    /// </summary>
    public class InputItem : Item
    {
        /// <summary>
        /// Делегат на перерисовку
        /// </summary>
        public delegate void dRedrawItem();
        /// <summary>
        /// Событие на перерисовку
        /// </summary>
        public event dRedrawItem RedrawItem = null;

        /// <summary>
        /// Конструктор
        /// </summary>
        public InputItem() : base("")
        {

        }

        /// <summary>
        /// Изменяет текст на поле ввода
        /// </summary>
        /// <param name="parNewString">Новая строка</param>
        public void ChangeText(string parNewString)
        {
            Text = parNewString;
            RedrawItem?.Invoke();
        }
    }
}
