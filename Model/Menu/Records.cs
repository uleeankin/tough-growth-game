using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Items;
using Model.Enums;

namespace Model.Menu
{
    public class Records : MenuScreen
    {
        public Records() : base()
        {
            this.AddControlItem(new ControlItem((int)ControlItemCode.MainMenu,
                                        Properties.Resources.MainMenuControlItem));
            this.FocusItemById((int)ControlItemCode.MainMenu);
        }
    }
}
