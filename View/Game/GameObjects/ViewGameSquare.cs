using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Game.GameObjects;

namespace View.Game.GameObjects
{
    public abstract class ViewGameSquare : ViewGameObject
    {
        public ViewGameSquare(GameSquare parGameSquare) : base(parGameSquare)
        {

        }
    }
}
