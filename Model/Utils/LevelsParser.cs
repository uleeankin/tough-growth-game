﻿using Model.Enums;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model.Utils
{
    public class LevelsParser
    {

        private static volatile Dictionary<int, List<GameObject>> _levels 
                                        = new Dictionary<int, List<GameObject>>();
        private static volatile Dictionary<int, string> _levelsDescription 
                                        = GetLevelsDescription();

        private static List<Thread> _threads = new List<Thread>();

        private static int _levelNumber = 1;
        private static Object _locker = new Object();

        public static Dictionary<int, List<GameObject>> GetLevels(int parLevelsNumber)
        {

            for (int i = 1; i <= parLevelsNumber; i++)
            {
                _threads.Add(new Thread(() =>
                {
                    AddLevel();
                }));
            }

            _threads.ForEach(elThread => elThread.Start());
            _threads.ForEach(elThread => elThread.Join());
            return _levels;
        }

        private static void AddLevel()
        {
            lock(_locker)
            {
                _levels.Add(_levelNumber, GetLevel(_levelsDescription[_levelNumber]));
                _levelNumber++;
            }
        }

        private static List<GameObject> GetLevel(string parLevelString)
        {
            List<string> fileContent = parLevelString.Split('\n').ToList();

            List<GameObject> gameObjects = new List<GameObject>();

            foreach (string line in fileContent)
            {
                gameObjects.Add(GetObject(line));
            }

            return gameObjects;
        }

        private static GameObject GetObject(string parDescription)
        {
            GameObject gameObject = null;

            List<string> data = parDescription.Split(' ').ToList();

            GameObjectTypes gameObjectType = GetObjectType(data[0]);
            Tuple<double, double> coordinates = GetCoordinates(data[1]);
            double area = Double.Parse(data[2]);

            switch (gameObjectType)
            {
                case GameObjectTypes.GAME_SQUARE:
                    return new GameSquare(
                        gameObjectType, data[0],
                        coordinates.Item1, coordinates.Item2, area);
                case GameObjectTypes.PERMANENT_SQUARE:
                    return new PermanentSquare(
                        gameObjectType, data[0],
                        coordinates.Item1, coordinates.Item2, area);
                case GameObjectTypes.SQUARE:
                    return new Square(
                        gameObjectType, data[0],
                        coordinates.Item1, coordinates.Item2, area);
                case GameObjectTypes.CIRCLE:
                    return new Circle(
                        gameObjectType, data[0],
                        coordinates.Item1, coordinates.Item2, area);
                case GameObjectTypes.RECTANGLE:
                    Rectangle rectangle = new Rectangle(
                        gameObjectType, data[0],
                        coordinates.Item1, coordinates.Item2, area);
                    Tuple<double, double> startCoordinates = GetCoordinates(data[3]);
                    Tuple<double, double> endCoordinates = GetCoordinates(data[4]);
                    rectangle.StartX = startCoordinates.Item1;
                    rectangle.StartY = startCoordinates.Item2;
                    rectangle.EndX = endCoordinates.Item1;
                    rectangle.EndY = endCoordinates.Item2;
                    rectangle.Orientation = int.Parse(data[5]);
                    return rectangle;
                case GameObjectTypes.TRIANGLE:
                    return new Triangle(
                        gameObjectType, data[0],
                        coordinates.Item1, coordinates.Item2, area);
                case GameObjectTypes.HEXAGON:
                    return new Hexagon(
                        gameObjectType, data[0],
                        coordinates.Item1, coordinates.Item2, area);

            }

            return gameObject;
        }

        private static GameObjectTypes GetObjectType(string parStringType)
        {
            switch (parStringType)
            {
                case "ИК":
                    return GameObjectTypes.GAME_SQUARE;
                case "ПСК":
                    return GameObjectTypes.PERMANENT_SQUARE;
                case "КВ":
                    return GameObjectTypes.SQUARE;
                case "Ш":
                    return GameObjectTypes.HEXAGON;
                case "КР":
                    return GameObjectTypes.CIRCLE;
                case "П":
                    return GameObjectTypes.RECTANGLE;
                case "Т":
                    return GameObjectTypes.TRIANGLE;
                default:
                    return GameObjectTypes.SQUARE;
            }
        }

        private static Tuple<double, double> GetCoordinates(string parCoordinates)
        {
            List<string> coordinatesList = parCoordinates.Substring(1, parCoordinates.Length - 2).Split(';').ToList();

            return new Tuple<double, double>(Double.Parse(coordinatesList[0]),
                                            Double.Parse(coordinatesList[1]));
        }

        private static Dictionary<int, string> GetLevelsDescription()
        {
            Dictionary<int, string> levels = new Dictionary<int, string>();

            levels.Add(1, Properties.Resources.Level1);
            levels.Add(2, Properties.Resources.Level2);
            levels.Add(3, Properties.Resources.Level3);
            levels.Add(4, Properties.Resources.Level4);
            levels.Add(5, Properties.Resources.Level5);
            levels.Add(6, Properties.Resources.Level6);
            levels.Add(7, Properties.Resources.Level7);
            levels.Add(8, Properties.Resources.Level8);
            levels.Add(9, Properties.Resources.Level9);
            levels.Add(10, Properties.Resources.Level10);

            return levels;
        }
    }
}
