using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;
using Model.Menu;
using Model.Enums;

namespace ConsoleController.Menu
{
    /// <summary>
    /// Контроллер окна справки (консоль)
    /// </summary>
    public class ConsoleInfoController : InfoController
    {
        /// <summary>
        /// Сущность консольного контроллера справки
        /// </summary>
        private static ConsoleInfoController _instance;

        /// <summary>
        /// Представление окна справки
        /// </summary>
        private ViewInfo _viewInfo = null;

        /// <summary>
        /// Флаг состояния работы контроллера
        /// </summary>
        protected bool IsExit { get; set; }

        /// <summary>
        /// Конструктор контроллера справки
        /// </summary>
        private ConsoleInfoController() : base()
        {
            Info = new Info();
            _viewInfo = new ConsoleView.Menu.ConsoleViewInfo(Info);
            foreach (Model.Items.ControlItem elItem in Info.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }
        
        /// <summary>
        /// Получает или создает консольный контроллер справки
        /// </summary>
        /// <returns>Контроллер справки</returns>
        public static ConsoleInfoController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleInfoController();
            }
            return _instance;
        }

        /// <summary>
        /// Запускает работу консольного контроллера справки
        /// </summary>
        public override void Start()
        {
            _viewInfo.Draw();
            IsExit = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Info.SelectFocusedItem();
                        break;
                }
            } while (!IsExit);
            
        }

        /// <summary>
        /// Останавливает работу консольного контроллера справки
        /// </summary>
        public override void Stop()
        {
            IsExit = !IsExit;
        }
    }
}
