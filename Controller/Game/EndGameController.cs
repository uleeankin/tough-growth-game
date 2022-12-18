using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Game
{
    public abstract class EndGameController : Controller
    {

        public Model.Game.EndGameScreen End { get; set; }

        public EndGameController() : base()
        {

        }
    }
}
