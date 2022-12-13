using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    public class Triangle : GameObject
    {
        public Triangle(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        public override GameObject Clone()
        {
            Triangle triangle = new Triangle(ID, IDName, X, Y, Area);
            return triangle;
        }

        public override void SetHeight()
        {
            double a = Math.Sqrt((4 * Area) / Math.Sqrt(3));
            Height = Math.Sqrt(3 * Math.Pow(a, 2) / 4);
        }

        public override void SetWidth()
        {
            Width = Math.Sqrt((4 * Area) / Math.Sqrt(3));
        }
    }
}
