using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    /// <summary>
    /// Виды препятствий
    /// </summary>
    public enum BarrierType : int
    {
        /// <summary>
        /// Короткий выстрел
        /// </summary>
        SHORT_SHOT,
        /// <summary>
        /// Длинный выстрел
        /// </summary>
        LONG_SHOT,
        /// <summary>
        /// Преследующая стрелка
        /// </summary>
        ARROW
    }
}
