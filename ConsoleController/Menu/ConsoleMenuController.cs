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

        private ConsoleControllersManager _controllersManager = null;

        public ConsoleMenuController(ConsoleControllersManager parManager) : base()
        {
            Menu = new Model.Menu.MainMenu();
            _viewMenu = new ConsoleView.Menu.ConsoleViewMenu(Menu);
            _controllersManager = parManager;
            foreach (Model.Items.ControlItem elItem in Menu.ControlItems)
            {
                elItem.Selected += () => { _controllersManager.GetMove((ControlItemCode)elItem.ID); };
            }
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
            IsExit = !IsExit;
        }
    }
}
