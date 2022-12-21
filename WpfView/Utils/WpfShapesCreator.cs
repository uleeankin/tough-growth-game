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
    /// <summary>
    /// Создает графические фигуры для игры
    /// </summary>
    public class WpfShapesCreator
    {
        /// <summary>
        /// Цвет игрового квадрата
        /// </summary>
        private static readonly Brush GAME_SQUARE_COLOR = Brushes.Magenta;

        /// <summary>
        /// Цвет квадрата в состоянии препятствия
        /// </summary>
        private static readonly Brush SQUARE_COLOR = Brushes.Red;

        /// <summary>
        /// Цвет шестиугольника в состоянии препятствия
        /// </summary>
        private static readonly Brush HEXAGON_COLOR = Brushes.LightGreen;

        /// <summary>
        /// Цвет треугольника в состоянии препятствия
        /// </summary>
        private static readonly Brush TRIANGLE_COLOR = Brushes.Orange;

        /// <summary>
        /// Цвет круга в состоянии препятствия
        /// </summary>
        private static readonly Brush CIRCLE_COLOR = Brushes.LightSkyBlue;

        /// <summary>
        /// Цвет прямоугольника в состоянии препятствия
        /// </summary>
        private static readonly Brush RECTANGLE_COLOR = Brushes.BlueViolet;

        /// <summary>
        /// Цвет границ фигур
        /// </summary>
        private static readonly Brush BOUNDS_COLOR = Brushes.White;

        /// <summary>
        /// Цвет игровых объектов в съеденном или неактивном состоянии
        /// </summary>
        private static readonly Brush INACTIVE_EATEN_COLOR = Brushes.Black;

        /// <summary>
        /// Цвет границ съеденных фигур
        /// </summary>
        private static readonly Brush EATEN_BOUNDS_COLOR = Brushes.Black;

        /// <summary>
        /// Цвет фигуры, доступной для съедения
        /// </summary>
        private static readonly Brush FOOD_STATE_COLOR = Brushes.Yellow;

        /// <summary>
        /// Толщина границ фигур
        /// </summary>
        private static readonly int BOUNDS_THICKNESS = 3;

        /// <summary>
        /// Создаёт представление игрового объекта
        /// </summary>
        /// <param name="parGameObject">Модель игрового объекта</param>
        /// <returns>Фигура игрового объекта</returns>
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

        /// <summary>
        /// Создает фигуры относящиеся к прямоугольникам
        /// </summary>
        /// <param name="parWidth">Ширина</param>
        /// <param name="parHeight">Высота</param>
        /// <param name="parX">Координата X центра</param>
        /// <param name="parY">Координата Y центра</param>
        /// <returns></returns>
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

        /// <summary>
        /// Создает фигуры относящиеся к многоугольникам
        /// </summary>
        /// <param name="parAnglesCoordinates">Координаты углов многоугольника</param>
        /// <returns></returns>
        private static Shape CreatePolygonGroup(PointCollection parAnglesCoordinates)
        {
            Polygon polygon = new Polygon();
            polygon.Points = parAnglesCoordinates;
            polygon.StrokeThickness = BOUNDS_THICKNESS;
            return polygon;
        }

        /// <summary>
        /// Вычисляет координаты вершин труегольника по координатам центра
        /// </summary>
        /// <param name="parX">Координата X центра</param>
        /// <param name="parY">Координата Y центра</param>
        /// <param name="parHeight">Высота</param>
        /// <param name="parWeight">Ширина</param>
        /// <returns>Координаты вершин треугольника</returns>
        private static PointCollection GetTriangleVerticesCoordinates(
            double parX, double parY, double parHeight, double parWeight)
        {
            PointCollection coordinates = new PointCollection();
            coordinates.Add(new Point(parX - parHeight / 3, parY - parWeight / 2));
            coordinates.Add(new Point(parX + (parHeight * 2 / 3), parY));
            coordinates.Add(new Point(parX - parHeight / 3, parY + parWeight / 2));
            return coordinates;
        }

        /// <summary>
        /// Вычисляет координаты вершин шестиугольника по координатам центра
        /// </summary>
        /// <param name="parX">Координата X центра</param>
        /// <param name="parY">Координата Y центра</param>
        /// <param name="parHeight">Высота</param>
        /// <param name="parWeight">Ширина</param>
        /// <returns>Координаты вершин шестиугольника</returns>
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

        /// <summary>
        /// Создает фигуры относящиеся к эллипсам
        /// </summary>
        /// <param name="parWidth">Ширина</param>
        /// <param name="parHeight">Высота</param>
        /// <param name="parX">Координата X центра</param>
        /// <param name="parY">Координата Y центра</param>
        /// <returns></returns>
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

        /// <summary>
        /// Устанавливает цвет фигуры и цвет границ 
        /// в соответствии с типом фигуры и её состоянием
        /// </summary>
        /// <param name="parObjectType"></param>
        /// <param name="parState"></param>
        /// <param name="parShape"></param>
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

        /// <summary>
        /// Создает фигуру препятствия по её центру
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        /// <returns></returns>
        public static Shape CreateBarrierView(Barrier parBarrier)
        {
            Shape shape = null;
            if (parBarrier.ID == BarrierType.ARROW)
            {
                shape = CreateEllipseGroup(parBarrier.Width,
                                                parBarrier.Height,
                                                parBarrier.X,
                                                parBarrier.Y);
            }

            if (parBarrier.ID == BarrierType.SHORT_SHOT
                || parBarrier.ID == BarrierType.LONG_SHOT)
            {

                shape = new Line();
                shape = SetLineCoordinates(parBarrier, shape);


                if (parBarrier.ID == BarrierType.SHORT_SHOT)
                {
                    shape.Stroke = HEXAGON_COLOR;
                    shape.StrokeThickness = BOUNDS_THICKNESS;
                }
                if (parBarrier.ID == BarrierType.LONG_SHOT)
                {
                    shape.Stroke = TRIANGLE_COLOR;
                    shape.StrokeThickness = BOUNDS_THICKNESS * 2;
                }
            }

            return shape;
        }

        /// <summary>
        /// Установка цвета препятствия в соответствии с типом родителя
        /// </summary>
        /// <param name="parBarrierType">Тип препятствия</param>
        /// <param name="parState">Состояние родителя</param>
        /// <param name="parShape">Фигура</param>
        public static void SetBarrierColorByState(BarrierType parBarrierType,
            GameObjectsStates parState, Shape parShape)
        {
            if (parState == GameObjectsStates.INACTIVE)
            {
                parShape.Fill = INACTIVE_EATEN_COLOR;
                parShape.Stroke = EATEN_BOUNDS_COLOR;
            }
            else
            {
                if (parBarrierType == BarrierType.ARROW)
                {
                    parShape.Fill = CIRCLE_COLOR;
                    parShape.Stroke = BOUNDS_COLOR;
                }
            }
        }

        /// <summary>
        /// Устанавливает координаты препятствия,
        /// в соответствии с направлением движения
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        /// <param name="parShape">Фигура</param>
        /// <returns></returns>
        public static Line SetLineCoordinates(Barrier parBarrier, Shape parShape)
        {
            double startX;
            double startY;
            double endX;
            double endY;

            if (parBarrier.StartX > parBarrier.EndX)
            {
                startX = parBarrier.X - parBarrier.Width / 2;
                endX = parBarrier.X + parBarrier.Width / 2;
            }
            else
            {
                startX = parBarrier.X + parBarrier.Width / 2;
                endX = parBarrier.X - parBarrier.Width / 2;
            }

            if (parBarrier.StartY > parBarrier.EndY)
            {
                startY = parBarrier.Y - parBarrier.Height / 2;
                endY = parBarrier.Y + parBarrier.Height / 2;
            }
            else
            {
                startY = parBarrier.Y + parBarrier.Height / 2;
                endY = parBarrier.Y - parBarrier.Height / 2;
            }

            ((Line)parShape).X1 = startX;
            ((Line)parShape).Y1 = startY;
            ((Line)parShape).X2 = endX;
            ((Line)parShape).Y2 = endY;
            return (Line)parShape;
        }
    }
}
