using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    /// <summary>
    /// Направления движения
    /// </summary>
    public enum MotionType : int
    {
        /// <summary>
        /// Вверх
        /// </summary>
        UP,
        /// <summary>
        /// Вниз
        /// </summary>
        DOWN,
        /// <summary>
        /// Влево
        /// </summary>
        LEFT,
        /// <summary>
        /// Вправо
        /// </summary>
        RIGHT,
        /// <summary>
        /// Стоит на месте
        /// </summary>
        NO_MOTION
    }
}
