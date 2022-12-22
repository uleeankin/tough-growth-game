using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Menu;
using View.Items;
using Model.Items;
using ConsoleView.Items;
using Model.Menu;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Консольное представление окна справки
    /// </summary>
    public class ConsoleViewInfo : ViewInfo
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
        /// Конструктор консольного представления справки
        /// </summary>
        /// <param name="parInfo">Модель справки</param>
        public ConsoleViewInfo(MenuScreen parInfo) : base(parInfo)
        {
            Init();
        }

        /// <summary>
        /// Обработчик события рисования окна справки
        /// </summary>
        public override void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            foreach (ViewPassiveItem elViewPassiveItem in Rules)
            {
                elViewPassiveItem.Draw();
            }
            BackToMenu[0].Draw();
        }

        /// <summary>
        /// Создает консольное представление кнопки
        /// </summary>
        /// <param name="parControlItem">Модель кнопки</param>
        /// <returns>Консольное представление кнопки</returns>
        protected override ViewControlItem CreateControlItem(ControlItem parControlItem)
        {
            return new ConsoleViewControlItem(parControlItem);
        }

        /// <summary>
        /// Создает консольное представление текстового поля
        /// </summary>
        /// <param name="parPassiveItem">Модель текстового поля</param>
        /// <returns>Консольное представление текстового поля</returns>
        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parPassiveItem)
        {
            return new ConsoleViewPassiveItem(parPassiveItem);
        }

        /// <summary>
        /// Обработчик события перерисовки окна справки
        /// </summary>
        protected override void Redraw()
        {
            
        }

        /// <summary>
        /// Инициализация координат объектов окна справки
        /// </summary>
        private void Init()
        {
            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;

            Console.CursorVisible = false;

            X = 0;
            Y = 2;
            int y = Y;
            foreach(ViewPassiveItem elViewPassiveItem in Rules)
            {
                elViewPassiveItem.X = X;
                elViewPassiveItem.Y = y;
                y = Console.CursorTop + (Y + 1) * 5;
            } 

            ViewControlItem[] button = BackToMenu;
            Height = button.Length;
            Width = button.Max(x => x.Width);

            button[0].X = Console.WindowWidth / 2;
            button[0].Y = Console.WindowHeight - Height * 4;
            
        }
    }
}
