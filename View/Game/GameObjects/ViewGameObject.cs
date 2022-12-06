using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Game.GameObjects;

namespace View.Game.GameObjects
{
    public abstract class ViewGameObject : View
    {
        private GameObject _gameObject = null;

        public GameObject Object
        {
            get
            {
                return _gameObject;
            }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public ViewGameObject(GameObject parGameObject)
        {
            _gameObject = parGameObject;
            _gameObject.Redraw += RedrawGameObject;
        }

        protected abstract void RedrawGameObject();
    }
}
