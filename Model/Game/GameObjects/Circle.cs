using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    public class Circle : GameObject
    {
        public Circle(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }
        public override void SetHeight()
        {
            Height = 2 * Math.Sqrt(Area / Math.PI);
        }

        public override void SetWidth()
        {
            Width = 2 * Math.Sqrt(Area / Math.PI);
        }
    }
}
