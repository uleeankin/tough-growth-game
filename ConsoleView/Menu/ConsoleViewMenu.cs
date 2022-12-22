using Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using View.Items;
using Model.Items;
using ConsoleView.Items;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Консольное представление окна главного меню
    /// </summary>
    public class ConsoleViewMenu : ViewMenu
    {

        /// <summary>
        /// Ширина окна
        /// </summary>
        private const int WIDTH = 120;

        /// <summary>
        /// Высота окна
        /// </summary>
        private const int HEIGHT = 30;

        /// <summary>
        /// Выводитель
        /// </summary>
        private ConsoleView.Utils.CustomOutput _output = new Utils.CustomOutput();

        /// <summary>
        /// Конструктор консольного представления окна главного меню
        /// </summary>
        /// <param name="parMenu">Модель главного меню</param>
        public ConsoleViewMenu(MenuScreen parMenu) : base(parMenu)
        {
            Init();
        }

        /// <summary>
        /// Обработчик события рисования окна главного меню
        /// </summary>
        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            _output.PrintGameTitle(WIDTH);
            foreach (ViewControlItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

        /// <summary>
        /// Создает консольное представление кнопки
        /// </summary>
        /// <param name="parMenuItem">Модель кнопки</param>
        /// <returns>Консольное представление кнопки</returns>
        protected override ViewControlItem CreateControlItem(ControlItem parMenuItem)
        {
            return new ConsoleViewControlItem(parMenuItem);
        }

        /// <summary>
        /// Создает консольное представление текстового поля
        /// </summary>
        /// <param name="parMenuTitle">Модель текстового поля</param>
        /// <returns>Консольное представление текстового поля</returns>
        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parMenuTitle)
        {
            return new ConsoleViewPassiveItem(parMenuTitle);
        }

        /// <summary>
        /// Обработчик события перерисовки окна главного меню
        /// </summary>
        protected override void Redraw()
        {
            
        }

        /// <summary>
        /// Инициализация координат объектов главного меню
        /// </summary>
        private void Init()
        {
            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;

            Console.SetBufferSize(WIDTH, HEIGHT);

            Console.CursorVisible = false;

            ViewControlItem[] menu = Menu;
            Height = menu.Length;
            Width = menu.Max(x => x.Width);

            X = Console.WindowWidth / 2;
            Y = Console.WindowHeight / 2 - Width / 4;

            int y = Y;

            for (int i = 0; i < menu.Length; i++)
            {
                menu[i].X = X;
                menu[i].Y = y + (3 * i);
                y++;
            }
        }
    }
}
