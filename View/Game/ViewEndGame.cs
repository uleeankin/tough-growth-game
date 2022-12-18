using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Items;

namespace View.Game
{
    public abstract class ViewEndGame : View
    {

        private Dictionary<int, ViewControlItem> _controlItems = null;
        private List<ViewPassiveItem> _passiveItems = null;
        private List<ViewInputItem> _inputItems = null;

        protected ViewControlItem[] BackToMenu => _controlItems.Values.ToArray();
        protected ViewPassiveItem[] Info => _passiveItems.ToArray();
        protected ViewInputItem[] Input => _inputItems.ToArray();
        protected Model.Game.EndGameScreen EndScreen { get; set; }

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

        public ViewEndGame(Model.Game.EndGameScreen parEndGame)
        {
            EndScreen = parEndGame;
            _controlItems = new Dictionary<int, ViewControlItem>();
            _passiveItems = new List<ViewPassiveItem>();
            _inputItems = new List<ViewInputItem>();

            foreach (Model.Items.PassiveItem elPassiveItem in parEndGame.PassiveItems)
            {
                _passiveItems.Add(CreatePassiveItem(elPassiveItem));
            }

            foreach (Model.Items.ControlItem elControlItem in parEndGame.ControlItems)
            {
                _controlItems.Add(elControlItem.ID, CreateControlItem(elControlItem));
            }

            foreach (Model.Items.InputItem elInputItem in parEndGame.InputItems)
            {
                _inputItems.Add(CreateInputItem(elInputItem));
            }
        }

        protected abstract void Redraw();
        protected abstract ViewControlItem CreateControlItem(Model.Items.ControlItem parControlItem);
        protected abstract ViewPassiveItem CreatePassiveItem(Model.Items.PassiveItem parPassiveItem);
        protected abstract ViewInputItem CreateInputItem(Model.Items.InputItem parInputItem);
    }
}
