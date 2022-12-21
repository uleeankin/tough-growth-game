using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Игровой квадрат 
    /// </summary>
    public class GameSquare : GameObject
    {

        /// <summary>
        /// Текущее направление движения
        /// </summary>
        private MotionType _motionDirection = MotionType.NO_MOTION;
        /// <summary>
        /// Текущее состояние в игре
        /// </summary>
        private GameObjectsStates _state = GameObjectsStates.NO_STATE;

        /// <summary>
        /// Текущее направление движения
        /// </summary>
        public MotionType MotionDirection
        {
            get
            {
                return _motionDirection;
            }
            set
            {
                _motionDirection = value;
            }
        }

        /// <summary>
        /// Текущее состояние в игре
        /// </summary>
        public override GameObjectsStates State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
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
        public GameSquare(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

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

        /// <summary>
        /// Двигает объект на заданный шаг
        /// </summary>
        /// <param name="parSpeed">Шаг</param>
        /// <param name="parScreenHeight">Высота игрового поля</param>
        /// <param name="parScreenWidth">Ширина игрового поля</param>
        public void MoveByStep(double parSpeed, double parScreenHeight, double parScreenWidth)
        {
            if (MotionDirection == MotionType.UP)
            {
                if (Y <= 0)
                {
                    Y = parScreenHeight;
                }
                Y -= parSpeed;
            }
            if (MotionDirection == MotionType.DOWN)
            {
                if (Y >= parScreenHeight)
                {
                    Y = 0;
                }
                Y += parSpeed;
            }
            if (MotionDirection == MotionType.LEFT)
            {
                if (X <= 0)
                {
                    X = parScreenWidth;
                }
                X -= parSpeed;
            }
            if (MotionDirection == MotionType.RIGHT)
            {
                if (X >= parScreenWidth)
                {
                    X = 0;
                }
                X += parSpeed;
            }
        }

        /// <summary>
        /// Клонирует объект
        /// </summary>
        /// <returns>Возвращает копию объекта</returns>
        public override GameObject Clone()
        {
            GameSquare gameSquare = new GameSquare(ID, IDName, X, Y, Area);
            return gameSquare;
        }
    
    }
}
