using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Enums
{
    /// <summary>
    /// Виды игровых объектов на поле
    /// </summary>
    public enum GameObjectTypes : int
    {
        /// <summary>
        /// Игровой квадрат
        /// </summary>
        GAME_SQUARE,
        /// <summary>
        /// Постоянный съедобный квадрат
        /// </summary>
        PERMANENT_SQUARE,
        /// <summary>
        /// Квадрат
        /// </summary>
        SQUARE,
        /// <summary>
        /// Круг
        /// </summary>
        CIRCLE,
        /// <summary>
        /// Прямоугольник
        /// </summary>
        RECTANGLE,
        /// <summary>
        /// Треугольник
        /// </summary>
        TRIANGLE,
        /// <summary>
        /// Шестиугольник
        /// </summary>
        HEXAGON
    }
}
