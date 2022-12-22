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
    /// <summary>
    /// Консольное представление окна игры
    /// </summary>
    public class ConsoleViewGame : ViewGame
    {

        /// <summary>
        /// Выводитель
        /// </summary>
        private GameCustomOutput _output = GameCustomOutput.GetInstance();

        /// <summary>
        /// Конструктор консольного представления окна игры
        /// </summary>
        /// <param name="parGameScreen">Модель окна игры</param>
        public ConsoleViewGame(GameScreen parGameScreen) : base(parGameScreen)
        {
 
        }

        /// <summary>
        /// Обработчик события рисования окна игры
        /// </summary>
        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (ViewGameObject elGameObject in GameObjects)
            {
                elGameObject.Draw();
            }
        }

        /// <summary>
        /// Создает консольное представление препятствия
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        /// <returns>Консольное представление препятствия</returns>
        protected override ViewBarrier CreateBarrier(Barrier parBarrier)
        {
            return new ConsoleViewBarrier(parBarrier);
        }

        /// <summary>
        /// Создает консольное представление игрового объекта
        /// </summary>
        /// <param name="parGameObject">Модель игрового объекта</param>
        /// <returns>Консольное представление игрового объекта</returns>
        protected override ViewGameObject CreateGameObject(GameObject parGameObject)
        {
            return new ConsoleViewGameObject(parGameObject);
        }

        /// <summary>
        /// Обработчик события изменения количества препятсвий на поле
        /// </summary>
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

        /// <summary>
        /// Обработчик события перерисовки окна игры
        /// </summary>
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
