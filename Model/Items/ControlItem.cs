using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Items
{
    public class ControlItem
    {
        public delegate void dSelected();
        public delegate void dRedrawItem();

        public event dSelected Selected = null;
        public event dRedrawItem RedrawItem = null;
       
        private States _state = States.Normal;
        public string Name { get; private set; }
        public States State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                if (_state == States.Selected)
                {
                    Selected?.Invoke();
                } 
                else
                {
                    RedrawItem?.Invoke();
                }
            }
        }
        public int ID { get; private set; }
        public ControlItem(int parId, string parName)
        {
            ID = parId;
            State = States.Normal;
            Name = parName;
        }
    }
}
