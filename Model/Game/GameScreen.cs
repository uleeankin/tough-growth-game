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
        }

        public void MoveUp()
        {
            if (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].Y > 0)
            {
                ((GameSquare)_gameObjects[(int)GameObjectTypes.GAME_SQUARE]).MoveUp(
                    _gameObjects[(int)GameObjectTypes.GAME_SQUARE].Height / 2);
            }
        }

        public void MoveDown()
        {
            if (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].Y < ScreenHeight)
            {
                ((GameSquare)_gameObjects[(int)GameObjectTypes.GAME_SQUARE]).MoveDown(
                    _gameObjects[(int)GameObjectTypes.GAME_SQUARE].Height / 2);
            }
        }

        public void MoveLeft()
        {
            if (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].X > 0)
            {
                ((GameSquare)_gameObjects[(int)GameObjectTypes.GAME_SQUARE]).MoveLeft(
                    _gameObjects[(int)GameObjectTypes.GAME_SQUARE].Height / 2);
            }
        }

        public void MoveRight()
        {
            if (_gameObjects[(int)GameObjectTypes.GAME_SQUARE].X < ScreenWidth)
            {
                ((GameSquare)_gameObjects[(int)GameObjectTypes.GAME_SQUARE]).MoveRight(
                    _gameObjects[(int)GameObjectTypes.GAME_SQUARE].Height / 2);
            }
        }
    }
}
