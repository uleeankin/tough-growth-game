using ConsoleView.Game.GameObjects;
using ConsoleView.Utils;
using Model.Enums;
using Model.Game;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;
using View.Game.GameObjects;

namespace ConsoleView.Game
{
    public class ConsoleViewGame : ViewGame
    {

        private GameCastomOutput _output = GameCastomOutput.GetInstance();

        public ConsoleViewGame(GameScreen parGameScreen) : base(parGameScreen)
        {
 
        }

        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (ViewGameObject elGameObject in GameObjects)
            {
                elGameObject.Draw();
            }
        }

        protected override ViewBarrier CreateBarrier(Barrier parBarrier)
        {
            return new ConsoleViewBarrier(parBarrier);
        }

        protected override ViewGameObject CreateGameObject(GameObject parGameObject)
        {
            return new ConsoleViewGameObject(parGameObject);
        }

        protected override void OnBarriersChange()
        {
            if (Barriers.Count != 0)
            {
                foreach (ConsoleViewBarrier elViewBarrier in Barriers)
                {
                    if (elViewBarrier.Barrier.State == GameObjectsStates.INACTIVE)
                    {
                        _output.Clear(ConsoleCoordinatesConverter.ConvertX(elViewBarrier.Barrier.X),
                            ConsoleCoordinatesConverter.ConvertY(elViewBarrier.Barrier.Y));
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
            }
            foreach (ViewGameObject elGameObject in GameObjects)
            {
                elGameObject.Draw();
            }
        }

        protected override void Redraw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ClearObjects();
            foreach (GameObject elGameObject in Screen.GameObjects)
            {
                GameObjects.Add(CreateGameObject(elGameObject));
            }
            foreach (ViewGameObject elGameObject in GameObjects)
            {
                elGameObject.Draw();
            }
        }
    }
}
