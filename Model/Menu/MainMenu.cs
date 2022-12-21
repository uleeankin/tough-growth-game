using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;
using Model.Items;

namespace Model.Menu
{
    /// <summary>
    /// Главное меню
    /// </summary>
    public class MainMenu : MenuScreen
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MainMenu() : base()
        {
            this.AddPassiveItem(new PassiveItem(Properties.Resources.TitlePassiveItem));
            this.AddControlItem(new ControlItem((int)ControlItemCode.Game, 
                                Properties.Resources.GameControlItem));
            this.AddControlItem(new ControlItem((int)ControlItemCode.Records,
                                Properties.Resources.RecordsControlItem));
            this.AddControlItem(new ControlItem((int)ControlItemCode.Info,
                                Properties.Resources.InfoControlItem));
            this.AddControlItem(new ControlItem((int)ControlItemCode.Exit,
                                Properties.Resources.ExitControlItem));

            this.FocusItemById((int)ControlItemCode.Game);
        }

    }
}
