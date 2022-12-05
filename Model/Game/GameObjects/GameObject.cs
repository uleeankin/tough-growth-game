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

        private double _x;
        private double _y;
        private double _area;

        public GameObjectTypes ID { get; set; }
        public string IDName { get; set; }

        public double X
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
        public double Y
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

        public double Area
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

        public virtual GameObjectsStates State { get; set; }
        public double Height { get; protected set; }
        public double Width { get; protected set; }
        
        public GameObject(GameObjectTypes parID, string parIDName, double parX, double parY, double parArea)
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
