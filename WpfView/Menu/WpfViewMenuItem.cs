using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;


namespace WpfView.Menu
{
    public class WpfViewMenuItem : ViewMenuItem
    {

        public const int HEIGHT = 60;
        public const int WIDTH = 150;
        public const int TOP_MARGIN = 15;

        private Button _button = null;
        private TextBlock _text = null;
        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public WpfViewMenuItem(Model.Menu.MenuItem parMenuItem) : base(parMenuItem)
        {
            _button = _output.InitButton(HEIGHT, WIDTH,
                                        new Thickness(0, TOP_MARGIN, 0, 0));
            _text = _output.InitTextBlock(parMenuItem.Name);

            _button.Content = _text;

            Height = (int) _button.Height;
            Width = (int)_button.Width;

        }

        public override void Draw()
        {
            if (this.Item.State == Model.Enums.States.Normal)
            {
                this._button.Background = Brushes.Black;
                this._text.Foreground = Brushes.White;
                
            } else
            {
                this._button.Background = Brushes.White;
                this._text.Foreground = Brushes.Black;
            }
        }

        protected override void RedrawItem()
        {
            Draw();
        }

        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_button);
        }
    }
}
