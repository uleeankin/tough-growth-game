using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Game.GameObjects
{
    /// <summary>
    /// Базовое представление модели препятствия
    /// </summary>
    public abstract class ViewBarrier : View
    {
        /// <summary>
        /// Препятствие
        /// </summary>
        private Barrier _barrier = null;

        /// <summary>
        /// Препятствие
        /// </summary>
        public Barrier Barrier
        {
            get
            {
                return _barrier;
            }
        }

        /// <summary>
        /// Координата X на отображении
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Координата Y на отображении
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Ширина на отображении
        /// </summary>
        public double Width { get; protected set; }
        /// <summary>
        /// Высота на отображении
        /// </summary>
        public double Height { get; protected set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parBarrier">Объект препятствия</param>
        public ViewBarrier(Barrier parBarrier)
        {
            _barrier = parBarrier;
            _barrier.Redraw += RedrawBarrier;
        }

        /// <summary>
        /// Обработчик события перерисовки
        /// </summary>
        protected abstract void RedrawBarrier();
    }
}
