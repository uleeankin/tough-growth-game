using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Game
{
    public abstract class GameController : Controller
    {
        public Model.Game.GameScreen Game { get; set; }

        public GameController() : base()
        {

        }
    }
}
