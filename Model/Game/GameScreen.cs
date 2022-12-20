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
using System.Timers;
using Barrier = Model.Game.GameObjects.Barrier;

namespace Model.Game
{
    public class GameScreen : Screen
    {
        private const double PLAYER_SPEED = 200;
        private const double RECTANGLE_SPEED = 100;
        private const double SHORT_BARRIER_SPEED = 150;
        private const double LONG_BARRIER_SPEED = 50;
        private const double ARROW_BARRIER_SPEED = 70;

        public delegate void dNeedRedraw();
        public event dNeedRedraw NeedRedraw = null;

        public delegate void dEndGame();
        public event dEndGame EndGame = null;

        public delegate void dOnBarriersChange();
        public event dOnBarriersChange OnBarriersChange = null;

        private bool _isNeedStop = false;
        private double _timeCoefficient = 0;
        private volatile int _inactiveObjectsNumber = 0;
        private volatile int _eatenObjectsNumber = 0;

        private System.Timers.Timer _shortBarrierTimer = new System.Timers.Timer(2000);
        private System.Timers.Timer _longBarrierTimer = new System.Timers.Timer(3000);

        private volatile List<Barrier> _barriers = new List<Barrier>();

        private List<GameObject> _gameObjects
            = new List<GameObject>();

        private Dictionary<int, List<GameObject>> _levelObjects
            = new Dictionary<int, List<GameObject>>();

        private int _level = 1;

        public double ScreenHeight { get; set; }
        public double ScreenWidth { get; set; }

        public bool HasHexagons { get; set; }
        public bool HasTriangles { get; set; }

        public List<Barrier> Barriers
        {
            get
            {
                return _barriers;
            }
        }

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

        public List<GameObject> this[int parId]
        {
            get
            {
                return _gameObjects.FindAll((x) => (int)x.ID == parId);
            }
        }

        public int Deaths { get; set; }

        public GameScreen() : base()
        {
            _levelObjects = LevelsParser.GetLevels(10);
            Init();
            InitTimers();
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
                _eatenObjectsNumber = 0;
                _inactiveObjectsNumber = _gameObjects.Count - 2;
                _barriers.Clear();
                if (this[(int)GameObjectTypes.HEXAGON].Count != 0)
                {
                    HasHexagons = true;
                }
                else
                {
                    HasHexagons = false;
                }

                if (this[(int)GameObjectTypes.TRIANGLE].Count != 0)
                {
                    HasTriangles = true;
                }
                else
                {
                    HasTriangles = false;
                }
            }

        }

        private void InitTimers()
        {
            _shortBarrierTimer.AutoReset = true;
            _shortBarrierTimer.Elapsed += OnShortShotsTimerEvent;
            _longBarrierTimer.AutoReset = true;
            _longBarrierTimer.Elapsed += OnLongShotsTimerEvent;

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
            _shortBarrierTimer.Enabled = true;
            _longBarrierTimer.Enabled = true;
            _isNeedStop = false;
            if (_level == 1 || _level > 10)
            {
                Level = 1;
                Deaths = 0;
            }

            StartNewLevel();

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
            _shortBarrierTimer.Enabled = false;
            _longBarrierTimer.Enabled = false;
            _isNeedStop = true;
        }

