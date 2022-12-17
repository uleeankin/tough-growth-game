using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Game.GameObjects;
using Model.Enums;
using Model.Utils;
using System.Threading;
using System.Diagnostics;

namespace Model.Game
{
    public class GameScreen : Screen
    {
        public delegate void dNeedRedraw();
        public event dNeedRedraw NeedRedraw = null;

        public delegate void dEndGame();
        public event dEndGame EndGame = null;

        private bool _isNeedStop = false;
        private double _objectsSpeed = 200;
        private double _timeCoefficient = 0;

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

        public int Deaths { get; set; }

        public GameScreen() : base()
        {
            Deaths = 0;
            _levelObjects = LevelsParser.GetLevels(10);
            Init();
        }

        private void Init()
        {
            if (Level > 10)
            {
                EndGame?.Invoke();
            }
            else
            {
                _gameObjects.Clear();
                _levelObjects[Level].ForEach((elObject) => {
                    _gameObjects.Add(elObject.Clone());
                });
                ((PermanentSquare)_gameObjects[(int)GameObjectTypes.PERMANENT_SQUARE])
                                    .NeedNewPosition += SetPermanentSquareCoordinates;
            }
            
        }

        private void SetPermanentSquareCoordinates()
        {
            double x;
            double y;

            bool isIntersection;
            GameObject permanentSquare = GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE];

            do
            {
                isIntersection = false;
                Random random = new Random();
                x = random.NextDouble()
                    * ((ScreenWidth - permanentSquare.Width * 3)
                    - permanentSquare.Width * 3) + permanentSquare.Width * 3;
                y = random.NextDouble()
                    * ((ScreenHeight - permanentSquare.Height * 3)
                    - permanentSquare.Height * 3) + permanentSquare.Height * 3;

                foreach (GameObject elGameObject in GameObjects)
                {
                    if (elGameObject.ID != GameObjectTypes.PERMANENT_SQUARE
                        && elGameObject.ID != GameObjectTypes.GAME_SQUARE)
                    {
                        isIntersection = isIntersection
                            || (GetXIntersection(elGameObject.X, x,
                                    permanentSquare.Width, elGameObject.Width)
                                && GetYIntersection(elGameObject.Y, y,
                                    permanentSquare.Height, elGameObject.Height));
                    }
                }
            } while (isIntersection);


            GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X = x;
            GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y = y;

        }

        public void StartGame()
        {
            Level = 1;
            new Thread(() =>
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                while (!_isNeedStop)
                {
                    double start = timer.ElapsedMilliseconds;
                    Move();
                    double end = timer.ElapsedMilliseconds;
                    _timeCoefficient = (end - start) / 1000;
                }
            }).Start();
        }

        public void StopGame()
        {
            _isNeedStop = true;
        }

        private void Move()
        {
            ((GameSquare)_gameObjects[(int)GameObjectTypes.GAME_SQUARE])
                .MoveByStep(_objectsSpeed * _timeCoefficient, ScreenHeight, ScreenWidth);
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
                        if (IsIntersection(elGameObject, gameSquare))
                        {
                            if (elGameObject.State == GameObjectsStates.FOOD)
                            {
                                if (_gameObjects.FindAll(
                                    (x) => x.State == GameObjectsStates.EATEN)
                                    .Count == GameObjects.Length - 2)
                                {
                                    Level++;
                                    StartNewLevel();
                                    break;
                                }

                                gameSquare.Area += (elGameObject.Area / (GameObjects.Length - 2));
                                elGameObject.State = GameObjectsStates.EATEN;

                                if (_gameObjects.FindAll(
                                    (x) => x.State == GameObjectsStates.INACTIVE)
                                    .Count == GameObjects.Length - 2)
                                {
                                    _gameObjects.ForEach((x) =>
                                    {
                                        SetNewState(x,
                                            GameObjectsStates.INACTIVE, GameObjectsStates.BARRIER);
                                    });
                                }

                            }

                        }
                        SetNewState(elGameObject,
                            GameObjectsStates.BARRIER, GameObjectsStates.FOOD);
                    }
                    else
                    {
                        if (IsIntersection(elGameObject, gameSquare))
                        {
                            if (elGameObject.State == GameObjectsStates.BARRIER)
                            {
                                Deaths++;
                                Level = Level < 8 ? Level : Level - 1;
                                StartNewLevel();
                            }
                        }
                    }
                }
            }
        }

        private void SetNewState(GameObject parObject,
                                GameObjectsStates parCurrentState,
                                GameObjectsStates parNewState)
        {
            if (parObject.State == parCurrentState)
            {
                parObject.State = parNewState;
            }
        }

        private bool IsIntersection(GameObject parGameObject, GameObject parGameSquare)
        {
            return GetXIntersection(parGameObject.X, parGameSquare.X,
                            parGameSquare.Width / 2, parGameObject.Width / 2)
                        && GetYIntersection(parGameObject.Y, parGameSquare.Y,
                            parGameSquare.Height / 2, parGameObject.Height / 2);
        }

        private void StartNewLevel()
        {
            ((PermanentSquare)_gameObjects[(int)GameObjectTypes.PERMANENT_SQUARE])
                                .NeedNewPosition -= SetPermanentSquareCoordinates;
            Init();
            if (Level <= 10)
            {
                NeedRedraw?.Invoke();
            }
        }

        private bool GetXIntersection(double parObjectX, double parGameSquareX,
            double parGameSquareDelta, double parObjectDelta)
        {
            return ((parGameSquareX - parGameSquareDelta) < (parObjectX + parObjectDelta)
                && (parObjectX - parObjectDelta) < (parGameSquareX + parGameSquareDelta));
        }

        private bool GetYIntersection(double parObjectY, double parGameSquareY,
            double parGameSquareDelta, double parObjectDelta)
        {
            return ((parGameSquareY - parGameSquareDelta) < (parObjectY + parObjectDelta)
                && (parObjectY - parObjectDelta) < (parGameSquareY + parGameSquareDelta));
        }

        public void MoveUp(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.UP;
        }

        public void MoveDown(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.DOWN;
        }
        public void MoveLeft(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.LEFT;
        }
        public void MoveRight(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.RIGHT;
        }
    }
}
