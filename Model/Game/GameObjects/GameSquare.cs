using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    public class GameSquare : GameObject
    {
        public GameSquare(GameObjectTypes parID, string parIDName, int parX, 
            int parY, int parArea) : base(parID, parIDName, parX, parY, parArea)
        {
            
        }

        public override void SetHeight()
        {
            Height = (int)Math.Sqrt(Area);
        }

        public override void SetWidth()
        {
            Width = (int)Math.Sqrt(Area);
        }
    }
}
