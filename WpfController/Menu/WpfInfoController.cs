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
    public class WpfInfoController : InfoController
    {

        private static WpfInfoController _instance;

        private ViewInfo _viewInfo = null;
        private MainScreen _screen = null;

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

        public static WpfInfoController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WpfInfoController();
            }
            return _instance;
        }

        public void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Enter:
                    Info.SelectFocusedItem();
                    break;
            }
        }

        public override void Start()
        {
            _screen.KeyDown += OnKeyDownHandler;
            _viewInfo.Draw();
        }

        public override void Stop()
        {
            _screen.KeyDown -= OnKeyDownHandler;
        }
    }
}
