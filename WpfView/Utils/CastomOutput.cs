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
    public class CastomOutput
    {
        public const int BUTTON_BORDER_WIDTH = 3;

        public CastomOutput()
        {

        }

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
    }
}
