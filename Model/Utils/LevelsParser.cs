using Model.Enums;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Utils
{
    public class LevelsParser
    {
        public static Dictionary<int, List<GameObject>> GetLevels(int parLevelsNumber)
        {
            Dictionary<int, List<GameObject>> levels = new Dictionary<int, List<GameObject>>();

            for (int i = 1; i <= parLevelsNumber; i++)
            {
                levels.Add(i, GetLevelFromFile(i));
            }

            return levels;
        }

        private static List<GameObject> GetLevelFromFile(int parLevelNumber)
        {
            List<string> fileContent = FileIO.FileReader(
                Properties.Resources.LevelsFilesPath
                + parLevelNumber + ".txt");

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
    }
}
