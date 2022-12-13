using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;
using View.Game.GameObjects;
using Model.Game;
using Model.Enums;
using WpfView.Game.GameObjects;
using System.Windows;

namespace WpfView.Game
{
    public class WpfViewGame : ViewGame
    {

        private MainScreen _screen = MainScreen.GetInstance();

        public WpfViewGame(GameScreen parGameScreen) : base(parGameScreen)
        {

        }

        public override void Draw()
        {
            _screen.Screen.Children.Clear();
            foreach (ViewGameObject elGameObject in Objects)
            {
                elGameObject.Draw();
            }
            this.SetParentControl(_screen.Screen);
        }

        protected override ViewGameObject CreateGameObject(GameObject parGameObject)
        {
            return new WpfViewGameObject(parGameObject);
        }

        protected override void Redraw()
        {
            Application.Current.Dispatcher.Invoke(() => {
                _screen.Screen.Children.Clear();
                ClearObjects();
                foreach (GameObject elGameObject in Screen.GameObjects)
                {
                    Objects.Add(CreateGameObject(elGameObject));
                }
                foreach (ViewGameObject elGameObject in Objects)
                {
                    elGameObject.Draw();
                }
                this.SetParentControl(_screen.Screen);
            });
        }

        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewGameObject elGameObject in Objects)
            {
                ((WpfViewGameObject)elGameObject).SetParentControl(parParent);
            }
        }
    }
}
