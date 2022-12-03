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

        public Button InitButton(int parHeight, int parWidth, Thickness parThickness)
        {
            Button button = new Button();   
            button.Height = parHeight;
            button.Width = parWidth;
            button.Margin = parThickness;
            button.BorderBrush = Brushes.White;
            button.BorderThickness = new Thickness(BUTTON_BORDER_WIDTH);
            button.VerticalAlignment = VerticalAlignment.Bottom;
            return button;
        }

        public TextBlock InitTextBlock(string parText, int parFontSize, Thickness parMargin)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = parText;
            textBlock.FontSize = parFontSize;
            textBlock.Foreground = Brushes.White;
            textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
            textBlock.FontFamily = new FontFamily(Properties.Resources.FontFamily);
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Margin = parMargin;
            return textBlock;
        }
    }
}
