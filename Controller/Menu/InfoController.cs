using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    /// <summary>
    /// Абстрактный класс контроллера, отвечающего за управление окном справки
    /// </summary>
    public abstract class InfoController : Controller
    {
        /// <summary>
        /// Модель окна справки
        /// </summary>
        protected Model.Menu.MenuScreen Info { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public InfoController() : base()
        {

        }
    }
}
