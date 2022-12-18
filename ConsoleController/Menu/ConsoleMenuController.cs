﻿using System;
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

        private static ConsoleMenuController _instance;

        protected bool IsExit { get; set; }

        private ViewMenu _viewMenu = null;

        private ConsoleMenuController() : base()
        {
            Menu = new Model.Menu.MainMenu();
            _viewMenu = new ConsoleView.Menu.ConsoleViewMenu(Menu);
            foreach (Model.Items.ControlItem elItem in Menu.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        public static ConsoleMenuController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleMenuController();
            }
           
            return _instance;
        }

        public override void Start()
        {
            _viewMenu.Draw();
            IsExit = false;
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