using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Enums;
using Model.Game;
using Model.Game.GameObjects;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ToughtGrowthTest
{
    /// <summary>
    /// ����� ������ ��� ������������ ������ GameScreen
    /// </summary>
    [TestClass]
    public class UnitToughGrowthTest
    {
        /// <summary>
        /// ��������� ����������� ��� ����������� ���� ������� ��������
        /// </summary>
        private const double TIME_COEFFICIENT = 0.001;
        /// <summary>
        /// ������ ����
        /// </summary>
        private const int SCREEN_HEIGHT = 550;
        /// <summary>
        /// ������ ����
        /// </summary>
        private const int SCREEN_WIDTH = 1000;
        /// <summary>
        /// �������� �������� ��������
        /// </summary>
        private const int GAME_SQUARE_SPEED = 200;
        /// <summary>
        /// �������� ������� ��� �������� ���������
        /// </summary>
        private const int SHORT_SHOT_TIMER = 2500;
        /// <summary>
        /// �������� ������� ��� ������� ���������
        /// </summary>
        private const int LONG_SHOT_TIMER = 3500;

        /// <summary>
        /// ����������� �����, ��������������� ������ �������� ��������
        /// </summary>
        private static GameScreen _gameScreen = new GameScreen();

        /// <summary>
        /// ����������� ���� �� 1 ������
        /// </summary>
        private void InitFirstLevelGameScreen()
        {
            _gameScreen.Level = 1;
            _gameScreen.StartNewLevel();
            _gameScreen.TimeCoefficient = TIME_COEFFICIENT;
            _gameScreen.ScreenHeight = SCREEN_HEIGHT;
            _gameScreen.ScreenWidth = SCREEN_WIDTH;
            _gameScreen.Deaths = 0;
        }

        /// <summary>
        /// ����������� ���� �� 8 �������
        /// </summary>
        private void InitEightLevelGameScreen()
        {
            _gameScreen.Level = 8;
            _gameScreen.StartNewLevel();
            _gameScreen.TimeCoefficient = TIME_COEFFICIENT;
            _gameScreen.ScreenHeight = SCREEN_HEIGHT;
            _gameScreen.ScreenWidth = SCREEN_WIDTH;
            _gameScreen.Deaths = 0;
        }

        /// <summary>
        /// ����������� ���� �� 2 �������
        /// </summary>
        private void InitSecondLevelGameScreen()
        {
            _gameScreen.Level = 2;
            _gameScreen.StartNewLevel();
            _gameScreen.TimeCoefficient = TIME_COEFFICIENT;
            _gameScreen.ScreenHeight = SCREEN_HEIGHT;
            _gameScreen.ScreenWidth = SCREEN_WIDTH;
            _gameScreen.Deaths = 0;
        }

        /// <summary>
        /// ����������� ���� �� 3 �������
        /// </summary>
        private void InitThirdLevelGameScreen()
        {
            _gameScreen.Level = 3;
            _gameScreen.StartNewLevel();
            _gameScreen.TimeCoefficient = TIME_COEFFICIENT;
            _gameScreen.ScreenHeight = SCREEN_HEIGHT;
            _gameScreen.ScreenWidth = SCREEN_WIDTH;
            _gameScreen.Deaths = 0;
        }

        /// <summary>
        /// ����������� ���� �� 7 �������
        /// </summary>
        private void InitSevenLevelGameScreen()
        {
            _gameScreen.Level = 7;
            _gameScreen.StartNewLevel();
            _gameScreen.TimeCoefficient = TIME_COEFFICIENT;
            _gameScreen.ScreenHeight = SCREEN_HEIGHT;
            _gameScreen.ScreenWidth = SCREEN_WIDTH;
            _gameScreen.Deaths = 0;
        }

        /// <summary>
        /// ������������� ���������� �������� �������� �� ���������� ��������� �������,
        /// ����� ��������� ������ ������� ������� �� ���� � �������� ���������
        /// </summary>
        private void ActivateGameObjects()
        {
            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X =
                _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X;
            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y =
                _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y;
        }

        /// <summary>
        /// ��������� �������� �������� �������� �����
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionUp()
        {
            InitFirstLevelGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y 
                - (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveUp((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        /// <summary>
        /// ��������� �������� �������� �������� ����
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionDown()
        {
            InitFirstLevelGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y 
                + (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveDown((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        /// <summary>
        /// ��������� �������� �������� �������� �����
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionLeft()
        {
            InitFirstLevelGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X 
                - (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveLeft((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        /// <summary>
        /// ��������� �������� �������� �������� ������
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionRight()
        {
            InitFirstLevelGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X 
                + (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveRight((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        /// <summary>
        /// ��������� ���� �������� �������� ��� ��������
        /// </summary>
        [TestMethod]
        public void TestGameSquareGrowth()
        {
            InitFirstLevelGameScreen();

            double expectedArea = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area
                                + _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Area;

            ActivateGameObjects();
            _gameScreen.CheckIntersections();

            Assert.AreEqual(expectedArea, ((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]).Area);
        }

        /// <summary>
        /// ��������� ������� ���� ������� �������� � ��������� �����������
        /// ��� ������ �������� ����������� �������� ��������
        /// </summary>
        [TestMethod]
        public void TestGameObjectStateChangingFromInactiveToBarrier()
        {
            InitFirstLevelGameScreen();

            ActivateGameObjects();
            _gameScreen.CheckIntersections();

            Assert.AreEqual(_gameScreen.GameObjects.Length - 2,
                _gameScreen.GameObjects.ToList().FindAll(x => x.State == GameObjectsStates.BARRIER).Count);
        }

        /// <summary>
        /// ��������� ��������� ����������� ���������� �������� � ����� ����� ��� ��� ��������
        /// </summary>
        [TestMethod]
        public void TestPermanentSquareNewCoordinatesGeneration()
        {
            InitFirstLevelGameScreen();

            ActivateGameObjects();

            double x = _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X;
            double y = _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y;

            _gameScreen.CheckIntersections();

            Assert.IsTrue(x != _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X
                    || y != _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y);
        }

        /// <summary>
        /// ��������� �������� �������� �������� ����� �� ������� ����
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionUpBehindField()
        {
            InitFirstLevelGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = 0;

            _gameScreen.MoveUp((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(SCREEN_HEIGHT - TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        /// <summary>
        /// ��������� �������� �������� �������� ���� �� ������� ����
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionDownBehindField()
        {
            InitFirstLevelGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = SCREEN_HEIGHT;

            _gameScreen.MoveDown((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        /// <summary>
        /// ��������� �������� �������� �������� ����� �� ������� ����
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionLeftBehindField()
        {
            InitFirstLevelGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = 0;

            _gameScreen.MoveLeft((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(SCREEN_WIDTH - TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        /// <summary>
        /// ��������� �������� �������� �������� ������ �� ������� ����
        /// </summary>
        [TestMethod]
        public void TestGameSquareMotionRightBehindField()
        {
            InitFirstLevelGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = SCREEN_WIDTH;

            _gameScreen.MoveRight((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        /// <summary>
        /// ��������� ��������� ��������� ������� �������� � ��������� ���
        /// ��� ������� �������� �������� ������� ������� ��������� ��������
        /// </summary>
        [TestMethod]
        public void TestGameObjectStatusChangingToFood()
        {
            InitFirstLevelGameScreen();

            ActivateGameObjects();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area =
                                        _gameScreen.GameObjects.Max(x => x.Area);

            _gameScreen.CheckIntersections();

            Assert.AreEqual(_gameScreen.GameObjects.Length - 1,
                _gameScreen.GameObjects.ToList().FindAll(x => x.State == GameObjectsStates.FOOD).Count);
        }

        /// <summary>
        /// ��������� ��������� ��������� ������� �������� � ��������� ������
        /// ��� ����������� �� � ������� ���������
        /// </summary>
        [TestMethod]
        public void TestGameObjectStatusChangingToEaten()
        {
            InitFirstLevelGameScreen();

            ActivateGameObjects();

            _gameScreen.CheckIntersections();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area =
                                        _gameScreen.GameObjects.Max(x => x.Area);

            foreach (GameObject elGameObject in _gameScreen.GameObjects)
            {
                if (elGameObject.ID != GameObjectTypes.GAME_SQUARE
                    || elGameObject.ID != GameObjectTypes.PERMANENT_SQUARE)
                {
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = elGameObject.X;
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = elGameObject.Y;
                    _gameScreen.CheckIntersections();
                }
            }

            Assert.AreEqual(_gameScreen.GameObjects.Length - 2,
                _gameScreen.GameObjects.ToList().FindAll(x => x.State == GameObjectsStates.EATEN).Count);
        }

        /// <summary>
        /// ��������� ���������� ���������� ������� ��� �����������
        /// ������� ��������� ������� � ��������� ����������� � ������� ��������
        /// </summary>
        [TestMethod]
        public void TestDeathsIncreasing()
        {
            InitFirstLevelGameScreen();

            ActivateGameObjects();

            _gameScreen.CheckIntersections();


            GameObject fieldGameObject = _gameScreen.GameObjects.ToList().Find(
                x => x.ID != GameObjectTypes.GAME_SQUARE && x.ID != GameObjectTypes.PERMANENT_SQUARE);

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = fieldGameObject.X;
            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = fieldGameObject.Y;
            _gameScreen.CheckIntersections();

            Assert.AreEqual(1, _gameScreen.Deaths);
        }

        /// <summary>
        /// ��������� ������� �� ��������� �������
        /// </summary>
        [TestMethod]
        public void TestSwichingToNextLevel()
        {
            InitFirstLevelGameScreen();

            ActivateGameObjects();

            _gameScreen.CheckIntersections();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area =
                                        _gameScreen.GameObjects.Max(x => x.Area);

            foreach (GameObject elGameObject in _gameScreen.GameObjects)
            {
                if (elGameObject.ID != GameObjectTypes.GAME_SQUARE
                    || elGameObject.ID != GameObjectTypes.PERMANENT_SQUARE)
                {
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = elGameObject.X;
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = elGameObject.Y;
                    _gameScreen.CheckIntersections();
                }
            }

            ActivateGameObjects();

            _gameScreen.CheckIntersections();

            Assert.AreEqual(2, _gameScreen.Level);
        }

        /// <summary>
        /// ��������� ������� �� ���������� �������
        /// (��������� � ������ ������ �������� �������� �� 8 ������ � ������)
        /// </summary>
        [TestMethod]
        public void TestSwichingPreviousLevel()
        {
            InitEightLevelGameScreen();

            int expectedValue = _gameScreen.Level - 1;

            ActivateGameObjects();

            _gameScreen.CheckIntersections();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area =
                                        _gameScreen.GameObjects.Min(x => x.Area);

            GameObject fieldGameObject = _gameScreen.GameObjects.ToList().Find(
                x => x.State == GameObjectsStates.BARRIER);

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = fieldGameObject.X;
            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = fieldGameObject.Y;
            _gameScreen.CheckIntersections();

            Assert.AreEqual(expectedValue, _gameScreen.Level);
        }

        /// <summary>
        /// ��������� ������ �������� ������ ��� ������ �������� ��������
        /// ������, ��� �� 8 ������
        /// </summary>
        [TestMethod]
        public void TestStartingCurrentLevel()
        {
            InitFirstLevelGameScreen();

            int expectedValue = _gameScreen.GameObjects.ToList()
                .FindAll(x => x.State == GameObjectsStates.INACTIVE).Count;

            ActivateGameObjects();
            _gameScreen.CheckIntersections();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area =
                                        _gameScreen.GameObjects.Min(x => x.Area);

            GameObject fieldGameObject = _gameScreen.GameObjects.ToList().Find(
                x => x.ID != GameObjectTypes.GAME_SQUARE && x.ID != GameObjectTypes.PERMANENT_SQUARE);

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = fieldGameObject.X;
            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = fieldGameObject.Y;
            _gameScreen.CheckIntersections();

            Assert.AreEqual(expectedValue,
                _gameScreen.GameObjects.ToList()
                    .FindAll(x => x.State == GameObjectsStates.INACTIVE).Count);
        }

        /// <summary>
        /// ��������� ��������� �����������, ������������� ������
        /// </summary>
        [TestMethod]
        public void TestArrowBarrierGenerating()
        {
            InitThirdLevelGameScreen();
            ActivateGameObjects();
            _gameScreen.CheckIntersections();

            Assert.IsTrue(_gameScreen.Barriers.Count == 1 
                && _gameScreen.Barriers[0].ID == BarrierType.ARROW);
        }

        /// <summary>
        /// ��������� ��������� �����������, ������������� ���������������
        /// </summary>
        [TestMethod]
        public void TestShortBarrierGenerating()
        {
            InitSecondLevelGameScreen();
            ActivateGameObjects();
            _gameScreen.CheckIntersections();
            _gameScreen.HasHexagons = true;
            _gameScreen.ShortBarrierTimer.Enabled = true;
            Thread.Sleep(SHORT_SHOT_TIMER);
            Assert.IsTrue(_gameScreen.Barriers.Count == 1
                && _gameScreen.Barriers[0].ID == BarrierType.SHORT_SHOT);
            _gameScreen.ShortBarrierTimer.Enabled = false;
            _gameScreen.HasHexagons = false;
        }

        /// <summary>
        /// ��������� ��������� �����������, ������������� �������������
        /// </summary>
        [TestMethod]
        public void TestLongShotBarrierGenerating()
        {
            InitSevenLevelGameScreen();
            ActivateGameObjects();
            _gameScreen.CheckIntersections();
            _gameScreen.HasTriangles = true;
            _gameScreen.LongBarrierTimer.Enabled = true;
            Thread.Sleep(LONG_SHOT_TIMER);
            Assert.IsTrue(_gameScreen.Barriers.ToList()
                    .FindAll(x => x.ID == BarrierType.LONG_SHOT).Count ==
                _gameScreen.GameObjects.ToList()
                    .FindAll(x => x.ID == GameObjectTypes.TRIANGLE).Count);
            _gameScreen.LongBarrierTimer.Enabled = false;
            _gameScreen.HasTriangles = false;
        }
    }
}
