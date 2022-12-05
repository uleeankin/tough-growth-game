using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Game.GameObjects;
using Model.Enums;

namespace Model.Game
{
    public class GameScreen : Screen
    {

        private Dictionary<int, GameObject> _gameObjects 
            = new Dictionary<int, GameObject>();


        public double ScreenHeight { get; set; }
        public double ScreenWidth { get; set; }
        public int Level { get; set; }

        public GameObject[] GameObjects
        {
            get
            {
                return _gameObjects.Values.ToArray();
            }
        }

        public GameObject this[int parId]
        {
            get
            {
                return _gameObjects[parId];
            }
        }

        public GameScreen() : base()
        {
            _gameObjects.Add((int)GameObjectTypes.GAME_SQUARE,
                new GameSquare(GameObjectTypes.GAME_SQUARE, "ИК", 500, 275, 625));
            PermanentSquare permanentSquare = new PermanentSquare(GameObjectTypes.PERMANENT_SQUARE, "ПСК", 275, 275, 400);
            permanentSquare.NeedNewPosition += SetPermanentSquareCoordinates;
            _gameObjects.Add((int)GameObjectTypes.PERMANENT_SQUARE, permanentSquare);
        }

        private void SetPermanentSquareCoordinates()
        {
            Random random = new Random();
            GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X =
                random.NextDouble() * (ScreenWidth - GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Width * 3);
            GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y =
                random.NextDouble() * (ScreenHeight - GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Height * 3);

        }

        private void Move(GameSquare parGameSquare, MotionType parMotionType)
        {
            //parGameSquare.ChangeDirection(parMotionType);
            if (parMotionType == MotionType.UP)
            {
                parGameSquare.Y -= parGameSquare.Height / 2;
            }
            if (parMotionType == MotionType.DOWN)
            {
                parGameSquare.Y += parGameSquare.Height / 2;
            }
            if (parMotionType == MotionType.LEFT)
            {
                parGameSquare.X -= parGameSquare.Height / 2;
            }
            if (parMotionType == MotionType.RIGHT)
            {
                parGameSquare.X += parGameSquare.Height / 2;
            }
            CheckIntersections();
        }

        private void CheckIntersections()
        {
            GameObject gameSquare = GameObjects[(int)GameObjectTypes.GAME_SQUARE];
            foreach (GameObject elGameObject in GameObjects)
            {
                if (elGameObject.ID != GameObjectTypes.GAME_SQUARE)
                {
                    if (GetXIntersection(elGameObject.X, gameSquare.X, gameSquare.Width / 2)
                        && GetYIntersection(elGameObject.Y, gameSquare.Y, gameSquare.Height / 2))
                    {
                        if (gameSquare.Area >= elGameObject.Area)
                        {
                            if (elGameObject.State == GameObjectsStates.FOOD)
                            {
                                gameSquare.Area += elGameObject.Area;
                                elGameObject.State = GameObjectsStates.EATEN;
                            }
                        }
                    }
                }
            }
        }

        private bool GetXIntersection(double parObjectX, double parGameSquareX, double parDelta)
        {
            return (parGameSquareX <= parObjectX && parObjectX <= (parGameSquareX + parDelta))
                || ((parGameSquareX - parDelta) <= parObjectX && parObjectX <= parGameSquareX);
        }

        private bool GetYIntersection(double parObjectY, double parGameSquareY, double parDelta)
        {
            return (parGameSquareY <= parObjectY && parObjectY <= (parGameSquareY + parDelta))
                || ((parGameSquareY - parDelta) <= parObjectY && parObjectY <= parGameSquareY);
        }

        public void MoveUp(GameSquare parGameSquare)
        {
            Move(parGameSquare, MotionType.UP);
        }

        public void MoveDown(GameSquare parGameSquare)
        {
            Move(parGameSquare, MotionType.DOWN);
        }
        public void MoveLeft(GameSquare parGameSquare)
        {
            Move(parGameSquare, MotionType.LEFT);
        }
        public void MoveRight(GameSquare parGameSquare)
        {
            Move(parGameSquare, MotionType.RIGHT);
        }
    }
}
