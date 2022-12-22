using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using View.Items;
using ConsoleView.Items;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Консольное представление окна рекордов
    /// </summary>
    public class ConsoleViewRecords : ViewRecords
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
        /// Конструктор консольного представления окна рекордов
        /// </summary>
        /// <param name="parRecords"></param>
        public ConsoleViewRecords(Model.Menu.MenuScreen parRecords) : base(parRecords)
        {
            
        }

        /// <summary>
        /// Обработчик события рисования окна рекордов
        /// </summary>
        public override void Draw()
        {
            Init();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (ViewPassiveItem elViewPassiveItem in Records)
            {
                elViewPassiveItem.Draw();
            }

            BackToMenu[0].Draw();
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
        /// Обработчик события перерисовки окна рекордов
        /// </summary>
        protected override void Redraw()
        {
            
        }

        /// <summary>
        /// Задает координаты объектов в окне
        /// </summary>
        private void Init()
        {
            
            Console.CursorVisible = false;

            X = 2;
            Y = 2;
            int y = Y;
            foreach (ViewPassiveItem elViewPassiveItem in Records)
            {
                elViewPassiveItem.X = X;
                elViewPassiveItem.Y = y;
                y++;
            }

            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;
            ViewControlItem[] button = BackToMenu;
            Height = button.Length;
            Width = button.Max(x => x.Width);

            button[0].X = Console.WindowWidth / 2;
            button[0].Y = Console.WindowHeight - Height * 4;
        }
    }
}
