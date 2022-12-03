using Model.Items;
using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using View.Items;
using View.Menu;
using WpfView.Items;

namespace WpfView.Menu
{
    public class WpfViewMenu : ViewMenu
    {

        private MainScreen _screen = MainScreen.GetInstance();

        public WpfViewMenu(MenuScreen parMenu) : base(parMenu)
        {
            Init();
        }

        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Title)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in Menu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
            }
        }

        public override void Draw()
        {
            _screen.Screen.Children.Clear();
            foreach (ViewPassiveItem elPassiveItem in Title)
            {
                elPassiveItem.Draw();
            }
            foreach (ViewControlItem elViewControlItem in Menu)
            {
                elViewControlItem.Draw();
            }
            this.SetParentControl(_screen.Screen);
        }

        protected override void Redraw()
        {

        }

        protected override ViewControlItem CreateControlItem(ControlItem parMenuItem)
        {
            return new WpfViewControlItem(parMenuItem);
        }

        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parMenuTitle)
        {
            return new WpfViewPassiveItem(parMenuTitle);
        }

        private void Init()
        {
            foreach (ViewPassiveItem elPassiveItem in Title)
            {
                elPassiveItem.Y = (int)_screen.Height % 100 / 2;
                elPassiveItem.Height = (int)_screen.Width / 10 - ((int)_screen.Width / 40);
                elPassiveItem.X = (int)_screen.Width / 4;
            }

            foreach (ViewControlItem elMenuItem in Menu)
            {
                elMenuItem.Y = 15;
            }
        }
    }
}
