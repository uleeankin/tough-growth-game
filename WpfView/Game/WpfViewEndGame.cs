using Model.Game;
using Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using View.Game;
using View.Items;
using WpfView.Items;

namespace WpfView.Game
{
    /// <summary>
    /// Графическое представление окна окончания игры
    /// </summary>
    public class WpfViewEndGame : ViewEndGame
    {
        /// <summary>
        /// Размер шрифта для текстовых полей и полей ввода
        /// </summary>
        public const int TEXT_FONT_SIZE = 24;

        /// <summary>
        /// Общее окно для всех окон приложения
        /// </summary>
        private MainScreen _screen = MainScreen.GetInstance();

        /// <summary>
        /// Конструктор графического представления окна окончания игры
        /// </summary>
        /// <param name="parEndGameScreen">Модель окна окончания игры</param>
        public WpfViewEndGame(EndGameScreen parEndGameScreen) : 
                                                base(parEndGameScreen)
        {
            Init();
        }

        /// <summary>
        /// Обработчик события рисования окна окончания игры
        /// </summary>
        public override void Draw()
        {
            Info[1].Item.Text += EndScreen.Score.ToString();
            Application.Current.Dispatcher.Invoke(() => {
                _screen.Screen.Children.Clear();
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
                this.SetParentControl(_screen.Screen);
            });
        }

        /// <summary>
        /// Устанавливает координаты объектов окна игры
        /// для размещения на экране
        /// </summary>
        private void Init()
        {
            int y = TEXT_FONT_SIZE * 2;
            
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                elPassiveItem.Y = y;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = (int)_screen.Screen.Width / 2
                    - elPassiveItem.Item.Text.Length / 2 * TEXT_FONT_SIZE / 2;
                y += TEXT_FONT_SIZE * 2;
            }

            foreach (ViewControlItem elControlItem in BackToMenu)
            {
                elControlItem.Y = (int)_screen.Height - (int)(elControlItem.Height * 2.5);
                elControlItem.X = (int)_screen.Width / 2 - (int)(elControlItem.Width / 2);
            }

            foreach (ViewInputItem elInputItem in Input)
            {
                elInputItem.X = (int)_screen.Width / 2 - elInputItem.Width / 2;
                elInputItem.Y = (int)_screen.Height / 2;
            }
        }

        /// <summary>
        /// Размещает все объекты окна на экране
        /// </summary>
        /// <param name="parParent"></param>
        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Info)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
            }
            foreach (ViewInputItem elInputItem in Input)
            {
                ((WpfViewInputItem)elInputItem).SetParentControl(parParent);
            }
        }

        /// <summary>
        /// Создает графическое представление кнопки
        /// </summary>
        /// <param name="parControlItem">Модель кнопки</param>
        /// <returns>Графическое представление кнопки</returns>
        protected override ViewControlItem CreateControlItem(ControlItem parControlItem)
        {
            return new WpfViewControlItem(parControlItem);
        }

        /// <summary>
        /// Создает графическое представление текстового поля
        /// </summary>
        /// <param name="parPassiveItem">Модель текстового поля</param>
        /// <returns>Графическое представление текстового поля</returns>
        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parPassiveItem)
        {
            return new WpfViewPassiveItem(parPassiveItem);
        }

        /// <summary>
        /// Обработчик события перерисовки окна окончания игры
        /// </summary>
        protected override void Redraw()
        {
            
        }

        /// <summary>
        /// Создает графическое представление поля ввода
        /// </summary>
        /// <param name="parInputItem">Модель поля ввода</param>
        /// <returns>Графическое представление поля ввода</returns>
        protected override ViewInputItem CreateInputItem(InputItem parInputItem)
        {
            return new WpfViewInputItem(parInputItem);
        }
    }
}
