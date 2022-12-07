﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Game.GameObjects;
using Model.Enums;
using Model.Utils;

namespace Model.Game
{
    public class GameScreen : Screen
    {
        public delegate void dNeedRedraw();
        public event dNeedRedraw NeedRedraw = null;

        private List<GameObject> _gameObjects 
            = new List<GameObject>();

        private Dictionary<int, List<GameObject>> _levelObjects
            = new Dictionary<int, List<GameObject>>();

        private int _level = 1;

        public double ScreenHeight { get; set; }
        public double ScreenWidth { get; set; }
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                NeedRedraw?.Invoke();
            }
        }

        public GameObject[] GameObjects
        {
            get
            {
                return _gameObjects.ToArray();
            }
        }

        public GameObject this[int parId]
        {
            get
            {
                return _gameObjects.Find((x) => (int)x.ID == parId);
            }
        }

        public GameScreen() : base()
        {
            Init();
        }

        private void Init()
        {
            _levelObjects = LevelsParser.GetLevels(1);
            _gameObjects = _levelObjects[Level];
            ((PermanentSquare)_gameObjects[(int)GameObjectTypes.PERMANENT_SQUARE])
                                .NeedNewPosition += SetPermanentSquareCoordinates;
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
                    if (gameSquare.Area >= elGameObject.Area)
                    {
                        if (GetXIntersection(elGameObject.X, gameSquare.X, gameSquare.Width / 2)
                        && GetYIntersection(elGameObject.Y, gameSquare.Y, gameSquare.Height / 2))
                        {
                            if (elGameObject.State == GameObjectsStates.FOOD)
                            {
                                gameSquare.Area += elGameObject.Area;
                                elGameObject.State = GameObjectsStates.EATEN;
                                if (_gameObjects.FindAll(
                                    (x) => x.State == GameObjectsStates.INACTIVE)
                                    .Count == GameObjects.Length - 2)
                                {
                                    _gameObjects.ForEach((x) => {
                                        if (x.State == GameObjectsStates.INACTIVE)
                                        {
                                            x.State = GameObjectsStates.BARRIER;
                                        }
                                    });
                                }
                            }

                        }
                        if (elGameObject.State == GameObjectsStates.BARRIER)
                        {
                            elGameObject.State = GameObjectsStates.FOOD;
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
