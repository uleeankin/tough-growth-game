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

        public const int FONT_SIZE = 20;
        public const int TITLE_FONT_SIZE = 80;
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

            return button;
        }

        public TextBlock InitTextBlock(string parText)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = parText;
            textBlock.FontSize = FONT_SIZE;
            textBlock.FontFamily = new FontFamily(Properties.Resources.FontFamily);
            return textBlock;
        }

        public TextBlock GetTitle()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = Properties.Resources.Title;
            textBlock.FontSize = TITLE_FONT_SIZE;
            textBlock.Foreground = Brushes.White;
            textBlock.FontFamily = new FontFamily(Properties.Resources.FontFamily);
            textBlock.Margin = new Thickness(0, 30, 0, 0);
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.FontWeight = FontWeights.Bold;
            return textBlock;
        }
    }
}
