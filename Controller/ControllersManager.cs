using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using Controller.Game;
using Model.Enums;

namespace Controller
{
    /// <summary>
    /// Базовый класс для передачи управления между контроллерами
    /// </summary>
    public abstract class ControllersManager
    {
        /// <summary>
        /// Текущий работающий контроллер
        /// </summary>
        protected Controller CurrentController { get; set; }

        /// <summary>
        /// Контроллер окна главного меню
        /// </summary>
        protected MenuController Menu { get; set; }

        /// <summary>
        /// Контроллер окна справки
        /// </summary>
        protected InfoController Info { get; set; }

        /// <summary>
        /// Контроллер окна рекордов
        /// </summary>
        protected RecordsController Records { get; set; }

        /// <summary>
        /// Контроллер окна игры
        /// </summary>
        protected GameController Game { get; set; }

        /// <summary>
        /// Контроллер окна конца игры
        /// </summary>
        protected EndGameController EndGame { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ControllersManager()
        {

        }

        /// <summary>
        /// Передача управления между контроллерами
        /// </summary>
        /// <param name="parCode">Код контроллера, которому передается управление</param>
        public void GetMove(ControlItemCode parCode)
        {
            CurrentController.Stop();
            switch (parCode)
            {
                case ControlItemCode.Game:
                    CurrentController = Game;
                    Game.Start();
                    break;
                case ControlItemCode.Records:
                    CurrentController = Records;
                    Records.Start();
                    break;
                case ControlItemCode.Info:
                    CurrentController = Info;
                    Info.Start();
                    break;
                case ControlItemCode.MainMenu:
                    CurrentController = Menu;
                    Menu.Start();
                    break;
                case ControlItemCode.EndGame:
                    CurrentController = EndGame;
                    EndGame.End.Score = Game.Game.Deaths;
                    EndGame.Start();
                    break;
            }
        }

        /// <summary>
        /// Запуск работы контроллеров
        /// </summary>
        public void Start()
        {
            InitControllers();
            SubscribeToEvents();
            CurrentController = Menu;
            CurrentController.Start();
        }

        /// <summary>
        /// Определение обработчика событий передачи управления
        /// </summary>
        private void SubscribeToEvents()
        {
            Menu.ChangeController += GetMove;
            Records.ChangeController += GetMove;
            Info.ChangeController += GetMove;
            Game.ChangeController += GetMove;
            EndGame.ChangeController += GetMove;
        }

        /// <summary>
        /// Инициализация всех контроллеров приложения
        /// </summary>
        private void InitControllers()
        {
            Menu = this.GetMenuController();
            Records = this.GetRecordsController();
            Info = this.GetInfoController();
            Game = this.GetGameController();
            EndGame = this.GetEndGameController();
        }

        /// <summary>
        /// Получение контроллера главного меню
        /// </summary>
        /// <returns>Контроллер главного меню</returns>
        protected abstract MenuController GetMenuController();

        /// <summary>
        /// Получение контроллера справки
        /// </summary>
        /// <returns>Контроллер справки</returns>
        protected abstract InfoController GetInfoController();

        /// <summary>
        /// Получение контроллера рекордов
        /// </summary>
        /// <returns>Контроллер рекордов</returns>
        protected abstract RecordsController GetRecordsController();

        /// <summary>
        /// Получение контроллера игры
        /// </summary>
        /// <returns>Контроллер игры</returns>
        protected abstract GameController GetGameController();

        /// <summary>
        /// Получение контроллера конца игры
        /// </summary>
        /// <returns>Контроллер окна окончания игры</returns>
        protected abstract EndGameController GetEndGameController();
    }
}
