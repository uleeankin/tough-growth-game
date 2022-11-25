using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;
using Model.Enums;

namespace Controller
{
    public abstract class Controller
    {
        public delegate void dChangeController(ControlItemCode parItemCode);
        public event dChangeController ChangeController = null;

        public Controller()
        {
            
        }

        public void SwitchController(ControlItemCode parItemCode)
        {
            ChangeController?.Invoke(parItemCode);
        }

        public abstract void Start();
        public abstract void Stop();
    }
}
