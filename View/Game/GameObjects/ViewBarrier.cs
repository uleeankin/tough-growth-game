using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game.GameObjects
{
    public abstract class ViewBarrier : View
    {
        private Barrier _barrier = null;

        public Barrier Barrier
        {
            get
            {
                return _barrier;
            }
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public ViewBarrier(Barrier parBarrier)
        {
            _barrier = parBarrier;
            _barrier.Redraw += RedrawBarrier;
        }

        protected abstract void RedrawBarrier();
    }
}
