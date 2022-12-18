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
    public class WpfRecordsController : RecordsController
    {

        private static WpfRecordsController _instance;

        private ViewRecords _viewRecords = null;

        private MainScreen _screen = null;

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

        public static WpfRecordsController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfRecordsController();
            }
            
            return _instance;
        }

        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Records.SelectFocusedItem();
                    break;
            }
        }

        public override void Start()
        {
            ((Records)Records).GetRecords();
            _viewRecords = new WpfView.Menu.WpfViewRecords(Records);
            _screen.KeyDown += OnKeyDownHandler;
            _viewRecords.Draw();
        }

        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
