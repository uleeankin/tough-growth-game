using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using System.Windows.Input;

namespace WpfController.Menu
{
    public class WpfMenuController : MenuController
    {

        public WpfMenuController() : base()
        {
            Menu = new Model.Menu.MainMenu();
            ViewMenu = new WpfView.Menu.WpfViewMenu(Menu);
        }

        public override void Start()
        {

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
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
    }
}
