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

        public const int TEXT_FONT_SIZE = 16;

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
            int y = TEXT_FONT_SIZE * 2;
            foreach (ViewPassiveItem elPassiveItem in Records)
            {
                elPassiveItem.Y = y;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = (int)_screen.Width / 2 
                    - elPassiveItem.Item.Text.Length / 2 * (int)(TEXT_FONT_SIZE / 1.5);
                y += (TEXT_FONT_SIZE * 2);
            }

            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                elMenuItem.Y = (int)_screen.Height - (int)(elMenuItem.Height * 2.5);
                elMenuItem.X = (int)_screen.Width / 2 - (int)(elMenuItem.Width / 2);
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
