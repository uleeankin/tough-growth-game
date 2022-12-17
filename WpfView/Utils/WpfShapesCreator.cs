using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Model.Enums;
using Model.Game.GameObjects;

namespace WpfView.Utils
{
    public class WpfShapesCreator
    {
        private static readonly Brush GAME_SQUARE_COLOR = Brushes.Magenta;
        private static readonly Brush SQUARE_COLOR = Brushes.Red;
        private static readonly Brush HEXAGON_COLOR = Brushes.LightGreen;
        private static readonly Brush TRIANGLE_COLOR = Brushes.Orange;
        private static readonly Brush CIRCLE_COLOR = Brushes.LightSkyBlue;
        private static readonly Brush RECTANGLE_COLOR = Brushes.BlueViolet;
        private static readonly Brush BOUNDS_COLOR = Brushes.White;
        private static readonly Brush INACTIVE_EATEN_COLOR = Brushes.Black;
        private static readonly Brush EATEN_BOUNDS_COLOR = Brushes.Black;
        private static readonly Brush FOOD_STATE_COLOR = Brushes.Yellow;
        private static readonly int BOUNDS_THICKNESS = 3;

        public static Shape CreateGameObjectView(GameObject parGameObject)
        {
            Shape shape = null;
            if (parGameObject.ID == GameObjectTypes.GAME_SQUARE
                || parGameObject.ID == GameObjectTypes.PERMANENT_SQUARE
                || parGameObject.ID == GameObjectTypes.SQUARE
                || parGameObject.ID == GameObjectTypes.RECTANGLE)
            {
                shape = CreateRectangleGroup(parGameObject.Width,
                                                parGameObject.Height,
                                                parGameObject.X,
                                                parGameObject.Y);
                if (parGameObject.ID == GameObjectTypes.GAME_SQUARE)
                {
                    Canvas.SetZIndex(shape, 1);
                }
            }



            if (parGameObject.ID == GameObjectTypes.CIRCLE)
            {
                shape = CreateEllipseGroup(parGameObject.Width,
                                                parGameObject.Height,
                                                parGameObject.X,
                                                parGameObject.Y);
            }

            if (parGameObject.ID == GameObjectTypes.TRIANGLE)
            {
                shape = CreatePolygonGroup(GetTriangleVerticesCoordinates(
                    parGameObject.X, parGameObject.Y,
                    parGameObject.Height, parGameObject.Width));
            }

            if (parGameObject.ID == GameObjectTypes.HEXAGON)
            {
                shape = CreatePolygonGroup(GetHexagonVerticesCoordinates(
                    parGameObject.X, parGameObject.Y,
                    parGameObject.Height, parGameObject.Width));
            }

            SetColorByState(parGameObject.ID, parGameObject.State, shape);
            return shape;
        }

        private static Shape CreateRectangleGroup(double parWidth, double parHeight,
                                                    double parX, double parY)
        {
            Shape rectangle = new System.Windows.Shapes.Rectangle();
            rectangle.Width = parWidth;
            rectangle.Height = parHeight;
            rectangle.StrokeThickness = BOUNDS_THICKNESS;
            Canvas.SetTop(rectangle, parY - parHeight / 2);
            Canvas.SetLeft(rectangle, parX - parWidth / 2);
            return rectangle;
        }

        private static Shape CreatePolygonGroup(PointCollection parAnglesCoordinates)
        {
            Polygon polygon = new Polygon();
            polygon.Points = parAnglesCoordinates;
            polygon.StrokeThickness = BOUNDS_THICKNESS;
            return polygon;
        }

        private static PointCollection GetTriangleVerticesCoordinates(
            double parX, double parY, double parHeight, double parWeight)
        {
            PointCollection coordinates = new PointCollection();
            coordinates.Add(new Point(parX - parHeight / 3, parY - parWeight / 2));
            coordinates.Add(new Point(parX + (parHeight * 2 / 3), parY));
            coordinates.Add(new Point(parX - parHeight / 3, parY + parWeight / 2));
            return coordinates;
        }

        private static PointCollection GetHexagonVerticesCoordinates(
            double parX, double parY, double parHeight, double parWeight)
        {
            PointCollection coordinates = new PointCollection();
            coordinates.Add(new Point(parX - parWeight / 2, parY));
            coordinates.Add(new Point(parX - parWeight / 4, parY - parHeight / 2));
            coordinates.Add(new Point(parX + parWeight / 4, parY - parHeight / 2));
            coordinates.Add(new Point(parX + parWeight / 2, parY));
            coordinates.Add(new Point(parX + parWeight / 4, parY + parHeight / 2));
            coordinates.Add(new Point(parX - parWeight / 4, parY + parHeight / 2));
            return coordinates;
        }

        private static Shape CreateEllipseGroup(double parWidth, double parHeight,
                                                    double parX, double parY)
        {
            Shape ellipse = new Ellipse();
            ellipse.Width = parWidth;
            ellipse.Height = parHeight;
            ellipse.StrokeThickness = BOUNDS_THICKNESS;
            Canvas.SetTop(ellipse, parY - parHeight / 2);
            Canvas.SetLeft(ellipse, parX - parWidth / 2);
            return ellipse;
        }

        public static void SetColorByState(GameObjectTypes parObjectType,
            GameObjectsStates parState, Shape parShape)
        {
            if (parState == GameObjectsStates.INACTIVE)
            {
                parShape.Fill = INACTIVE_EATEN_COLOR;
                parShape.Stroke = BOUNDS_COLOR;
            }

            if (parState == GameObjectsStates.EATEN)
            {
                parShape.Fill = INACTIVE_EATEN_COLOR;
                parShape.Stroke = EATEN_BOUNDS_COLOR;
            }

            if (parState == GameObjectsStates.FOOD)
            {
                parShape.Fill = FOOD_STATE_COLOR;
                parShape.Stroke = BOUNDS_COLOR;
            }

            if (parState == GameObjectsStates.BARRIER)
            {
                switch (parObjectType)
                {
                    case GameObjectTypes.SQUARE:
                        parShape.Fill = SQUARE_COLOR;
                        parShape.Stroke = BOUNDS_COLOR;
                        break;
                    case GameObjectTypes.CIRCLE:
                        parShape.Fill = CIRCLE_COLOR;
                        parShape.Stroke = BOUNDS_COLOR;
                        break;
                    case GameObjectTypes.RECTANGLE:
                        parShape.Fill = RECTANGLE_COLOR;
                        parShape.Stroke = BOUNDS_COLOR;
                        break;
                    case GameObjectTypes.TRIANGLE:
                        parShape.Fill = TRIANGLE_COLOR;
                        parShape.Stroke = BOUNDS_COLOR;
                        break;
                    case GameObjectTypes.HEXAGON:
                        parShape.Fill = HEXAGON_COLOR;
                        parShape.Stroke = BOUNDS_COLOR;
                        break;
                }
            }

            if (parState == GameObjectsStates.NO_STATE
                && parObjectType == GameObjectTypes.GAME_SQUARE)
            {
                parShape.Fill = GAME_SQUARE_COLOR;
                parShape.Stroke = BOUNDS_COLOR;
            }
        }
    }
}
