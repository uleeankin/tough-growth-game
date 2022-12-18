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
    public class WpfViewInputItem : ViewInputItem
    {

        public const int HEIGHT = 60;
        public const int WIDTH = 300;
        public const int FONT_SIZE = 14;

        private Label _label = null;
        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public WpfViewInputItem(InputItem parInputItem) : base(parInputItem)
        {
            Height = HEIGHT;
            Width = WIDTH;
        }

        public override void Draw()
        {
            Init();
        }

        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_label);
        }

        protected override void RedrawItem()
        {
            _label.Content = Item.Text;
        }

        private void Init()
        {
            _label = _output.InitLabel(FONT_SIZE, X, Y, Height, Width);
        }
    }
}
