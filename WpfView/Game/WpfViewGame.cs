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

        protected override ViewBarrier CreateBarrier(Barrier parBarrier)
        {
            return new WpfViewBarrier(parBarrier);
        }

        protected override ViewGameObject CreateGameObject(GameObject parGameObject)
        {
            return new WpfViewGameObject(parGameObject);
        }

        protected override void OnBarriersChange()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (Barriers.Count != 0)
                {
                    foreach (WpfViewBarrier elViewBarrier in Barriers)
                    {
                        if (elViewBarrier.Barrier.State == GameObjectsStates.INACTIVE)
                        {
                            _screen.Screen.Children.Remove(((WpfViewBarrier)elViewBarrier).Shape);
                        }
                    }

                    List<Barrier> barriers = new List<Barrier>();
                    List<ViewBarrier> barriersView = new List<ViewBarrier>();
                    Barriers.ForEach(elBarrierView => barriers.Add(elBarrierView.Barrier));
                    Barriers.ForEach(elBarrierView => barriersView.Add(elBarrierView));

                    foreach (Barrier elBarrier in Screen.Barriers)
                    {
                        if (!barriers.Contains(elBarrier))
                        {
                            Barriers.Add(CreateBarrier(elBarrier));
                        }
                    }

                    foreach (ViewBarrier elBarrier in Barriers)
                    {
                        if (!barriersView.Contains(elBarrier))
                        {
                            elBarrier.Draw();
                            ((WpfViewBarrier)elBarrier).SetParentControl(_screen.Screen);
                        }
                    }

                }
                else
                {
                    Barriers = new List<ViewBarrier>();
                    foreach (Barrier elBarrier in Screen.Barriers)
                    {
                        Barriers.Add(CreateBarrier(elBarrier));
                    }
                    foreach (ViewBarrier elBarrier in Barriers)
                    {
                        elBarrier.Draw();
                    }
                    this.SetParentControlForBarriers(_screen.Screen);
                }

            });
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

        private void SetParentControlForBarriers(FrameworkElement parParent)
        {
            foreach (ViewBarrier elBarrier in Barriers)
            {
                ((WpfViewBarrier)elBarrier).SetParentControl(parParent);
            }
        }
    }
}
