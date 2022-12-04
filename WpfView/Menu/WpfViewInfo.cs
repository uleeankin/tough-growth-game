using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;
using View.Menu;
using WpfView.Items;
using Model.Items;
using Model.Menu;
using System.Windows;

namespace WpfView.Menu
{
    public class WpfViewInfo : ViewInfo
    {
        public const int TEXT_FONT_SIZE = 14;

        private MainScreen _screen = MainScreen.GetInstance();

        public WpfViewInfo(MenuScreen parMenuScreen) : base(parMenuScreen)
        {
            Init();
        }

        public override void Draw()
        {
            _screen.Screen.Children.Clear();
            foreach (ViewPassiveItem elPassiveItem in Rules)
            {
                elPassiveItem.Draw();
            }
            foreach (ViewControlItem elViewControlItem in BackToMenu)
            {
                elViewControlItem.Draw();
            }
            this.SetParentControl(_screen.Screen);
        }

        private void Init()
        {
            int y = 10;
            foreach (ViewPassiveItem elPassiveItem in Rules)
            {
                elPassiveItem.Y = y;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = 10;
                y += (int)_screen.Height / 3;
            }

            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                elMenuItem.Y = (int)_screen.Height - (int)(elMenuItem.Height * 2.5);
                elMenuItem.X = (int)_screen.Width / 2 - (int)(elMenuItem.Width / 2);
            }
        }

        protected override ViewControlItem CreateControlItem(ControlItem parControlItem)
        {
            return new WpfViewControlItem(parControlItem);
        }

        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parPassiveItem)
        {
            return new WpfViewPassiveItem(parPassiveItem);
        }

        protected override void Redraw()
        {
            
        }

        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Rules)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
            }
        }
    }
}
