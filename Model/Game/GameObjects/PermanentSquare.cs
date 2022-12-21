using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Игровой объект Постоянный съедобный квадрат
    /// </summary>
    public class PermanentSquare : GameObject
    {
        /// <summary>
        /// Делегат на перемещение
        /// </summary>
        public delegate void dNeedNewPosition();
        /// <summary>
        /// Событие на перемещение
        /// </summary>
        public event dNeedNewPosition NeedNewPosition;

        /// <summary>
        /// Состояние объекта в игре
        /// </summary>
        private GameObjectsStates _state = GameObjectsStates.FOOD;

        /// <summary>
        /// Состояние объекта в игре
        /// </summary>
        public override GameObjectsStates State
        {
            get
            {
                return _state;
            }
            set
            {
                NeedNewPosition?.Invoke();
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parID">Тип объекта</param>
        /// <param name="parIDName">Наименование типа</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parArea">Площадь</param>
        public PermanentSquare(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        /// <summary>
        /// Клонирует объект
        /// </summary>
        /// <returns>Возвращает копию объекта</returns>
        public override GameObject Clone()
        {
            PermanentSquare permanentSquare = new PermanentSquare(ID, IDName, X, Y, Area);
            permanentSquare.State = State;
            return permanentSquare;
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
