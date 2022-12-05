using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Model.Enums;

namespace WpfView.Utils
{
    public class WpfShapesCreator
    {
        private static readonly Brush GAME_SQUARE_COLOR = Brushes.Magenta;
        private static readonly Brush BOUNDS_COLOR = Brushes.White;
        private static readonly Brush FOOD_STATE_COLOR = Brushes.Yellow;
        private static readonly int BOUNDS_THICKNESS = 3;

        public static Shape CreateGameObjectView(GameObjectTypes parGameObjectType,
                                                    double parHeight, double parWidth,
                                                    double parX, double parY)
        {
            Shape shape = null;
            switch(parGameObjectType)
            {
                case GameObjectTypes.GAME_SQUARE:
                    shape = CreateRectangleGroup(parHeight, parWidth, parX, parY,
                        GAME_SQUARE_COLOR, BOUNDS_COLOR);
                    break;
                case GameObjectTypes.PERMANENT_SQUARE:
                    shape = CreateRectangleGroup(parHeight, parWidth, parX, parY,
                        FOOD_STATE_COLOR, BOUNDS_COLOR);
                    break;
            }
            return shape;
        }

        private static Shape CreateRectangleGroup(double parWidth, double parHeight, 
                                                    double parX, double parY, 
                                                    Brush parShapeColor, 
                                                    Brush parShapeBoundsColor)
        {
            Shape rectangle = new Rectangle();
            rectangle.Width = parWidth;
            rectangle.Height = parHeight;
            rectangle.Fill = parShapeColor;
            rectangle.Stroke = parShapeBoundsColor;
            rectangle.StrokeThickness = BOUNDS_THICKNESS;
            Canvas.SetTop(rectangle, parY);
            Canvas.SetLeft(rectangle, parX);
            return rectangle;
        }

        private static Shape CreatePolygonGroup()
        {
            Shape polygon = new Polygon();
            return polygon;
        }

        private static Shape CreateEllipseGroup()
        {
            Shape ellipse = new Ellipse();
            return ellipse;
        }
    }
}
