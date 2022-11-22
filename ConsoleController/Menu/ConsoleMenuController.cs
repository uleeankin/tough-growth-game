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
    public class ConsoleMenuController : MenuController
    {
        protected bool IsExit { get; set; }

        private ViewMenu _viewMenu = null;

        public ConsoleMenuController() : base()
        {
            Menu = new Model.Menu.MainMenu();
            _viewMenu = new ConsoleView.Menu.ConsoleViewMenu(Menu);
            Menu[(int) ControlItemCode.Exit].Selected += () => { IsExit = true; };
        }

        public override void Start()
        {
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

        public override void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
