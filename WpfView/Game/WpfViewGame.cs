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
    /// <summary>
    /// Графическое представление окна игры
    /// </summary>
    public class WpfViewGame : ViewGame
    {

        /// <summary>
        /// Общее окно для всех окон приложения
        /// </summary>
        private MainScreen _screen = MainScreen.GetInstance();

        /// <summary>
        /// Конструктор графического представления окна игры
        /// </summary>
        /// <param name="parGameScreen">Модель игры</param>
        public WpfViewGame(GameScreen parGameScreen) : base(parGameScreen)
        {

        }

        /// <summary>
        /// Обработчик события рисования объектов в окне игры
        /// </summary>
        public override void Draw()
        {
            _screen.Screen.Children.Clear();
            foreach (ViewGameObject elGameObject in GameObjects)
            {
                elGameObject.Draw();
            }
            this.SetParentControl(_screen.Screen);
        }

        /// <summary>
        /// Создает графическое представление препятствия
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        /// <returns>Графическое представление препятствия</returns>
        protected override ViewBarrier CreateBarrier(Barrier parBarrier)
        {
            return new WpfViewBarrier(parBarrier);
        }

        /// <summary>
        /// Создает графическое представление игрового объекта
        /// </summary>
        /// <param name="parGameObject">Модель игрового объекта</param>
        /// <returns>Графическое представление игрового объекта</returns>
        protected override ViewGameObject CreateGameObject(GameObject parGameObject)
        {
            return new WpfViewGameObject(parGameObject);
        }

        /// <summary>
        /// Обработчик события изменения количества препятствий на поле
        /// </summary>
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

        /// <summary>
        /// Обработчик события перерисовки окна игры
        /// </summary>
        protected override void Redraw()
        {
            Application.Current.Dispatcher.Invoke(() => {
                _screen.Screen.Children.Clear();
                ClearObjects();
                foreach (GameObject elGameObject in Screen.GameObjects)
                {
                    GameObjects.Add(CreateGameObject(elGameObject));
                }
                foreach (ViewGameObject elGameObject in GameObjects)
                {
                    elGameObject.Draw();
                }
                this.SetParentControl(_screen.Screen);
            });
        }

        /// <summary>
        /// Размещает игровые объекты на поле
        /// </summary>
        /// <param name="parParent"></param>
        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewGameObject elGameObject in GameObjects)
            {
                ((WpfViewGameObject)elGameObject).SetParentControl(parParent);
            }
        }

        /// <summary>
        /// Размещает препятствия на поле
        /// </summary>
        /// <param name="parParent"></param>
        private void SetParentControlForBarriers(FrameworkElement parParent)
        {
            foreach (ViewBarrier elBarrier in Barriers)
            {
                ((WpfViewBarrier)elBarrier).SetParentControl(parParent);
            }
        }
    }
}
