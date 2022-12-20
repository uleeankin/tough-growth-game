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
            /*X = ConsoleCoordinatesConverter.ConvertX(Object.X - Object.Width / 2);
            Y = ConsoleCoordinatesConverter.ConvertY(Object.Y - Object.Height / 2);
            _output.CreateGameObjectView(Object, (int)X, (int)Y);*/
            Console.SetBufferSize(120, 30);
        }
            

        protected override void RedrawGameObject()
        {
            /*int newX = ConsoleCoordinatesConverter.ConvertX(Object.X - Object.Width / 2);
            int newY = ConsoleCoordinatesConverter.ConvertY(Object.Y - Object.Height / 2);
            if (Object.ID == Model.Enums.GameObjectTypes.GAME_SQUARE)
            {
                if (Math.Abs(X - newX) > 2 || newY != Y)
                {
                    _output.RedrawObject(Object, (int)X, (int)Y, newX, newY);
                    X = newX;
                    Y = newY;
                }
            }
            else if (Object.ID == Model.Enums.GameObjectTypes.PERMANENT_SQUARE)
            {
                if (newX != X || newY != Y)
                {
                    _output.RedrawObject(Object, (int)X, (int)Y, newX, newY);
                    X = newX;
                    Y = newY;
                }
            }
            else
            {
                _output.RedrawObject(Object, (int)X, (int)Y, newX, newY);
            }*/
        }
    }
}
