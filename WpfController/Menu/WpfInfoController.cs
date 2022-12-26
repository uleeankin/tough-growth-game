using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Controller.Menu;
using View.Menu;
using WpfView;
using Model.Menu;
using Model.Items;
using Model.Enums;

namespace WpfController.Menu
{
    /// <summary>
    /// Контроллер окна справки (wpf)
    /// </summary>
    public class WpfInfoController : InfoController
    {
        
        /// <summary>
        /// Сущность контроллера справки
        /// </summary>
        private static WpfInfoController _instance;

        /// <summary>
        /// Представление окна справки
        /// </summary>
        private ViewInfo _viewInfo = null;

        /// <summary>
        /// Общее wpf окно для всех окон
        /// </summary>
        private MainScreen _screen = null;


        /// <summary>
        /// Конструктор контроллера справки
        /// </summary>
        private WpfInfoController() : base()
        {
            _screen = MainScreen.GetInstance();
            Info = new Info();
            _viewInfo = new WpfView.Menu.WpfViewInfo(Info);
            foreach (ControlItem elItem in Info.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        /// <summary>
        /// Получает сущность контроллера справки
        /// </summary>
        /// <returns>Контроллер справки</returns>
        public static WpfInfoController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfInfoController();
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
            switch(e.Key)
            {
                case Key.Enter:
                    Info.SelectFocusedItem();
                    break;
            }
        }

        /// <summary>
        /// Запускает работу MVC справки
        /// </summary>
        public override void Start()
        {
            _screen.KeyDown += OnKeyDownHandler;
            _viewInfo.Draw();
        }

        /// <summary>
        /// Останавливает работу MVC справки
        /// </summary>
        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
