using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Enums;
using Model.Game;
using Model.Game.GameObjects;
using System;
using System.Linq;
using System.Threading;

namespace ToughtGrowthTest
{
    [TestClass]
    public class UnitToughGrowthTest
    {
        private const double TIME_COEFFICIENT = 0.001;
        private const int SCREEN_HEIGHT = 550;
        private const int SCREEN_WIDTH = 1000;
        private const int GAME_SQUARE_SPEED = 200;

        private static GameScreen _gameScreen = new GameScreen();

        private void InitGameScreen()
        {
            _gameScreen.StartNewLevel();
            _gameScreen.TimeCoefficient = TIME_COEFFICIENT;
            _gameScreen.ScreenHeight = SCREEN_HEIGHT;
            _gameScreen.ScreenWidth = SCREEN_WIDTH;
        }

        [TestMethod]
        public void TestGameSquareMotionUp()
        {
            InitGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y 
                - (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveUp((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        [TestMethod]
        public void TestGameSquareMotionDown()
        {
            InitGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y 
                + (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveDown((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        [TestMethod]
        public void TestGameSquareMotionLeft()
        {
            InitGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X 
                - (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveLeft((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        [TestMethod]
        public void TestGameSquareMotionRight()
        {
            InitGameScreen();
            double expectedValue = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X 
                + (TIME_COEFFICIENT * GAME_SQUARE_SPEED);
            _gameScreen.MoveRight((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();
            Assert.AreEqual(expectedValue, _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        [TestMethod]
        public void TestGameSquareGrowth()
        {
            InitGameScreen();

            double expectedArea = _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area
                                + _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Area;

            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X;
            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y;

            _gameScreen.CheckIntersections();
            Assert.AreEqual(expectedArea, ((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]).Area);
        }

        [TestMethod]
        public void TestGameObjectStateChangingFromInactiveToBarrier()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X;
            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y;

            _gameScreen.CheckIntersections();

            Assert.AreEqual(_gameScreen.GameObjects.Length - 2,
                _gameScreen.GameObjects.ToList().FindAll(x => x.State == GameObjectsStates.BARRIER).Count);
        }

        [TestMethod]
        public void TestPermanentSquareNewCoordinatesGeneration()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X;
            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y;

            double x = _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X;
            double y = _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y;

            _gameScreen.CheckIntersections();

            Assert.IsTrue(x != _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X
                    || y != _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y);
        }

        [TestMethod]
        public void TestGameSquareMotionUpBehindField()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = 0;

            _gameScreen.MoveUp((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(SCREEN_HEIGHT - TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        [TestMethod]
        public void TestGameSquareMotionDownBehindField()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y = SCREEN_HEIGHT;

            _gameScreen.MoveDown((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y);
        }

        [TestMethod]
        public void TestGameSquareMotionLeftBehindField()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = 0;

            _gameScreen.MoveLeft((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(SCREEN_WIDTH - TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        [TestMethod]
        public void TestGameSquareMotionRightBehindField()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X = SCREEN_WIDTH;

            _gameScreen.MoveRight((GameSquare)_gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE]);
            _gameScreen.Move();

            Assert.AreEqual(TIME_COEFFICIENT * GAME_SQUARE_SPEED,
                    _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X);
        }

        [TestMethod]
        public void TestGameObjectStatusChangingToFood()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X;
            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y;

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area =
                                        _gameScreen.GameObjects.Max(x => x.Area);

            _gameScreen.CheckIntersections();

            Assert.AreEqual(_gameScreen.GameObjects.Length - 1,
                _gameScreen.GameObjects.ToList().FindAll(x => x.State == GameObjectsStates.FOOD).Count);
        }

        [TestMethod]
        public void TestGameObjectStatusChangingToEaten()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X;
            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y;

            _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Area =
                                        _gameScreen.GameObjects.Max(x => x.Area);

            _gameScreen.CheckIntersections();

            foreach(GameObject elGameObject in _gameScreen.GameObjects)
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

        [TestMethod]
        public void TestDeathsIncreasing()
        {
            InitGameScreen();

            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].X =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].X;
            _gameScreen.GameObjects[(int)GameObjectTypes.PERMANENT_SQUARE].Y =
                _gameScreen.GameObjects[(int)GameObjectTypes.GAME_SQUARE].Y;

            _gameScreen.CheckIntersections();

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

            Assert.AreEqual(1, _gameScreen.Deaths);
        }
    }
}
