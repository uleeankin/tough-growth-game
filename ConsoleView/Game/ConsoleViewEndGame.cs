using ConsoleView.Items;
using Model.Game;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game;
using View.Items;

namespace ConsoleView.Game
{
    /// <summary>
    /// Консольное представление окна конца игры
    /// </summary>
    public class ConsoleViewEndGame : ViewEndGame
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
        /// Конструктор консольного представления окна конца игры
        /// </summary>
        /// <param name="parEndGameScreen">Модель окна конца игры</param>
        public ConsoleViewEndGame(EndGameScreen parEndGameScreen) : base(parEndGameScreen)
        {
            Init();
        }

        /// <summary>
        /// Обработчик события рисования окна игры
        /// </summary>
        public override void Draw()
        {
            Info[1].Item.Text += EndScreen.Score.ToString();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                elPassiveItem.Draw();
            }
            foreach (ViewControlItem elViewControlItem in BackToMenu)
            {
                elViewControlItem.Draw();
            }

            foreach (ViewInputItem elInputItem in Input)
            {
                elInputItem.Draw();
            }
        }

        /// <summary>
        /// Инициализация координат объектов окна
        /// </summary>
        private void Init()
        {
            int y = 2;
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                elPassiveItem.Y = y;
                elPassiveItem.X = WIDTH / 2
                    - elPassiveItem.Item.Text.Length / 2;
                y += 2;
            }

            foreach (ViewInputItem elInputItem in Input)
            {
                elInputItem.X = WIDTH / 2 - elInputItem.Width / 2;
                elInputItem.Y = HEIGHT / 2;
            }

            Console.WindowHeight = HEIGHT;
            Console.WindowWidth = WIDTH;

            Console.CursorVisible = false;

            ViewControlItem[] button = BackToMenu;
            Height = button.Length;
            Width = button.Max(x => x.Width);

            button[0].X = Console.WindowWidth / 2;
            button[0].Y = Console.WindowHeight - Height * 4;
        }

        /// <summary>
        /// Создает консольное представление кнопки
        /// </summary>
        /// <param name="parControlItem"></param>
        /// <returns>Консольное представление кнопки</returns>
        protected override ViewControlItem CreateControlItem(ControlItem parControlItem)
        {
            return new ConsoleViewControlItem(parControlItem);
        }

        /// <summary>
        /// Создает консольное представление поля ввода
        /// </summary>
        /// <param name="parInputItem">Модель поля ввода</param>
        /// <returns>Консольное представление поля ввода</returns>
        protected override ViewInputItem CreateInputItem(InputItem parInputItem)
        {
            return new ConsoleViewInputItem(parInputItem);
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
        /// Обработчик события перерисовки окна окончания игры
        /// </summary>
        protected override void Redraw()
        {
            
        }
    }
}
