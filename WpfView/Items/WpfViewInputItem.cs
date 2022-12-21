using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using View.Items;

namespace WpfView.Items
{
    /// <summary>
    /// Wpf представление элемента управления (поля ввода)
    /// </summary>
    public class WpfViewInputItem : ViewInputItem
    {
        /// <summary>
        /// высота представления поля ввода
        /// </summary>
        public const int HEIGHT = 60;

        /// <summary>
        /// Ширина представления поля ввода
        /// </summary>
        public const int WIDTH = 300;

        /// <summary>
        /// Размер шрифта при вводе текста
        /// </summary>
        public const int FONT_SIZE = 14;

        /// <summary>
        /// Графический элемент - поле ввода
        /// </summary>
        private Label _label = null;

        /// <summary>
        /// Выводитель
        /// </summary>
        private Utils.CastomOutput _output = new Utils.CastomOutput();

        /// <summary>
        /// Конструктор представления поля ввода
        /// </summary>
        /// <param name="parInputItem">Модель поля ввода</param>
        public WpfViewInputItem(InputItem parInputItem) : base(parInputItem)
        {
            Height = HEIGHT;
            Width = WIDTH;
        }

        /// <summary>
        /// Обработчик события рисования поля ввода
        /// </summary>
        public override void Draw()
        {
            Init();
        }

        /// <summary>
        /// Устанавливает поле ввода на экран
        /// </summary>
        /// <param name="parControl"></param>
        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_label);
        }

        /// <summary>
        /// Обработчик события перерисовки текста в поле ввода
        /// </summary>
        protected override void RedrawItem()
        {
            _label.Content = Item.Text;
        }

        /// <summary>
        /// Инициализирует поле ввода
        /// </summary>
        private void Init()
        {
            _label = _output.InitLabel(FONT_SIZE, X, Y, Height, Width);
        }
    }
}
