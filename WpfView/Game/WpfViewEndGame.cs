using Model.Game;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public const int TEXT_FONT_SIZE = 14;

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
                _screen.Screen.Background = Brushes.Black;
                Console.WriteLine(_screen.Screen.Children.Count);
                foreach (ViewPassiveItem elPassiveItem in Info)
                {
                    elPassiveItem.Draw();
                }
                foreach (ViewControlItem elViewControlItem in BackToMenu)
                {
                    elViewControlItem.Draw();
                }

                /*foreach (ViewInputItem elInputItem in Input)
                {
                    elInputItem.Draw();
                }*/
                this.SetParentControl(_screen.Screen);
            });
            
        }

        private void Init()
        {
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                elPassiveItem.Y = 30;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = 0;
            }

            foreach (ViewControlItem elControlItem in BackToMenu)
            {
                elControlItem.Y = (int)_screen.Height - (int)(elControlItem.Height * 2.5);
                elControlItem.X = (int)_screen.Width / 2 - (int)(elControlItem.Width / 2);
            }

            foreach (ViewInputItem elInputItem in Input)
            {
                elInputItem.X = 500;
                elInputItem.Y = 275;
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
