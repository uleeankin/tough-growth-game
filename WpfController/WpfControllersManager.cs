using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using Controller.Game;
using Controller.Menu;
using WpfController.Menu;
using WpfController.Game;

namespace WpfController
{
    /// <summary>
    /// Класс управления контроллерами
    /// </summary>
    public class WpfControllersManager : ControllersManager
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        public WpfControllersManager()
        {

        }

        /// <summary>
        /// Получает контроллер игры в единственном экземпляре
        /// </summary>
        /// <returns>Wpf контроллер игры</returns>
        protected override GameController GetGameController()
        {
            return WpfGameController.GetInstance();
        }

        /// <summary>
        /// Получает контроллер справки в единственном экземпляре
        /// </summary>
        /// <returns>Wpf контроллер справки</returns>
        protected override InfoController GetInfoController()
        {
            return WpfInfoController.GetInstance();
        }

        /// <summary>
        /// Получает контроллер главного меню в единственном экземпляре
        /// </summary>
        /// <returns>Wpf контроллер главного меню</returns>
        protected override MenuController GetMenuController()
        {
            return WpfMenuController.GetInstance();
        }

        /// <summary>
        /// Получает контроллер рекордов в единственном экземпляре
        /// </summary>
        /// <returns>Wpf контроллер рекордов</returns>
        protected override RecordsController GetRecordsController()
        {
            return WpfRecordsController.GetInstance();
        }

        /// <summary>
        /// Получает контроллер окончания игры в единственном экземпляре
        /// </summary>
        /// <returns>Wpf окончания контроллер игры</returns>
        protected override EndGameController GetEndGameController()
        {
            return WpfEndGameController.GetInstance();
        }
    }
}
