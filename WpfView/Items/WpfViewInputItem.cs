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

        private Label _label = null;
        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public WpfViewInputItem(InputItem parInputItem) : base(parInputItem)
        {
            Height = HEIGHT;
            Width = WIDTH;
        }

        public override void Draw()
        {
            
        }

        public void SetParentControl(FrameworkElement parControl)
        {
            //((IAddChild)parControl).AddChild(_button);
        }
    }
}
