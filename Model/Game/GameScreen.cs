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
    /// <summary>
    /// Окно игры
    /// </summary>
    public class GameScreen : Screen
    {
        /// <summary>
        /// Скорость игрового квадрата
        /// </summary>
        private const double PLAYER_SPEED = 200;
        /// <summary>
        /// Скорость прямоугольника
        /// </summary>
        private const double RECTANGLE_SPEED = 100;
        /// <summary>
        /// Скорость короткого выстрела
        /// </summary>
        private const double SHORT_BARRIER_SPEED = 150;
        /// <summary>
        /// Скорость длинного выстрела
        /// </summary>
        private const double LONG_BARRIER_SPEED = 50;
        /// <summary>
        /// Скорость преследующей стрелки
        /// </summary>
        private const double ARROW_BARRIER_SPEED = 70;
        /// <summary>
        /// Значение таймера для коротких выстрелов
        /// </summary>
        private const int SHORT_SHOT_TIMER = 2000;
        /// <summary>
        /// Значение таймера для длинных выстрелов
        /// </summary>
        private const int LONG_SHOT_TIMER = 3000;

        /// <summary>
        /// Общее количество уровней в игре
        /// </summary>
        private const int MAX_LEVELS_NUMBER = 10;

        /// <summary>
        /// Делегат на перерисовку окна
        /// </summary>
        public delegate void dNeedRedraw();
        /// <summary>
        /// Событие на перерисовку окна
        /// </summary>
        public event dNeedRedraw NeedRedraw = null;

        /// <summary>
        /// Делегат на завершение игры
        /// </summary>
        public delegate void dEndGame();
        /// <summary>
        /// Событие на завершение игры
        /// </summary>
        public event dEndGame EndGame = null;

        /// <summary>
        /// Делегат на изменение количества препятствий
        /// </summary>
        public delegate void dOnBarriersChange();
        /// <summary>
        /// Событие на изменение количества препятствий
        /// </summary>
        public event dOnBarriersChange OnBarriersChange = null;

        /// <summary>
        /// Определяет завершение / запуск игрового цикла
        /// </summary>
        private bool _isNeedStop = false;
        /// <summary>
        /// Временной коэффициент для передвижения объектов
        /// </summary>
        private double _timeCoefficient = 0;
        /// <summary>
        /// Количество неактивных объектов
        /// </summary>
        private volatile int _inactiveObjectsNumber = 0;
        /// <summary>
        /// Количество съеденных объектов
        /// </summary>
        private volatile int _eatenObjectsNumber = 0;

        /// <summary>
        /// Таймер на создание коротких выстрелов
        /// </summary>
        private System.Timers.Timer _shortBarrierTimer 
                = new System.Timers.Timer(SHORT_SHOT_TIMER);
        /// <summary>
        /// Таймер на создание длинных выстрелов
        /// </summary>
        private System.Timers.Timer _longBarrierTimer 
                = new System.Timers.Timer(LONG_SHOT_TIMER);

        /// <summary>
        /// Выдаваемые препятствия
        /// </summary>
        private volatile List<Barrier> _barriers = new List<Barrier>();

        /// <summary>
        /// Игровые объекты текущего уровня
        /// </summary>
        private List<GameObject> _gameObjects
            = new List<GameObject>();

        /// <summary>
        /// Игровые объекты всех уровней
        /// </summary>
        private Dictionary<int, List<GameObject>> _levelObjects
            = new Dictionary<int, List<GameObject>>();

        /// <summary>
        /// Текущий уровень
        /// </summary>
        private int _level = 1;

        /// <summary>
        /// Список игровых объектов, требующих перерисовки
        /// </summary>
        private List<GameObject> _gameObjectsNeedRedrawing =
            new List<GameObject>();

        /// <summary>
        /// Список препятствий, требующих перерисовки
        /// </summary>
        private List<Barrier> _barriersNeedRedrawing =
            new List<Barrier>();

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public double ScreenHeight { get; set; }
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public double ScreenWidth { get; set; }

        /// <summary>
        /// Наличие шестиугольников на уровне
        /// </summary>
        public bool HasHexagons { get; set; }
        /// <summary>
        /// Наличие треугольников на уровне
        /// </summary>
        public bool HasTriangles { get; set; }

        /// <summary>
        /// Таймер на создание коротких выстрелов
        /// </summary>
        public System.Timers.Timer ShortBarrierTimer
        {
            get
            {
                return _shortBarrierTimer;
            }
        }

        /// <summary>
        /// Таймер на создание длинных выстрелов
        /// </summary>
        public System.Timers.Timer LongBarrierTimer
        {
            get
            {
                return _longBarrierTimer;
            }
        }

        /// <summary>
        /// Выдаваемые препятствия
        /// </summary>
        public List<Barrier> Barriers
        {
            get
            {
                return _barriers;
            }
        }

        /// <summary>
        /// Текущий уровень
        /// </summary>
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

        /// <summary>
        /// Игровые объекты текущего уровня
        /// </summary>
        public GameObject[] GameObjects
        {
            get
            {
                return _gameObjects.ToArray();
            }
        }

        /// <summary>
        /// Возвращает все объекта заданного типа
        /// </summary>
        /// <param name="parId">Код типа</param>
        /// <returns>Все объекты заданного типа</returns>
        public List<GameObject> this[int parId]
        {
            get
            {
                return _gameObjects.FindAll((x) => (int)x.ID == parId);
            }
        }

        /// <summary>
        /// Количество смертей
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        /// Временной коэффициент для движения объектов
        /// </summary>
        public double TimeCoefficient
        {
            get
            {
                return _timeCoefficient;
            }
            set
            {
                _timeCoefficient = value;
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameScreen() : base()
        {
            _levelObjects = LevelsParser.GetLevels(10);
            Init();
            InitTimers();
        }

        /// <summary>
        /// Инициализация уровня
        /// </summary>
        private void Init()
        {
            if (Level > MAX_LEVELS_NUMBER)
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

        /// <summary>
        /// Инициализация таймеров
        /// </summary>
        private void InitTimers()
        {
            _shortBarrierTimer.AutoReset = true;
            _shortBarrierTimer.Elapsed += OnShortShotsTimerEvent;
            _longBarrierTimer.AutoReset = true;
            _longBarrierTimer.Elapsed += OnLongShotsTimerEvent;

        }

        /// <summary>
        /// Обработчик события генерации новых координат для 
        /// постоянного съедобного квадрата
        /// </summary>
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

            lock(_gameObjectsNeedRedrawing)
            {
                _gameObjectsNeedRedrawing.Add(GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE]);
            }
        }

        /// <summary>
        /// Запускает игровой цикл
        /// </summary>
        public void StartGame()
        {
            _shortBarrierTimer.Enabled = true;
            _longBarrierTimer.Enabled = true;
            _isNeedStop = false;
            if (_level == 1 || _level > MAX_LEVELS_NUMBER)
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
                timer.Stop();
            }).Start();
        }

        /// <summary>
        /// Останавливает игровой цикл
        /// </summary>
        public void StopGame()
        {
            _shortBarrierTimer.Enabled = false;
            _longBarrierTimer.Enabled = false;
            _isNeedStop = true;
        }

        /// <summary>
        /// Перемещает все объекты
        /// </summary>
        public void Move()
        {
            GameSquare gameSquare = ((GameSquare)_gameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            gameSquare.MoveByStep(PLAYER_SPEED * _timeCoefficient, ScreenHeight, ScreenWidth);
            _gameObjectsNeedRedrawing.Add(gameSquare);

            Parallel.ForEach(GameObjects, elGameObject => {
                if (elGameObject.ID == GameObjectTypes.RECTANGLE)
                {
                    ((Rectangle)elGameObject).MoveByStep(RECTANGLE_SPEED * _timeCoefficient);
                    lock(_gameObjectsNeedRedrawing)
                    {
                        _gameObjectsNeedRedrawing.Add(elGameObject);
                    }
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
                lock(_barriersNeedRedrawing)
                {
                    _barriersNeedRedrawing.Add(elBarrier);
                }
            }

            CheckIntersections();
            CheckBarriersIntersections();
            DeleteInactiveBarrier();
            RedrawAll();
        }

        /// <summary>
        /// Вызывает события перерисовки всех объектов на игровом поле
        /// </summary>
        private void RedrawAll()
        {
            foreach(GameObject elGameObject in _gameObjectsNeedRedrawing) {
                elGameObject.RedrawGameObject();
            }

            foreach(Barrier elBarrier in _barriersNeedRedrawing)
            {
                elBarrier.RedrawBarrier();
            }

            _gameObjectsNeedRedrawing.Clear();
            _barriersNeedRedrawing.Clear();
        }

        /// <summary>
        /// Проверяет пересечение игрового квадрата с другими игровыми объектами
        /// </summary>
        public void CheckIntersections()
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
                                SetNewState(elGameObject, 
                                    GameObjectsStates.FOOD, 
                                    GameObjectsStates.EATEN);

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

        /// <summary>
        /// Проверяет пересечение игрового квадрата с препятствиями
        /// </summary>
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

        /// <summary>
        /// Заканчивает уровень
        /// </summary>
        private void EndLevel()
        {
            Deaths++;
            Level = Level < MAX_LEVELS_NUMBER - 2 ? Level : Level - 1;
            StartNewLevel();
        }

        /// <summary>
        /// Возвращает скорость препятствия по его типу
        /// </summary>
        /// <param name="parBarrierType">Тип препятствия</param>
        /// <returns>Скорость препятствия</returns>
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

        /// <summary>
        /// Обработчик события таймера на создание коротких выстрелов
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Обработчик события таймера на создание длинных выстрелов
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Устанавливает новое состояние для игрового объекта
        /// </summary>
        /// <param name="parObject">Игровой объект</param>
        /// <param name="parCurrentState">Текущее состояние</param>
        /// <param name="parNewState">Новое состояние</param>
        private void SetNewState(GameObject parObject,
                                GameObjectsStates parCurrentState,
                                GameObjectsStates parNewState)
        {
            if (parObject.State == parCurrentState)
            {
                parObject.State = parNewState;
                lock (_gameObjectsNeedRedrawing)
                {
                    _gameObjectsNeedRedrawing.Add(parObject);
                }
            }
        }

        /// <summary>
        /// Запускает работу препятствий, не зависящих от таймера
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        /// <param name="parGameSquare">Игровой квадрат</param>
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

        /// <summary>
        /// Останавливает работу препятствия, если родитель был съеден
        /// </summary>
        /// <param name="parParent">Родитель препятствия</param>
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

        /// <summary>
        /// Останавливает работу препятствия, 
        /// находящегося за пределами игрового поля
        /// </summary>
        /// <param name="parBarrier">Препятствие</param>
        private void StopBarrier(Barrier parBarrier)
        {
            parBarrier.State = GameObjectsStates.INACTIVE;
        }

        /// <summary>
        /// Удаляет неактивные препятствия из списка препятствий
        /// </summary>
        private void DeleteInactiveBarrier()
        {
            if (Barriers.FindAll(elBarrier => elBarrier.State == GameObjectsStates.INACTIVE).Count != 0)
            {
                _barriers.Remove(_barriers.Find(elBarrier => elBarrier.State == GameObjectsStates.INACTIVE));
                OnBarriersChange?.Invoke();
            }
        }

        /// <summary>
        /// Проверяет пересечение игрового объекта и игрового квадрата
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        /// <param name="parGameSquare">Игровой квадрат</param>
        /// <returns>Наличие пересечения</returns>
        private bool IsIntersection(GameObject parGameObject, GameObject parGameSquare)
        {
            return GetXIntersection(parGameObject.X, parGameSquare.X,
                            parGameSquare.Width / 2, parGameObject.Width / 2)
                        && GetYIntersection(parGameObject.Y, parGameSquare.Y,
                            parGameSquare.Height / 2, parGameObject.Height / 2);
        }

        /// <summary>
        /// Проверяет пересечение препятствия и игрового квадрата
        /// </summary>
        /// <param name="parBarrier">Препятствие</param>
        /// <param name="parGameSquare">Игровой квадрат</param>
        /// <returns></returns>
        private bool IsIntersection(Barrier parBarrier, GameObject parGameSquare)
        {
            return GetXIntersection(parBarrier.X, parGameSquare.X,
                            parGameSquare.Width / 2, parBarrier.Width / 2)
                        && GetYIntersection(parBarrier.Y, parGameSquare.Y,
                            parGameSquare.Height / 2, parBarrier.Height / 2);
        }

        /// <summary>
        /// Начинает новый уровень
        /// </summary>
        public void StartNewLevel()
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

        /// <summary>
        /// Проверяет пересечение по координате X
        /// </summary>
        /// <param name="parObjectX">Координата X объекта</param>
        /// <param name="parGameSquareX">Координата X игрового квадрата</param>
        /// <param name="parGameSquareDelta">Погрешность</param>
        /// <param name="parObjectDelta">Погрешность</param>
        /// <returns>Наличие пересечения</returns>
        private bool GetXIntersection(double parObjectX, double parGameSquareX,
            double parGameSquareDelta, double parObjectDelta)
        {
            return ((parGameSquareX - parGameSquareDelta) < (parObjectX + parObjectDelta)
                && (parObjectX - parObjectDelta) < (parGameSquareX + parGameSquareDelta));
        }

        /// <summary>
        /// Проверяет пересечение по координате Y
        /// </summary>
        /// <param name="parObjectY">Координата Y объекта</param>
        /// <param name="parGameSquareY">Координата Y игрового квадрата</param>
        /// <param name="parGameSquareDelta">Погрешность</param>
        /// <param name="parObjectDelta">Погрешность</param>
        /// <returns>Наличие пересечения</returns>
        private bool GetYIntersection(double parObjectY, double parGameSquareY,
            double parGameSquareDelta, double parObjectDelta)
        {
            return ((parGameSquareY - parGameSquareDelta) < (parObjectY + parObjectDelta)
                && (parObjectY - parObjectDelta) < (parGameSquareY + parGameSquareDelta));
        }

        /// <summary>
        /// Задает движение вверх игровому квадрату
        /// </summary>
        /// <param name="parGameSquare">Игровой квадрат</param>
        public void MoveUp(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.UP;
        }

        /// <summary>
        /// Задает движение вниз игровому квадрату
        /// </summary>
        /// <param name="parGameSquare">Игровой квадрат</param>
        public void MoveDown(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.DOWN;
        }

        /// <summary>
        /// Задает движение влево игровому квадрату
        /// </summary>
        /// <param name="parGameSquare">Игровой квадрат</param>
        public void MoveLeft(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.LEFT;
        }

        /// <summary>
        /// Задает движение вправо игровому квадрату
        /// </summary>
        /// <param name="parGameSquare">Игровой квадрат</param>
        public void MoveRight(GameSquare parGameSquare)
        {
            parGameSquare.MotionDirection = MotionType.RIGHT;
        }
    }
}
