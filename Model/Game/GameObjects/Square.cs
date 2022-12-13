using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.GameObjects
{
    public class Square : GameObject
    {

        public Square(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        public override GameObject Clone()
        {
            Square square = new Square(ID, IDName, X, Y, Area);
            return square;
        }

        public override void SetHeight()
        {
            Height = Math.Sqrt(Area);
        }

        public override void SetWidth()
        {
            Width = Math.Sqrt(Area);
        }
    }
}
