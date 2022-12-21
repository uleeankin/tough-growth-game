using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    /// <summary>
    /// Абстрактный класс контроллера, отвечающего за управление окна главного меню
    /// </summary>
    public abstract class MenuController : Controller
    {
        /// <summary>
        /// Модель главного меню
        /// </summary>
        protected Model.Menu.MenuScreen Menu { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public MenuController()
            : base()
        {
            
        }
    }
}
