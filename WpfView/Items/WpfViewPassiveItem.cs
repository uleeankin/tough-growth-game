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
    public class WpfViewPassiveItem : ViewPassiveItem
    {

        private TextBlock _text;
        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public WpfViewPassiveItem(PassiveItem parPassiveItem) : base(parPassiveItem)
        {

        }

        public override void Draw()
        {
            _text = _output.InitTextBlock(Item.Text, Height, X, Y);
        }

        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_text);
        }
    }
}
