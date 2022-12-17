using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using View.Items;

namespace WpfView.Items
{
    public class WpfViewInputItem : ViewInputItem
    {

        public WpfViewInputItem(InputItem parInputItem) : base(parInputItem)
        {

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
