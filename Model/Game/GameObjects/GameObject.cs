using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    public abstract class GameObject
    {

        public delegate void dRedraw();
        public event dRedraw Redraw = null;

        private int _x;
        private int _y;
        private int _area;

        public GameObjectTypes ID { get; set; }
        public string IDName { get; set; }

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                Redraw?.Invoke();
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                Redraw?.Invoke();
            }
        }

        public int Area
        {
            get
            {
                return _area;
            }
            set
            {
                _area = value;
                SetHeight();
                SetWidth();
                Redraw?.Invoke();
            }
        }

        public int Height { get; protected set; }
        public int Width { get; protected set; }
        
        public GameObject(GameObjectTypes parID, string parIDName, int parX, int parY, int parArea)
        {
            ID = parID;
            IDName = parIDName;
            X = parX;
            Y = parY;
            Area = parArea;
        }

        public abstract void SetHeight();
        public abstract void SetWidth();
    }
}
