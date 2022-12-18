using ConsoleView.Game.GameObjects;
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

        public ConsoleViewGame(GameScreen parGameScreen) : base(parGameScreen)
        {

        }

        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        protected override ViewGameObject CreateGameObject(GameObject parGameObject)
        {
            return new ConsoleViewGameObject(parGameObject);
        }

        protected override void Redraw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            ClearObjects();
        }
    }
}
