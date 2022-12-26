using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;
using WpfView;
using Model.Menu;
using Model.Items;
using System.Windows.Input;
using Model.Enums;

namespace WpfController.Menu
{
    /// <summary>
    /// Контроллер окна рекордов (wpf)
    /// </summary>
    public class WpfRecordsController : RecordsController
    {
        /// <summary>
        /// Сущность контроллера рекордов
        /// </summary>
        private static WpfRecordsController _instance;

        /// <summary>
        /// Представление окна рекордов
        /// </summary>
        private ViewRecords _viewRecords = null;

        /// <summary>
        /// Общее wpf окно для всех окон
        /// </summary>
        private MainScreen _screen = null;

        /// <summary>
        /// Конструктор контроллера рекордов
        /// </summary>
        private WpfRecordsController() : base()
        {
            Records = new Records();
            _screen = MainScreen.GetInstance();
            _viewRecords = new WpfView.Menu.WpfViewRecords(Records);
            foreach (ControlItem elItem in Records.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        /// <summary>
        /// Получает сущность контроллера рекордов
        /// </summary>
        /// <returns>Контроллер рекордов</returns>
        public static WpfRecordsController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfRecordsController();
            }
            
            return _instance;
        }

        /// <summary>
        /// Обработчик события нажатия на клавиши клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Records.SelectFocusedItem();
                    break;
            }
        }

        /// <summary>
        /// Запускает работу MVC рекордов
        /// </summary>
        public override void Start()
        {
            ((Records)Records).GetRecords();
            _viewRecords = new WpfView.Menu.WpfViewRecords(Records);
            _screen.KeyDown += OnKeyDownHandler;
            _viewRecords.Draw();
        }

        /// <summary>
        /// Останавливает работу MVC рекордов
        /// </summary>
        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
