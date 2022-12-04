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


        public bool HasMoving = false;
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
                new GameSquare(GameObjectTypes.GAME_SQUARE, "ИК", (int)ScreenWidth / 2, (int)ScreenHeight / 2, 625));
        }

        public void MoveUp()
        {
            HasMoving = true;
            while (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].Y > 0 && HasMoving)
            {
                _gameObjects[(int)GameObjectTypes.GAME_SQUARE].Y--;
            }
        }

        public void MoveDown()
        {
            HasMoving = true;
            while (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].Y < ScreenHeight && HasMoving)
            {
                _gameObjects[(int)GameObjectTypes.GAME_SQUARE].Y++;
            }
        }

        public void MoveLeft()
        {
            HasMoving = true;
            while (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].X > 0 && HasMoving)
            {
                _gameObjects[(int)GameObjectTypes.GAME_SQUARE].X--;
            }
        }

        public void MoveRight()
        {
            HasMoving = true;
            while (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].X < ScreenWidth && HasMoving)
            {
                _gameObjects[(int)GameObjectTypes.GAME_SQUARE].X++;
            }
        }
    }
}
