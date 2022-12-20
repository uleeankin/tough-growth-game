using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.GameObjects
{
    public class Barrier
    {
        public delegate void dRedraw();
        public event dRedraw Redraw = null;

        private GameObjectsStates _state;

        public BarrierType ID { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double StartX { get; set; }

        public double StartY { get; set; }

        public double EndX { get; set; }

        public double EndY { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public GameObject Parent { get; set; }

        public GameObjectsStates State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                Redraw?.Invoke();
            }
        }

        public Barrier(BarrierType parBarrierType,
            double parEndX, double parEndY,
            double parWidth, double parHeight,
            GameObject parParent)
        {
            ID = parBarrierType;
            StartX = parParent.X;
            StartY = parParent.Y;
            X = StartX;
            Y = StartY;
            EndX = parEndX;
            EndY = parEndY;
            Width = parWidth;
            Height = parHeight;
            State = GameObjectsStates.BARRIER;
            Parent = parParent;
        }

        public Barrier(BarrierType parBarrierType,
            double parEndX, double parEndY,
            double parWidth, double parHeight,
            GameObject parParent,
            double parScreenHeight, double parScreenWidth)
        {
            ID = parBarrierType;
            StartX = parParent.X;
            StartY = parParent.Y;
            X = StartX;
            Y = StartY;
            EndX = parEndX;
            EndY = parEndY;
            GetEndCoordinates(parScreenHeight, parScreenWidth);
            Width = parWidth;
            Height = parHeight;
            State = GameObjectsStates.BARRIER;
            Parent = parParent;
        }

        private void GetEndCoordinates(double parScreenHeight, double parScreenWidth)
        {
            if (X > EndX)
            {
                EndX = 0;
            }
            else
            {
                EndX = parScreenWidth;
            }
            if (Y > EndY)
            {
                EndY = 0;
            }
            else
            {
                EndY = parScreenHeight;
            }
        }

        public void MoveByStep(double parSpeed)
        {

            if (State == GameObjectsStates.BARRIER)
            {
                if (X > EndX)
                {
                    X -= parSpeed;
                }
                else
                {
                    X += parSpeed;
                }
                if (Y > EndY)
                {
                    Y -= parSpeed;
                }
                else
                {
                    Y += parSpeed;
                }
                Redraw?.Invoke();
            }
        }
    }
}
