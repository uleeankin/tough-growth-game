using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;
using Model.Items;

namespace Model.Menu
{
    public class MenuScreen : Screen
    {
        private int _focusedItemIndex = -1;

        private Dictionary<int, ControlItem> _controlItem = new Dictionary<int, ControlItem>();

        private List<PassiveItem> _passiveItems = new List<PassiveItem>();

        public int FocusedItemIndex
        {
            get { return _focusedItemIndex; }
            protected set { _focusedItemIndex = value; }
        }

        public ControlItem[] ControlItems
        {
            get
            {
                return _controlItem.Values.ToArray();
            }
        }

        public ControlItem this[int parId]
        {
            get
            {
                return _controlItem[parId];
            }
        }

        public MenuScreen()
        {

        }

        public void FocusNext()
        {
            int currentFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == ControlItems.Length - 1)
            {
                _focusedItemIndex = 0;
            }
            else
            {
                _focusedItemIndex++;
            }

            ControlItems[_focusedItemIndex].State = States.Focused;
            ControlItems[currentFocusedIndex].State = States.Normal;
        }

        public void FocusPrevious()
        {
            int currentFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == 0)
            {
                _focusedItemIndex = ControlItems.Length - 1;
            }
            else
            {
                _focusedItemIndex--;
            }

            ControlItems[_focusedItemIndex].State = States.Focused;
            ControlItems[currentFocusedIndex].State = States.Normal;
        }

        public void FocusItemById(int parId)
        {
            int currentFocusedIndex = _focusedItemIndex;
            ControlItem menuItem = this[parId];
            _focusedItemIndex = new List<ControlItem>(ControlItems).IndexOf(menuItem);

            if (currentFocusedIndex != -1)
            {
                ControlItems[currentFocusedIndex].State = States.Normal;
            }
              
            ControlItems[_focusedItemIndex].State = States.Focused;
        }

        public void SelectFocusedItem()
        {
            ControlItems[_focusedItemIndex].State = States.Selected;
        }

        protected void AddControlItem(ControlItem parControlItem)
        {
            _controlItem.Add(parControlItem.ID, parControlItem);
        }

        protected void AddPassiveItem(PassiveItem parPassiveItem)
        {
            _passiveItems.Add(parPassiveItem);
        }
    }
}
