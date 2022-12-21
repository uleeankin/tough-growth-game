using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Игровой объект Круг
    /// </summary>
    public class Circle : GameObject
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parID">Тип игрового объекта</param>
        /// <param name="parIDName">Наименование типа</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parArea">Площадь</param>
        public Circle(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>Копия объекта класса Circle</returns>
        public override GameObject Clone()
        {
            Circle circle = new Circle(ID, IDName, X, Y, Area);
            return circle;
        }

        /// <summary>
        /// Устанавливает высоту круга
        /// </summary>
        public override void SetHeight()
        {
            Height = 2 * Math.Sqrt(Area / Math.PI);
        }

        /// <summary>
        /// Устанавливает ширину круга
        /// </summary>
        public override void SetWidth()
        {
            Width = 2 * Math.Sqrt(Area / Math.PI);
        }
    }
}
