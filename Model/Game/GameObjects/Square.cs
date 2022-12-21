using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Игровой объект Квадрат
    /// </summary>
    public class Square : GameObject
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parID">Тип объекта</param>
        /// <param name="parIDName">Наименование типа</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parArea">Площадь</param>
        public Square(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        /// <summary>
        /// Клонирует объект
        /// </summary>
        /// <returns>Возвращает копию объекта</returns>
        public override GameObject Clone()
        {
            Square square = new Square(ID, IDName, X, Y, Area);
            return square;
        }

        /// <summary>
        /// Устанавливает высоту объекта
        /// </summary>
        public override void SetHeight()
        {
            Height = Math.Sqrt(Area);
        }

        /// <summary>
        /// Устанавливает ширину объекта
        /// </summary>
        public override void SetWidth()
        {
            Width = Math.Sqrt(Area);
        }
    }
}
