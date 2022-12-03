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
    public class WpfMenuController : MenuController
    {

        private static WpfMenuController _instance;

        private ViewMenu _viewMenu = null;
        private MainScreen _screen = null;

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

        public static WpfMenuController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfMenuController();
            }
            return _instance;
        }


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

        public override void Start()
        {
            _screen.KeyDown += OnKeyDownHandler;
            _viewMenu.Draw();
        }

        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
