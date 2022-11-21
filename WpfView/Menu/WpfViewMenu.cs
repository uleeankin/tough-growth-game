using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using View.Menu;

namespace WpfView.Menu
{
    public class WpfViewMenu : ViewMenu
    {

        public const int HEIGHT = 550;
        public const int WIDTH = 1000;

        private Window _window = null;
        private Utils.CastomOutput _output = new Utils.CastomOutput();

        public WpfViewMenu(Model.Menu.Menu parMenu) : base(parMenu)
        {
            Init();
            Draw();
        }

        private void Init()
        {
            _window = new Window();
            _window.Height = HEIGHT;
            _window.Width = WIDTH;
            _window.ResizeMode = ResizeMode.NoResize;
            _window.ShowActivated = true;
            _window.Background = Brushes.Black;
            StackPanel stackPanel = new StackPanel();
            _window.Content = stackPanel;
            this.SetParentControl(stackPanel);
            _window.Show();
        }

        private void SetParentControl(FrameworkElement parParent)
        {
            ((IAddChild)parParent).AddChild(_output.GetTitle());
            ViewMenuItem[] menu = Menu;
            foreach (ViewMenuItem elMenuItem in menu)
            {
                ((WpfViewMenuItem)elMenuItem).SetParentControl(parParent);
            }
        }

        public override void Draw()
        {
            foreach (ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

        protected override ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem)
        {
            return new WpfViewMenuItem(parMenuItem);
        }

        protected override void Redraw()
        {
            
        }
    }
}
