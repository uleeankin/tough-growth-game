using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Items;
using Model.Enums;
using Model.Utils;

namespace Model.Menu
{
    /// <summary>
    /// Окно рекордов
    /// </summary>
    public class Records : MenuScreen
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public Records() : base()
        {
            this.GetRecords();
            this.AddControlItem(new ControlItem((int)ControlItemCode.MainMenu,
                                        Properties.Resources.MainMenuControlItem));
            this.FocusItemById((int)ControlItemCode.MainMenu);
        }

        /// <summary>
        /// Получает рекорды из файла
        /// </summary>
        public void GetRecords()
        {
            this.DeletePassiveItems();
            List<Tuple<string, int>> recordsData 
                = FileIO.RecordsFileReader(
                    Properties.Resources.RecordsFileName)
                        .OrderBy(x => x.Item2).ToList();

            if (recordsData.Count != 0)
            {
                if (recordsData.Count > 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        this.AddPassiveItem(
                            new PassiveItem(
                                $"{i + 1} место. {recordsData[i].Item1} - {recordsData[i].Item2}"));
                    }
                } else
                {
                    for (int i = 0; i < recordsData.Count; i++)
                    {
                        this.AddPassiveItem(
                            new PassiveItem(
                                $"{i + 1} место. {recordsData[i].Item1} - {recordsData[i].Item2}"));
                    }
                }
            }
         }
    }
}
