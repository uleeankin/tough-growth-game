using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using Controller;
using Model.Enums;

namespace ConsoleController.Menu
{
    public class ConsoleMenuController : MenuController
    {

        private static Model.Menu.Menu _menu = null;
        private static View.Menu.ViewMenu _view = null;

        protected bool IsExit { get; set; }

        static ConsoleMenuController()
        {
            _menu = new Model.Menu.MainMenu();
            _view = new ConsoleView.Menu.ConsoleViewMenu(_menu);
        }

        public ConsoleMenuController() : base(_menu, _view)
        {
            _menu[(int) MenuItemCode.Exit].Selected += () => { IsExit = true; };
        }

        public override void Start()
        {
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        _menu.FocusPrevious();
                        break;
                    case ConsoleKey.DownArrow:
                        _menu.FocusNext();
                        break;
                    case ConsoleKey.Enter:
                        _menu.SelectFocusedItem();
                        break;
                }


            } while (!IsExit);
        }
    }
}
