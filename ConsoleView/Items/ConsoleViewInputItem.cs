using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace ConsoleView.Items
{
    /// <summary>
    /// Консольное представление поля ввода
    /// </summary>
    public class ConsoleViewInputItem : ViewInputItem
    {
        /// <summary>
        /// Ширина поля ввода
        /// </summary>
        private const int WIDTH = 20;

        /// <summary>
        /// Выводитель
        /// </summary>
        private Utils.CustomOutput _output = new Utils.CustomOutput();

        /// <summary>
        /// Коструктор представления поля ввода
        /// </summary>
        /// <param name="parInputItem">Модель поля ввода</param>
        public ConsoleViewInputItem(InputItem parInputItem) : base(parInputItem)
        {
            Width = WIDTH;
        }

        /// <summary>
        /// Обработчик события рисования поля ввода
        /// </summary>
        public override void Draw()
        {
            Console.SetCursorPosition(X, Y);
        }

        /// <summary>
        /// Обработчик события перерисовки поля ввода
        /// </summary>
        protected override void RedrawItem()
        {

            Console.BackgroundColor = ConsoleColor.Black;
            _output.OutputString(new StringBuilder().Insert(0, " ", WIDTH).ToString(), X, Y);
            Console.BackgroundColor = ConsoleColor.Black;
            _output.OutputString(Item.Text, X, Y);
        }
    }
}
