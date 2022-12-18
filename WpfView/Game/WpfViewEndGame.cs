using Model.Game;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using View.Game;
using View.Items;
using WpfView.Items;

namespace WpfView.Game
{
    public class WpfViewEndGame : ViewEndGame
    {
        public const int TEXT_FONT_SIZE = 24;

        private MainScreen _screen = MainScreen.GetInstance();

        public WpfViewEndGame(EndGameScreen parEndGameScreen) : 
                                                base(parEndGameScreen)
        {
            Init();
        }

        public override void Draw()
        {

            Application.Current.Dispatcher.Invoke(() => {
                _screen.Screen.Children.Clear();
                foreach (ViewPassiveItem elPassiveItem in Info)
                {
                    elPassiveItem.Draw();
                }
                foreach (ViewControlItem elViewControlItem in BackToMenu)
                {
                    elViewControlItem.Draw();
                }

                foreach (ViewInputItem elInputItem in Input)
                {
                    elInputItem.Draw();
                }
                this.SetParentControl(_screen.Screen);
            });
        }

        private void Init()
        {
            int y = TEXT_FONT_SIZE * 2;
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                elPassiveItem.Y = y;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = (int)_screen.Screen.Width / 2 - y * 2;
                y += TEXT_FONT_SIZE * 2;
            }

            foreach (ViewControlItem elControlItem in BackToMenu)
            {
                elControlItem.Y = (int)_screen.Height - (int)(elControlItem.Height * 2.5);
                elControlItem.X = (int)_screen.Width / 2 - (int)(elControlItem.Width / 2);
            }

            foreach (ViewInputItem elInputItem in Input)
            {
                elInputItem.X = (int)_screen.Width / 2 - elInputItem.Width / 2;
                elInputItem.Y = (int)_screen.Height / 2;
            }
        }

        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
            }
            foreach (ViewInputItem elInputItem in Input)
            {
                ((WpfViewInputItem)elInputItem).SetParentControl(parParent);
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

        protected override ViewInputItem CreateInputItem(InputItem parInputItem)
        {
            return new WpfViewInputItem(parInputItem);
        }
    }
}
