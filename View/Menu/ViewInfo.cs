using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace View.Menu
{
    public abstract class ViewInfo : View
    {
        private Model.Menu.MenuScreen _info = null;

        private Dictionary<int, ViewControlItem> _controlItems = null;
        private List<ViewPassiveItem> _passiveItems = null;

        protected ViewControlItem[] BackToMenu => _controlItems.Values.ToArray();
        protected ViewPassiveItem[] Rules => _passiveItems.ToArray();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewControlItem this[int parId]
        {
            get
            {
                return _controlItems[parId];
            }
        }

        public ViewInfo(Model.Menu.MenuScreen parInfo)
        {
            _info = parInfo;
            _controlItems = new Dictionary<int, ViewControlItem>();
            _passiveItems = new List<ViewPassiveItem>();

            foreach (Model.Items.PassiveItem elMenuTitle in parInfo.PassiveItems)
            {
                _passiveItems.Add(CreatePassiveItem(elMenuTitle));
            }

            foreach (Model.Items.ControlItem elMenuItem in parInfo.ControlItems)
            {
                _controlItems.Add(elMenuItem.ID, CreateControlItem(elMenuItem));
            }
        }

        protected abstract void Redraw();
        protected abstract ViewControlItem CreateControlItem(Model.Items.ControlItem parMenuItem);
        protected abstract ViewPassiveItem CreatePassiveItem(Model.Items.PassiveItem parMenuTitle);

    }
}
