using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Game
{
    /// <summary>
    /// Абстрактный класс контроллера, отвечающего за управление окном игры
    /// </summary>
    public abstract class GameController : Controller
    {
        /// <summary>
        /// Модель игры
        /// </summary>
        public Model.Game.GameScreen Game { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameController() : base()
        {

        }
    }
}
