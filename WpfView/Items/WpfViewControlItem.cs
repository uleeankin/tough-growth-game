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
    public class WpfViewControlItem : ViewControlItem
    {

        public const int HEIGHT = 60;
        public const int WIDTH = 160;
        public const int FONT_SIZE = 16;

        private Button _button = null;
        private TextBlock _text = null;
        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public WpfViewControlItem(ControlItem parControlItem) : base(parControlItem)
        {
            Height = HEIGHT;
            Width = WIDTH;
        }

        private void Init()
        {
            _button = _output.InitButton(X, Y, HEIGHT, WIDTH);
            _text = _output.InitTextBlock(Item.Text, FONT_SIZE,
                                           X, Y);

            _button.Content = _text;
        }

        public override void Draw()
        {
            Init();
            DrawItem();
        }

        protected override void RedrawItem()
        {
            DrawItem();
        }

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

        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_button);
        }

    }
}
