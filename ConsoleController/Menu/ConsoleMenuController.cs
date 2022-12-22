using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using Controller;
using Model.Enums;
using View.Menu;

namespace ConsoleController.Menu
{
    /// <summary>
    /// Консольный контроллер главного меню
    /// </summary>
    public class ConsoleMenuController : MenuController
    {
        /// <summary>
        /// Сущность консольного контроллера главного меню
        /// </summary>
        private static ConsoleMenuController _instance;

        /// <summary>
        /// Представление окна главного меню
        /// </summary>
        private ViewMenu _viewMenu = null;

        /// <summary>
        /// Флаг состояния работы контроллера главного меню
        /// </summary>
        protected bool IsExit { get; set; }

        /// <summary>
        /// Конструктор консольного контроллера главного меню
        /// </summary>
        private ConsoleMenuController() : base()
        {
            Menu = new Model.Menu.MainMenu();
            _viewMenu = new ConsoleView.Menu.ConsoleViewMenu(Menu);
            foreach (Model.Items.ControlItem elItem in Menu.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        /// <summary>
        /// Получает или создает консольный контроллер главного меню
        /// </summary>
        /// <returns>Контроллер главного меню</returns>
        public static ConsoleMenuController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleMenuController();
            }
           
            return _instance;
        }

        /// <summary>
        /// Запускает работу контроллера главного меню
        /// </summary>
        public override void Start()
        {
            _viewMenu.Draw();
            IsExit = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Menu.FocusPrevious();
                        break;
                    case ConsoleKey.DownArrow:
                        Menu.FocusNext();
                        break;
                    case ConsoleKey.Enter:
                        Menu.SelectFocusedItem();
                        break;
                }


            } while (!IsExit);
        }

        /// <summary>
        /// Останавливает работу контроллера главного меню
        /// </summary>
        public override void Stop()
        {
            IsExit = !IsExit;
        }
    }
}
