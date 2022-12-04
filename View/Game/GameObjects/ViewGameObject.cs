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

        protected GameObject Object
        {
            get
            {
                return _gameObject;
            }
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewGameObject(GameObject parGameObject)
        {
            _gameObject = parGameObject;
            _gameObject.Redraw += RedrawGameObject;
        }

        protected abstract void RedrawGameObject();
    }
}
