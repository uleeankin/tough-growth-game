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
    public class Info : MenuScreen
    {
        public Info() : base()
        {
            this.AddPassiveItem(new PassiveItem(
                String.Join("\n", FileIO.FileReader(Properties.Resources.GameRulesFileName).ToArray())));
            this.AddPassiveItem(new PassiveItem(
                String.Join("\n", FileIO.FileReader(Properties.Resources.ManagementRulesFileName).ToArray())));
            this.AddControlItem(new ControlItem((int)ControlItemCode.MainMenu,
                                        Properties.Resources.MainMenuControlItem));
            this.FocusItemById((int)ControlItemCode.MainMenu);
        }
    }
}
