using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;
using Model.Enums;
using Model.Menu;

namespace ConsoleController.Menu
{
    /// <summary>
    /// Консольный контроллер окна рекордов
    /// </summary>
    public class ConsoleRecordsController : RecordsController
    {
        /// <summary>
        /// Сущность контроллера окна рекордов
        /// </summary>
        private static ConsoleRecordsController _instance;

        /// <summary>
        /// Представление окна рекордов
        /// </summary>
        private ViewRecords _viewRecords = null;

        /// <summary>
        /// Флаг состояния работы контроллера
        /// </summary>
        protected bool IsExit { get; set; }

        /// <summary>
        /// Конструктор консольного контроллера окна рекордов
        /// </summary>
        private ConsoleRecordsController() : base()
        {
            Records = new Model.Menu.Records();
            _viewRecords = new ConsoleView.Menu.ConsoleViewRecords(Records);
            foreach (Model.Items.ControlItem elItem in Records.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        /// <summary>
        /// Получает или создает консольный контроллер окна рекордов
        /// </summary>
        /// <returns>Консольный контроллер окна рекордов</returns>
        public static ConsoleRecordsController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleRecordsController();
            }
            
            return _instance;
        }

        /// <summary>
        /// Запускает работу консольного контроллера окна рекордов
        /// </summary>
        public override void Start()
        {
            ((Records)Records).GetRecords();
            _viewRecords = new ConsoleView.Menu.ConsoleViewRecords(Records);
            _viewRecords.Draw();
            
            IsExit = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Records.SelectFocusedItem();
                        break;
                }
            } while (!IsExit);

        }

        /// <summary>
        /// Останавливает работу консольного контроллера окна рекордов
        /// </summary>
        public override void Stop()
        {
            IsExit = !IsExit;
        }
    }
}
