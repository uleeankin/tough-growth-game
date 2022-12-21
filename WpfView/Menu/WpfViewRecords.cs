using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;
using View.Menu;
using WpfView.Items;
using Model.Items;
using Model.Menu;
using System.Windows;

namespace WpfView.Menu
{
    /// <summary>
    /// Графическое представление окна рекордов
    /// </summary>
    public class WpfViewRecords : ViewRecords
    {

        /// <summary>
        /// Размер шрифта для текста рекордов
        /// </summary>
        public const int TEXT_FONT_SIZE = 16;

        /// <summary>
        /// Общее окно для всех окон приложения
        /// </summary>
        private MainScreen _screen = MainScreen.GetInstance();

        /// <summary>
        /// Конструктор графического представления окна рекорды
        /// </summary>
        /// <param name="parRecords">Модель окна рекордов</param>
        public WpfViewRecords(MenuScreen parRecords) : base(parRecords)
        {
            Init();
        }

        /// <summary>
        /// Обработчик события рисования окна рекордов
        /// </summary>
        public override void Draw()
        {
            _screen.Screen.Children.Clear();
            foreach (ViewPassiveItem elPassiveItem in Records)
            {
                elPassiveItem.Draw();
            }
            foreach (ViewControlItem elViewControlItem in BackToMenu)
            {
                elViewControlItem.Draw();
            }
            this.SetParentControl(_screen.Screen);
        }

        /// <summary>
        /// Устанавливает координаты объектов окна рекордов 
        /// для размещения на экране
        /// </summary>
        private void Init()
        {
            int y = TEXT_FONT_SIZE * 2;
            foreach (ViewPassiveItem elPassiveItem in Records)
            {
                elPassiveItem.Y = y;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = (int)_screen.Width / 2 
                    - elPassiveItem.Item.Text.Length / 2 * (int)(TEXT_FONT_SIZE / 1.5);
                y += (TEXT_FONT_SIZE * 2);
            }

            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                elMenuItem.Y = (int)_screen.Height - (int)(elMenuItem.Height * 2.5);
                elMenuItem.X = (int)_screen.Width / 2 - (int)(elMenuItem.Width / 2);
            }
        }

        /// <summary>
        /// Размещает все объекты окна на экране
        /// </summary>
        /// <param name="parParent"></param>
        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Records)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
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
        /// Обработчик события перерисовки окна рекордов
        /// </summary>
        protected override void Redraw()
        {

        }
    }
}
