using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Menu
{
    public class Menu : SubMenuItem
    {
        public delegate void dRedraw();

        public event dRedraw Redraw = null;

        private int _focusedItemIndex = -1;

        private string _title;

        public int FocusedItemIndex
        {
            get { return _focusedItemIndex; }
            protected set { _focusedItemIndex = value; }
        }

        public string Title
        {
            get { return _title; }
            private set { _title = value; }
        }

        public Menu(string parTitle, string parName) : base(0, parName)
        {
            _title = parTitle;
        }

        public void FocusNext()
        {
            int currentFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == Items.Length - 1)
            {
                _focusedItemIndex = 0;
            }
            else
            {
                _focusedItemIndex++;
            }

            Items[_focusedItemIndex].State = States.Focused;
            Items[currentFocusedIndex].State = States.Normal;

            Redraw?.Invoke();
        }
        public void FocusPrevious()
        {
            int currentFocusedIndex = _focusedItemIndex;
            if (_focusedItemIndex == 0)
            {
                _focusedItemIndex = Items.Length - 1;
            }
            else
            {
                _focusedItemIndex--;
            }

            Items[_focusedItemIndex].State = States.Focused;
            Items[currentFocusedIndex].State = States.Normal;

            Redraw?.Invoke();
        }
        public void FocusItemById(int parId)
        {
            int currentFocusedIndex = _focusedItemIndex;
            MenuItem menuItem = this[parId];
            _focusedItemIndex = new List<MenuItem>(Items).IndexOf(menuItem);

            if (currentFocusedIndex != -1)
            {
                Items[currentFocusedIndex].State = States.Normal;
            }
              
            Items[_focusedItemIndex].State = States.Focused;
            Redraw?.Invoke();
        }
        public void SelectFocusedItem()
        {
            Items[_focusedItemIndex].State = States.Selected;
        }
    }
}
