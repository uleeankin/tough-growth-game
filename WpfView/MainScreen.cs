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
    /// <summary>
    /// Общее графическое окно
    /// </summary>
    public class MainScreen : Window
    {
        /// <summary>
        /// Высота окна
        /// </summary>
        private const int HEIGHT = 550;
        /// <summary>
        /// Ширина окна
        /// </summary>
        private const int WIDTH = 1000;

        /// <summary>
        /// Сущность общего окна
        /// </summary>
        private static MainScreen _instance;

        /// <summary>
        /// Контейнер для объектов приложения
        /// </summary>
        public Canvas Screen { get; }

        /// <summary>
        /// Конструктор общего графического окна
        /// </summary>
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

        /// <summary>
        /// Получает или создает объект класса общего графического экрана
        /// </summary>
        /// <returns></returns>
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
