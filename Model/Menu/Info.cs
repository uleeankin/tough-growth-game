using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;
using Model.Items;
using Model.Utils;

namespace Model.Menu
{
    /// <summary>
    /// Окно справки
    /// </summary>
    public class Info : MenuScreen
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Info() : base()
        {
            this.AddPassiveItem(new PassiveItem(Properties.Resources.GameRules));
            this.AddPassiveItem(new PassiveItem(Properties.Resources.ManagementRules));
            this.AddControlItem(new ControlItem((int)ControlItemCode.MainMenu,
                                        Properties.Resources.MainMenuControlItem));
            this.FocusItemById((int)ControlItemCode.MainMenu);
        }
    }
}
