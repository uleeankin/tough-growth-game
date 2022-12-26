using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace WpfView.Utils
{
    /// <summary>
    /// Создатель графических элементов
    /// </summary>
    public class CustomOutput
    {
        /// <summary>
        /// Ширина границ объектов
        /// </summary>
        private const int BUTTON_BORDER_WIDTH = 3;

        /// <summary>
        /// Конструктор создателя графических элементов
        /// </summary>
        public CustomOutput()
        {

        }

        /// <summary>
        /// Создает кнопки
        /// </summary>
        /// <param name="parX">Координата X центра кнопки</param>
        /// <param name="parY">Координата Y центра кнопки</param>
        /// <param name="parHeight"></param>
        /// <param name="parWidth"></param>
        /// <returns></returns>
        public Button InitButton(int parX, int parY, int parHeight, int parWidth)
        {
            Button button = new Button();   
            button.Height = parHeight;
            button.Width = parWidth;
            button.BorderBrush = Brushes.White;
            button.BorderThickness = new Thickness(BUTTON_BORDER_WIDTH);
            button.VerticalAlignment = VerticalAlignment.Bottom;
            Canvas.SetTop(button, parY);
            Canvas.SetLeft(button, parX);
            return button;
        }

        /// <summary>
        /// Создает текстовое поле
        /// </summary>
        /// <param name="parText">Текст поля</param>
        /// <param name="parFontSize">Размер шрифта поля</param>
        /// <param name="parX">Координата X центра поля</param>
        /// <param name="parY">Координата Y центра поля</param>
        /// <returns></returns>
        public TextBlock InitTextBlock(string parText, int parFontSize, int parX, int parY)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = parText;
            textBlock.FontSize = parFontSize;
            textBlock.Foreground = Brushes.White;
            textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlock.FontFamily = new FontFamily(Properties.Resources.FontFamily);
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            Canvas.SetTop(textBlock, parY);
            Canvas.SetLeft(textBlock, parX);
            return textBlock;
        }

        /// <summary>
        /// Создает текстовое поле
        /// </summary>
        /// <param name="parFontSize">Шрифт текста</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parHeight">Высота поля</param>
        /// <param name="parWidth">Ширина поля</param>
        /// <returns></returns>
        public Label InitLabel(int parFontSize, int parX, int parY, int parHeight, int parWidth)
        {
            Label label = new Label();
            label.Foreground = Brushes.White;
            label.Background = Brushes.Black;
            label.FontSize = parFontSize;
            label.FontFamily = new FontFamily(Properties.Resources.FontFamily);
            label.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            label.BorderBrush = Brushes.White;
            label.BorderThickness = new Thickness(BUTTON_BORDER_WIDTH);
            label.Height = parHeight;
            label.Width = parWidth;
            Canvas.SetTop(label, parY);
            Canvas.SetLeft(label, parX);
            return label;
        }
    }
}
