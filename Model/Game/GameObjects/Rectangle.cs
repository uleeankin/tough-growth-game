using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Игровой объект прямоугольник
    /// </summary>
    public class Rectangle : GameObject
    {

        /// <summary>
        /// Начальная координата X для передвижения
        /// </summary>
        public double StartX { get; set; }
        /// <summary>
        /// Начальная координата Y для передвижения
        /// </summary>
        public double StartY { get; set; }
        /// <summary>
        /// Конечная координата X для передвижения
        /// </summary>
        public double EndX { get; set; }
        /// <summary>
        /// Конечная координата Y для передвижения
        /// </summary>
        public double EndY { get; set; }
        /// <summary>
        /// Ориентация прямоугольника на игровом поле 
        /// (вертикальная/горизонтальная)
        /// </summary>
        public int Orientation { get; set; }
        /// <summary>
        /// Флаг наличия движения
        /// </summary>
        public bool IsActiveMotion { get; set; }
        /// <summary>
        /// Направление движения
        /// </summary>
        public MotionType MotionDirection { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parID">Тип объекта</param>
        /// <param name="parIDName">Наименование типа</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parArea">Площадь</param>
        public Rectangle(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {
            IsActiveMotion = false;
        }

        /// <summary>
        /// Устанавливает высоту объекта
        /// </summary>
        public override void SetHeight()
        {
            if (Orientation == 1)
            {
                Height = Math.Sqrt(Area);
            }
            else
            {
                Height = Math.Sqrt(Area) * 4;
            }

        }

        /// <summary>
        /// Устанавливает ширину объекта
        /// </summary>
        public override void SetWidth()
        {
            if (Orientation == 1)
            {
                Width = Math.Sqrt(Area) * 4;
            }
            else
            {
                Width = Math.Sqrt(Area);
            }
        }

        /// <summary>
        /// Клонирует объект
        /// </summary>
        /// <returns>Возвращает копию объекта</returns>
        public override GameObject Clone()
        {
            Rectangle rectangle = new Rectangle(ID, IDName, X, Y, Area);
            rectangle.StartX = StartX;
            rectangle.StartY = StartY;
            rectangle.EndY = EndY;
            rectangle.EndX = EndX;
            rectangle.Orientation = Orientation;
            rectangle.Area = Area;
            return rectangle;
        }

        /// <summary>
        /// Двигает прямоугольник на заданный шаг
        /// </summary>
        /// <param name="parSpeed">Шаг</param>
        public void MoveByStep(double parSpeed)
        {
            if (IsActiveMotion)
            {
                if (Orientation == 1)
                {
                    if (MotionDirection == MotionType.LEFT)
                    {
                        X += parSpeed;
                    }

                    if (MotionDirection == MotionType.RIGHT)
                    {
                        X -= parSpeed;
                    }
                }
                else
                {
                    if (MotionDirection == MotionType.DOWN)
                    {
                        Y += parSpeed;
                    }

                    if (MotionDirection == MotionType.UP)
                    {
                        Y -= parSpeed;
                    }
                }
                CheckMotionDirection();
            }
            else
            {
                CheckMotionDirection();
            }
        }

        /// <summary>
        /// Проверяет направление движения
        /// </summary>
        private void CheckMotionDirection()
        {
            if (Orientation == 1)
            {
                if (X <= StartX)
                {
                    MotionDirection = MotionType.LEFT;
                }

                if (X >= EndX)
                {
                    MotionDirection = MotionType.RIGHT;
                }
            }
            else
            {
                if (Y <= StartY)
                {
                    MotionDirection = MotionType.DOWN;
                }

                if (Y >= EndY)
                {
                    MotionDirection = MotionType.UP;
                }
            }
        }
    }
}
