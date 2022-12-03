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
    public class WpfViewRecords : ViewRecords
    {

        public const int TEXT_FONT_SIZE = 14;

        private MainScreen _screen = MainScreen.GetInstance();

        public WpfViewRecords(MenuScreen parRecords) : base(parRecords)
        {
            Init();
        }

        public override void Draw()
        {
            _screen.Screen.Children.Clear();
            foreach (ViewPassiveItem elPassiveItem in Records)
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
            foreach (ViewPassiveItem elPassiveItem in Records)
            {
                elPassiveItem.Y = 30;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = 0;
            }

            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                if (Records.Length == 0)
                {
                    elMenuItem.Y = (int)_screen.Height - (int)(elMenuItem.Height * 2.5);
                } else
                {
                    elMenuItem.Y = elMenuItem.Height * 2 - elMenuItem.Height / 2;
                }
            }
        }

        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Records)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
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
    }
}
