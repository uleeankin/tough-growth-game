using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;
using Model.Items;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;

namespace WpfView.Items
{
    /// <summary>
    /// Графическое представление текстового поля
    /// </summary>
    public class WpfViewPassiveItem : ViewPassiveItem
    {
        /// <summary>
        /// Графический элемент - текстовое поле
        /// </summary>
        private TextBlock _text;

        /// <summary>
        /// Выводитель
        /// </summary>
        private Utils.CustomOutput _output = new Utils.CustomOutput();

        /// <summary>
        /// Конструктор представления текстового поля
        /// </summary>
        /// <param name="parPassiveItem">Модель текстового поля</param>
        public WpfViewPassiveItem(PassiveItem parPassiveItem) : base(parPassiveItem)
        {

        }

        /// <summary>
        /// Обработчик события рисования текстового поля
        /// </summary>
        public override void Draw()
        {
            _text = _output.InitTextBlock(Item.Text, Height, X, Y);
        }

        /// <summary>
        /// Устанавливает текстовое поле на экран
        /// </summary>
        /// <param name="parControl"></param>
        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_text);
        }
    }
}
