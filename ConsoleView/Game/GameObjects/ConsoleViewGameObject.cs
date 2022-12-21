using ConsoleView.Utils;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game.GameObjects;

namespace ConsoleView.Game.GameObjects
{
    public class ConsoleViewGameObject : ViewGameObject
    {

        private Utils.GameCastomOutput _output = GameCastomOutput.GetInstance();

        public ConsoleViewGameObject(GameObject parGameObject) : base(parGameObject)
        {

        }

        public override void Draw()
        {
            Console.OutputEncoding = Encoding.Unicode;
            X = ConsoleCoordinatesConverter.ConvertX(GameObject.X);
            Y = ConsoleCoordinatesConverter.ConvertY(GameObject.Y);
            _output.CreateGameObjectView(GameObject, (int)X, (int)Y);
        }
            

        protected override void RedrawGameObject()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int newX = ConsoleCoordinatesConverter.ConvertX(GameObject.X);
            int newY = ConsoleCoordinatesConverter.ConvertY(GameObject.Y);
            if (GameObject.ID == Model.Enums.GameObjectTypes.GAME_SQUARE
                || GameObject.ID == Model.Enums.GameObjectTypes.PERMANENT_SQUARE)
            {
                if ((newX != X || newY != Y) && newX >= 0 && newY >= 0)
                {
                    _output.RedrawObject(GameObject, (int)X, (int)Y, newX, newY);
                    X = newX;
                    Y = newY;
                }
            }
            else
            {
                _output.RedrawObject(GameObject, (int)X, (int)Y, newX, newY);
            }
        }
    }
}
