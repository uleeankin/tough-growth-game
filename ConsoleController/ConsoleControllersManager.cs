using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;
using ConsoleController.Menu;
using Controller.Menu;
using Model.Enums;
using Controller.Game;
using ConsoleController.Game;

namespace ConsoleController
{
    /// <summary>
    /// Класс управления контроллерами
    /// </summary>
    public class ConsoleControllersManager : ControllersManager
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ConsoleControllersManager()
        {

        }

        /// <summary>
        /// Получает консольный контроллер окна окончания игры
        /// </summary>
        /// <returns>Консольный контроллер окна окончания игры</returns>
        protected override EndGameController GetEndGameController()
        {
            return ConsoleEndGameController.GetInstance();
        }

        /// <summary>
        /// Получает консольный контроллер окна игры
        /// </summary>
        /// <returns>Консольный контроллер окна игры</returns>
        protected override GameController GetGameController()
        {
            return ConsoleGameController.GetInstance();
        }

        /// <summary>
        /// Получает консольный контроллер окна справки
        /// </summary>
        /// <returns>Консольный контроллер окна справки</returns>
        protected override InfoController GetInfoController()
        {
            return ConsoleInfoController.GetInstance();
        }

        /// <summary>
        /// Получает консольный контроллер окна главного меню
        /// </summary>
        /// <returns>Консольный контроллер окна главного меню</returns>
        protected override MenuController GetMenuController()
        {
            return ConsoleMenuController.GetInstance();
        }

        /// <summary>
        /// Получает консольный контроллер окна рекордов
        /// </summary>
        /// <returns>Консольный контроллер окна рекордов</returns>
        protected override RecordsController GetRecordsController()
        {
            return ConsoleRecordsController.GetInstance();
        }
    }
}
