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
    /// Графическое представление окна справки
    /// </summary>
    public class WpfViewInfo : ViewInfo
    {
        /// <summary>
        /// Размер шрифта для текста справки
        /// </summary>
        public const int TEXT_FONT_SIZE = 14;

        /// <summary>
        /// Общее окно для всех окон приложения
        /// </summary>
        private MainScreen _screen = MainScreen.GetInstance();

        /// <summary>
        /// Конструктор графического представления окна справки
        /// </summary>
        /// <param name="parMenuScreen">Модель окна справки</param>
        public WpfViewInfo(MenuScreen parMenuScreen) : base(parMenuScreen)
        {
            Init();
        }

        /// <summary>
        /// Обработчик события рисования окна справки
        /// </summary>
        public override void Draw()
        {
            _screen.Screen.Children.Clear();
            foreach (ViewPassiveItem elPassiveItem in Rules)
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
        /// Устанавливает координаты объектов окна справки
        /// для размещения на экране
        /// </summary>
        private void Init()
        {
            int y = 10;
            foreach (ViewPassiveItem elPassiveItem in Rules)
            {
                elPassiveItem.Y = y;
                elPassiveItem.Height = TEXT_FONT_SIZE;
                elPassiveItem.X = 10;
                y += (int)_screen.Height / 3;
            }

            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                elMenuItem.Y = (int)_screen.Height - (int)(elMenuItem.Height * 2.5);
                elMenuItem.X = (int)_screen.Width / 2 - (int)(elMenuItem.Width / 2);
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
        /// Размещает все объекты окна на экране
        /// </summary>
        /// <param name="parParent"></param>
        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Rules)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in BackToMenu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
            }
        }
    }
}
