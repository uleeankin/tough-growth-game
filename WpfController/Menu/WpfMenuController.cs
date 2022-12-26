using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using System.Windows.Input;
using WpfView;
using View.Menu;
using Model.Menu;
using Model.Items;
using Model.Enums;

namespace WpfController.Menu
{
    /// <summary>
    /// Контроллер главного меню (wpf)
    /// </summary>
    public class WpfMenuController : MenuController
    {
        /// <summary>
        /// Сущность контроллера главного меню
        /// </summary>
        private static WpfMenuController _instance;

        /// <summary>
        /// Представление окна главного меню
        /// </summary>
        private ViewMenu _viewMenu = null;

        /// <summary>
        /// Общее wpf окно для всех окон
        /// </summary>
        private MainScreen _screen = null;

        /// <summary>
        /// Конструктор контроллера главного меню
        /// </summary>
        private WpfMenuController() : base()
        {
            Menu = new MainMenu();
            _screen = MainScreen.GetInstance();
            _viewMenu = new WpfView.Menu.WpfViewMenu(Menu);
            foreach (ControlItem elItem in Menu.ControlItems)
            {
                if ((ControlItemCode)elItem.ID != ControlItemCode.Exit)
                {
                    elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
                } else
                {
                    elItem.Selected += () => { _screen.Close(); };
                }
            }

        }

        /// <summary>
        /// Получает сущность контроллера главного меню
        /// </summary>
        /// <returns>Контроллер главного меню</returns>
        public static WpfMenuController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfMenuController();
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
                case Key.Up:
                    Menu.FocusPrevious();
                    break;
                case Key.Down:
                    Menu.FocusNext();
                    break;
                case Key.Enter:
                    Menu.SelectFocusedItem();
                    break;
            }
        }

        /// <summary>
        /// Запускает работу MVC главного меню
        /// </summary>
        public override void Start()
        {
            _screen.KeyDown += OnKeyDownHandler;
            _viewMenu.Draw();
        }


        /// <summary>
        /// Останавливает работу MVC главного меню
        /// </summary>
        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
