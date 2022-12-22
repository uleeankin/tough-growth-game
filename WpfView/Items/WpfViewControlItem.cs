using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;
using Model.Items;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;

namespace WpfView.Items
{
    /// <summary>
    /// Wpf представление элемента управления (кнопки)
    /// </summary>
    public class WpfViewControlItem : ViewControlItem
    {
        /// <summary>
        /// Высота представления кнопки
        /// </summary>
        private const int HEIGHT = 60;
        /// <summary>
        /// Ширина представления кнопки
        /// </summary>
        private const int WIDTH = 160;

        /// <summary>
        /// Размер шрифта текста на кнопке
        /// </summary>
        private const int FONT_SIZE = 16;

        /// <summary>
        /// Графический элемент - кнопка
        /// </summary>
        private Button _button = null;

        /// <summary>
        /// Графический элемент - текстовый блок
        /// </summary>
        private TextBlock _text = null;

        /// <summary>
        /// Выводитель
        /// </summary>
        private Utils.CustomOutput _output = new Utils.CustomOutput();

        /// <summary>
        /// Конструктор представления кнопки
        /// </summary>
        /// <param name="parControlItem">Модель кнопки</param>
        public WpfViewControlItem(ControlItem parControlItem) : base(parControlItem)
        {
            Height = HEIGHT;
            Width = WIDTH;
        }

        /// <summary>
        /// Инициализирует кнопки
        /// </summary>
        private void Init()
        {
            _button = _output.InitButton(X, Y, HEIGHT, WIDTH);
            _text = _output.InitTextBlock(Item.Text, FONT_SIZE,
                                           X, Y);

            _button.Content = _text;
        }

        /// <summary>
        /// Обработчик события рисования кнопки
        /// </summary>
        public override void Draw()
        {
            Init();
            DrawItem();
        }

        /// <summary>
        /// Перерисовывает кнопку
        /// </summary>
        protected override void RedrawItem()
        {
            DrawItem();
        }

        /// <summary>
        /// Рисует кнопку
        /// </summary>
        private void DrawItem()
        {
            if (this.Item.State == Model.Enums.States.Normal)
            {
                this._button.Background = Brushes.Black;
                this._text.Foreground = Brushes.White;

            }
            else
            {
                this._button.Background = Brushes.White;
                this._text.Foreground = Brushes.Black;
            }
        }

        /// <summary>
        /// Устанавливает кнопку на экран
        /// </summary>
        /// <param name="parControl"></param>
        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_button);
        }

    }
}
