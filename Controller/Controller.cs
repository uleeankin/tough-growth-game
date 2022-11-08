using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;

namespace Controller
{
    public abstract class Controller
    {

        protected Model.Model Model { get; set; }
        protected View.View View { get; set; }

        public Controller(Model.Model parModel, View.View parView)
        {
            this.Model = parModel;
            this.View = parView;
        }

        public abstract void Start();
    }
}
