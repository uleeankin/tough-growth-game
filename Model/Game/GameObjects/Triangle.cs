using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Игровой объект Треугольник
    /// </summary>
    public class Triangle : GameObject
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parID">Тип объекта</param>
        /// <param name="parIDName">Наименование типа</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parArea">Площадь</param>
        public Triangle(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        /// <summary>
        /// Клонирует объект
        /// </summary>
        /// <returns>Возвращает копию объекта</returns>
        public override GameObject Clone()
        {
            Triangle triangle = new Triangle(ID, IDName, X, Y, Area);
            return triangle;
        }

        /// <summary>
        /// Устанавливает высоту объекта
        /// </summary>
        public override void SetHeight()
        {
            double a = Math.Sqrt((4 * Area) / Math.Sqrt(3));
            Height = Math.Sqrt(3 * Math.Pow(a, 2) / 4);
        }

        /// <summary>
        /// Устанавливает ширину объекта
        /// </summary>
        public override void SetWidth()
        {
            Width = Math.Sqrt((4 * Area) / Math.Sqrt(3));
        }
    }
}
