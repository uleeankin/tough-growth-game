using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class MainMenu : Menu
    {
        public enum MenuItemCode : int
        {
            Game,
            Records,
            Info,
            Exit
        }

        public MainMenu() : base(Properties.Resources.Title, 
                                    Properties.Resources.MainMenuName)
        {
            this.AddItem(new MenuItem((int)MenuItemCode.Game, 
                                Properties.Resources.GameMenuItem));
            this.AddItem(new MenuItem((int)MenuItemCode.Records,
                                Properties.Resources.RecordsMenuItem));
            this.AddItem(new MenuItem((int)MenuItemCode.Info,
                                Properties.Resources.InfoMenuItem));
            this.AddItem(new MenuItem((int)MenuItemCode.Exit,
                                Properties.Resources.ExitMenuItem));

            this.FocusItemById((int)MenuItemCode.Game);
        }

    }
}
