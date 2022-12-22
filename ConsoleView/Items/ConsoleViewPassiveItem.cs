using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;
using Model.Items;

namespace ConsoleView.Items
{
    /// <summary>
    /// Консольное представление текстового поля
    /// </summary>
    public class ConsoleViewPassiveItem : ViewPassiveItem
    {

        /// <summary>
        /// Выводитель
        /// </summary>
        private Utils.CustomOutput _output = new Utils.CustomOutput();

        /// <summary>
        /// Конструктор консольного представления текстового поля
        /// </summary>
        /// <param name="parPassiveItem">Модель текстового поля</param>
        public ConsoleViewPassiveItem(PassiveItem parPassiveItem) : base(parPassiveItem)
        {
        }

        /// <summary>
        /// Обработчик события рисования текстового поля
        /// </summary>
        public override void Draw()
        {
            _output.OutputString(Item.Text, X, Y);
        }
    }
}
