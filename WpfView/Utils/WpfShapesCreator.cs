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
        public static Shape CreateGameObjectView(GameObjectTypes parGameObjectType,
                                                    int parHeight, int parWidth,
                                                    int parX, int parY)
        {
            Shape shape = null;
            switch(parGameObjectType)
            {
                case GameObjectTypes.GAME_SQUARE:
                    shape = CreateGameSquare(parWidth, parX, parY);
                    break;
            }
            return shape;
        }

        private static Shape CreateGameSquare(int parWidth, int parX, int parY)
        {
            Shape rectangle = new Rectangle();
            rectangle.Width = parWidth;
            rectangle.Height = parWidth;
            rectangle.Fill = Brushes.Magenta;
            rectangle.Stroke = Brushes.White;
            rectangle.StrokeThickness = 3;
            Canvas.SetTop(rectangle, parY);
            Canvas.SetLeft(rectangle, parX);
            return rectangle;
        }
    }
}