        private void Move()
        {

            GameSquare gameSquare = ((GameSquare)_gameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            gameSquare.MoveByStep(PLAYER_SPEED * _timeCoefficient, ScreenHeight, ScreenWidth);

            Parallel.ForEach(GameObjects, elGameObject => {
                if (elGameObject.ID == GameObjectTypes.RECTANGLE)
                {
                    ((Rectangle)elGameObject).MoveByStep(RECTANGLE_SPEED * _timeCoefficient);
                }
            });

            for (int i = 0; i < Barriers.Count; i++)
            {
                Barrier elBarrier = Barriers[i];
                if (elBarrier.Parent.ID == GameObjectTypes.CIRCLE)
                {
                    elBarrier.EndX = gameSquare.X;
                    elBarrier.EndY = gameSquare.Y;
                }

                if (elBarrier.ID == BarrierType.SHORT_SHOT
                    || elBarrier.ID == BarrierType.LONG_SHOT)
                {
                    if (elBarrier.X < 0
                        || elBarrier.Y < 0
                        || elBarrier.X > ScreenWidth
                        || elBarrier.Y > ScreenHeight)
                    {
                        StopBarrier(elBarrier);
                    }
                }

                elBarrier.MoveByStep(GetBarrierSpeed(elBarrier.ID) * _timeCoefficient);
            }

            CheckIntersections();
            CheckBarriersIntersections();
            DeleteInactiveBarrier();
        }

        private void CheckIntersections()
        {
            GameObject gameSquare = GameObjects[(int)GameObjectTypes.GAME_SQUARE];
            Parallel.ForEach(GameObjects, elGameObject =>
            {
                if (elGameObject.ID != GameObjectTypes.GAME_SQUARE
                    && elGameObject.State != GameObjectsStates.INACTIVE)
                {
                    if (gameSquare.Area >= elGameObject.Area)
                    {
                        if (IsIntersection(elGameObject, gameSquare))
                        {
                            if (elGameObject.State == GameObjectsStates.FOOD)
                            {
                                if (_eatenObjectsNumber == GameObjects.Length - 2
                                        && elGameObject.ID == GameObjectTypes.PERMANENT_SQUARE)
                                {
                                    Level++;
                                    StartNewLevel();
                                    return;
                                }

                                gameSquare.Area += elGameObject.Area;
                                elGameObject.State = GameObjectsStates.EATEN;

                                if (_barriers.Count != 0)
                                {
                                    StopBarrier(elGameObject);
                                }

                                if (elGameObject.ID != GameObjectTypes.PERMANENT_SQUARE)
                                {
                                    _eatenObjectsNumber++;
                                }

                                if (_inactiveObjectsNumber == GameObjects.Length - 2)
                                {
                                    _gameObjects.ForEach((elObject) =>
                                    {

                                        StartBarriers(elObject, gameSquare);
                                        SetNewState(elObject,
                                            GameObjectsStates.INACTIVE, GameObjectsStates.BARRIER);
                                    });
                                    _inactiveObjectsNumber = 0;
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
                                EndLevel();
                            }
                        }
                    }
                }
            });
        }

        private void CheckBarriersIntersections()
        {
            GameObject gameSquare = GameObjects[(int)GameObjectTypes.GAME_SQUARE];
            for (int i = 0; i < _barriers.Count; i++)
            {
                if (_barriers[i].State == GameObjectsStates.BARRIER)
                {
                    if (IsIntersection(Barriers[i], gameSquare))
                    {
                        EndLevel();
                    }
                }
            }
        }

        private void EndLevel()
        {
            Deaths++;
            Level = Level < 8 ? Level : Level - 1;
            StartNewLevel();
        }

        private double GetBarrierSpeed(BarrierType parBarrierType)
        {
            switch (parBarrierType)
            {
                case BarrierType.ARROW:
                    return ARROW_BARRIER_SPEED;
                case BarrierType.SHORT_SHOT:
                    return SHORT_BARRIER_SPEED;
                case BarrierType.LONG_SHOT:
                    return LONG_BARRIER_SPEED;
                default:
                    return 0;
            }
        }

        private void OnShortShotsTimerEvent(Object source, ElapsedEventArgs e)
        {
            if (HasHexagons)
            {
                GameObject gameSquare = GameObjects[(int)GameObjectTypes.GAME_SQUARE];
                foreach (GameObject elGameObject in GameObjects)
                {
                    if (elGameObject.ID == GameObjectTypes.HEXAGON
                        && (elGameObject.State == GameObjectsStates.BARRIER
                        || elGameObject.State == GameObjectsStates.FOOD))
                    {
                        _barriers.Add(new Barrier(BarrierType.SHORT_SHOT,
                            gameSquare.X, gameSquare.Y, 10, 10, elGameObject,
                            ScreenHeight, ScreenWidth));
                    }
                }
                OnBarriersChange?.Invoke();
            }
        }

        private void OnLongShotsTimerEvent(Object source, ElapsedEventArgs e)
        {
            if (HasTriangles)
            {
                GameObject gameSquare = GameObjects[(int)GameObjectTypes.GAME_SQUARE];
                foreach (GameObject elGameObject in GameObjects)
                {
                    if (elGameObject.ID == GameObjectTypes.TRIANGLE
                        && (elGameObject.State == GameObjectsStates.BARRIER
                        || elGameObject.State == GameObjectsStates.FOOD))
                    {
                        _barriers.Add(new Barrier(BarrierType.LONG_SHOT,
                            gameSquare.X, gameSquare.Y, 40, 40, elGameObject,
                            ScreenHeight, ScreenWidth));

                    }
                }
                OnBarriersChange?.Invoke();
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

        private void StartBarriers(GameObject parGameObject, GameObject parGameSquare)
        {
            if (parGameObject.ID == GameObjectTypes.RECTANGLE)
            {
                ((Rectangle)parGameObject).IsActiveMotion = true;
            }

            if (parGameObject.ID == GameObjectTypes.CIRCLE)
            {
                _barriers.Add(new Barrier(BarrierType.ARROW, parGameObject.X,
                    parGameSquare.Y, 25, 25, parGameObject));
                OnBarriersChange?.Invoke();
            }
        }

        private void StopBarrier(GameObject parParent)
        {
            _barriers.ForEach((elBarrier) =>
            {
                if (elBarrier.Parent.Equals(parParent))
                {
                    elBarrier.State = GameObjectsStates.INACTIVE;
                }
            });
        }

        private void StopBarrier(Barrier parBarrier)
        {
            parBarrier.State = GameObjectsStates.INACTIVE;
        }

        private void DeleteInactiveBarrier()
        {
            if (Barriers.FindAll(elBarrier => elBarrier.State == GameObjectsStates.INACTIVE).Count != 0)
            {
                _barriers.Remove(_barriers.Find(elBarrier => elBarrier.State == GameObjectsStates.INACTIVE));
                OnBarriersChange?.Invoke();
            }
        }

        private bool IsIntersection(GameObject parGameObject, GameObject parGameSquare)
        {
            return GetXIntersection(parGameObject.X, parGameSquare.X,
                            parGameSquare.Width / 2, parGameObject.Width / 2)
                        && GetYIntersection(parGameObject.Y, parGameSquare.Y,
                            parGameSquare.Height / 2, parGameObject.Height / 2);
        }

        private bool IsIntersection(Barrier parBarrier, GameObject parGameSquare)
        {
            return GetXIntersection(parBarrier.X, parGameSquare.X,
                            parGameSquare.Width / 2, parBarrier.Width / 2)
                        && GetYIntersection(parBarrier.Y, parGameSquare.Y,
                            parGameSquare.Height / 2, parBarrier.Height / 2);
        }

        private void StartNewLevel()
        {
            ((PermanentSquare)_gameObjects[(int)GameObjectTypes.PERMANENT_SQUARE])
                                .NeedNewPosition -= SetPermanentSquareCoordinates;
            Init();
            OnBarriersChange?.Invoke();
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
