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
    /// Консольное представление кнопки
    /// </summary>
    public class ConsoleViewControlItem : ViewControlItem
    {
        /// <summary>
        /// Высота кнопки
        /// </summary>
        private const int HEIGHT = 3;

        /// <summary>
        /// Ширина кнопки
        /// </summary>
        private const int WIDTH = 20;

        /// <summary>
        /// Выводитель
        /// </summary>
        private Utils.CustomOutput _output = new Utils.CustomOutput();

        /// <summary>
        /// Конструктор представление кнопки
        /// </summary>
        /// <param name="parControlItem">Модель кнопки</param>
        public ConsoleViewControlItem(ControlItem parControlItem) : base(parControlItem)
        {
            Height = HEIGHT;
            Width = WIDTH;
        } 

        /// <summary>
        /// Обработчик события рисования кнопки
        /// </summary>
        public override void Draw()
        {
            _output.OutputButton(Item.Text,
                X - Item.Text.Length / 2,
                Y, Item.State);
            
        }

        /// <summary>
        /// Обработчик события перерисовки кнопки
        /// </summary>
        protected override void RedrawItem()
        {
            Draw();
        }
    }
}
