using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Game
{
    /// <summary>
    /// Абстрактный класс контроллера, отвечающего за управление окном конца игры
    /// </summary>
    public abstract class EndGameController : Controller
    {

        /// <summary>
        /// Модель окна окончания игры
        /// </summary>
        public Model.Game.EndGameScreen End { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public EndGameController() : base()
        {

        }
    }
}
