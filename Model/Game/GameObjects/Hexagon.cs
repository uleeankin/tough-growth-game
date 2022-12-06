using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    public class Hexagon : GameObject
    {

        public Hexagon(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        /// <summary>
        /// Вычисление высоты шестиугольника с помощью формул площадей многоугольников
        /// </summary>
        public override void SetHeight()
        {
            int n = 6;
            Height = 2 * Math.Sqrt((2 * Area / (n * Math.Sin(360 / n)))
                                    - ((4 * Area * Math.Tan(180 / n)) / (2 * n)));
        }

        /// <summary>
        /// Вычисление ширины шестиугольника с помощью формулы площади многоугольника
        /// </summary>
        public override void SetWidth()
        {
            int n = 6;
            double R = Math.Sqrt(Math.Abs(2 * Area / (n * Math.Sin(360 / n))));
            Width = 2 * R;
        }
    }
}
