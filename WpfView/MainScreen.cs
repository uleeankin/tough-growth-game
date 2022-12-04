using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace WpfView
{
    public class MainScreen : Window
    {
        private const int HEIGHT = 550;
        private const int WIDTH = 1000;

        private static MainScreen _instance;
        public Canvas Screen { get; }

        private MainScreen()
        {
            Width = WIDTH;
            Height = HEIGHT;
            ResizeMode = ResizeMode.NoResize;
            Screen = new Canvas();
            Screen.Width = WIDTH;
            Screen.Height = HEIGHT;
            Screen.Background = new SolidColorBrush(Colors.Black);
            AddChild(Screen);
            Show();
        }

        public static MainScreen GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MainScreen();
            }
            return _instance;
        }
    }
}
