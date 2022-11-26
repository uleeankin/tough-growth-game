﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.Menu;
using View.Menu;
using Model.Enums;

namespace ConsoleController.Menu
{
    public class ConsoleRecordsController : RecordsController
    {

        private static ConsoleRecordsController _instance;

        protected bool IsExit { get; set; }

        private ViewRecords _viewRecords = null;

        private ConsoleRecordsController() : base()
        {
            Records = new Model.Menu.Records();
            _viewRecords = new ConsoleView.Menu.ConsoleViewRecords(Records);
            foreach (Model.Items.ControlItem elItem in Records.ControlItems)
            {
                elItem.Selected += () => { SwitchController((ControlItemCode)elItem.ID); };
            }
        }

        public static ConsoleRecordsController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleRecordsController();
            }
            
            return _instance;
        }

        public override void Start()
        {
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

        public override void Stop()
        {
            IsExit = !IsExit;
        }
    }
}
