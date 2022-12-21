using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    /// <summary>
    /// Состояния игровых объектов
    /// </summary>
    public enum GameObjectsStates : int
    {
        /// <summary>
        /// Неактивный
        /// </summary>
        INACTIVE,
        /// <summary>
        /// Является препятствием
        /// </summary>
        BARRIER,
        /// <summary>
        /// Доступен для съедения
        /// </summary>
        FOOD,
        /// <summary>
        /// Съеден
        /// </summary>
        EATEN,
        /// <summary>
        /// Не имеет состояния
        /// </summary>
        NO_STATE
    }
}
