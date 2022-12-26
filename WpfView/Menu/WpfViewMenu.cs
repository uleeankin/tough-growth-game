using Model.Items;
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
using View.Items;
using View.Menu;
using WpfView.Items;

namespace WpfView.Menu
{
    /// <summary>
    /// Графическое представление окна галвного меню
    /// </summary>
    public class WpfViewMenu : ViewMenu
    {
        /// <summary>
        /// Общее окно для всех окон приложения
        /// </summary>
        private MainScreen _screen = MainScreen.GetInstance();

        /// <summary>
        /// Конструктор графического представления окна главного меню
        /// </summary>
        /// <param name="parMenu">Модель окна главного меню</param>
        public WpfViewMenu(MenuScreen parMenu) : base(parMenu)
        {
            Init();
        }

        /// <summary>
        /// Размещает все объекты окна на экране
        /// </summary>
        /// <param name="parParent"></param>
        private void SetParentControl(FrameworkElement parParent)
        {
            foreach (ViewPassiveItem elPassiveItem in Title)
            {
                ((WpfViewPassiveItem)elPassiveItem).SetParentControl(parParent);
            }
            foreach (ViewControlItem elMenuItem in Menu)
            {
                ((WpfViewControlItem)elMenuItem).SetParentControl(parParent);
            }
        }

        /// <summary>
        /// Обработчик события рисования окна главного меню
        /// </summary>
        public override void Draw()
        {
            Application.Current.Dispatcher.Invoke(() => {
                _screen.Screen.Children.Clear();
                foreach (ViewPassiveItem elPassiveItem in Title)
                {
                    elPassiveItem.Draw();
                }
                foreach (ViewControlItem elViewControlItem in Menu)
                {
                    elViewControlItem.Draw();
                }
                this.SetParentControl(_screen.Screen);
            });
            
        }

        /// <summary>
        /// Обработчик события перерисовки окна главного меню
        /// </summary>
        protected override void Redraw()
        {

        }

        /// <summary>
        /// Создает графическое представление кнопки
        /// </summary>
        /// <param name="parMenuItem">Модель кнопки</param>
        /// <returns>Графическое представление кнопки</returns>
        protected override ViewControlItem CreateControlItem(ControlItem parMenuItem)
        {
            return new WpfViewControlItem(parMenuItem);
        }

        /// <summary>
        /// Создает графическое представление текстового поля
        /// </summary>
        /// <param name="parMenuTitle">Модель текстового поля</param>
        /// <returns>Графическое представление текстового поля</returns>
        protected override ViewPassiveItem CreatePassiveItem(PassiveItem parMenuTitle)
        {
            return new WpfViewPassiveItem(parMenuTitle);
        }

        /// <summary>
        /// Устанавливает координаты объектов окна главного меню
        /// для размещения на экране
        /// </summary>
        private void Init()
        {
            foreach (ViewPassiveItem elPassiveItem in Title)
            {
                elPassiveItem.Y = (int)_screen.Height % 100 / 2;
                elPassiveItem.Height = (int)_screen.Width / 10 - ((int)_screen.Width / 40);
                elPassiveItem.X = (int)_screen.Width / 4;
            }

            int y = (int)_screen.Height / 2 - Menu.Length * Menu[0].Height / 2; ;

            foreach (ViewControlItem elMenuItem in Menu)
            {
                elMenuItem.Y = y;
                elMenuItem.X = (int)_screen.Width / 2 - elMenuItem.Width / 2;
                y += elMenuItem.Height + elMenuItem.Height / 2;
            }
        }
    }
}
