using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.GameObjects
{
    public class PermanentSquare : GameObject
    {
        public delegate void dNeedNewPosition();
        public event dNeedNewPosition NeedNewPosition;

        private GameObjectsStates _state = GameObjectsStates.FOOD;

        public override GameObjectsStates State
        {
            get
            {
                return _state;
            }
            set
            {
                NeedNewPosition?.Invoke();
            }
        }

        public PermanentSquare(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

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
