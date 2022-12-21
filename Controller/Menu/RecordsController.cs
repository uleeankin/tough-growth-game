using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Menu
{
    /// <summary>
    /// Абстрактный класс контроллера, отвечающего за управление окном рекордов
    /// </summary>
    public abstract class RecordsController : Controller
    {
        /// <summary>
        /// Модель окна рекордов
        /// </summary>
        protected Model.Menu.MenuScreen Records { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public RecordsController() : base()
        {

        }
    }
}
