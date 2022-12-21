using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Класс выдаваемого препятствия
    /// </summary>
    public class Barrier
    {
        /// <summary>
        /// Делегат на перерисовку
        /// </summary>
        public delegate void dRedraw();
        /// <summary>
        /// Событие перерисовки
        /// </summary>
        public event dRedraw Redraw = null;

        /// <summary>
        /// Состояние объекта на поле (активен/неактивен)
        /// </summary>
        private GameObjectsStates _state;

        /// <summary>
        /// Тип препятствия
        /// </summary>
        public BarrierType ID { get; set; }

        /// <summary>
        /// Текущее положение на оси X
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Текущее положение на оси Y 
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Координата начала движения по оси Х
        /// </summary>
        public double StartX { get; set; }

        /// <summary>
        /// Координата начала движения по оси Y
        /// </summary>
        public double StartY { get; set; }

        /// <summary>
        /// Координата конца движения по оси Х
        /// </summary>
        public double EndX { get; set; }

        /// <summary>
        /// Координата конца движения по оси Y
        /// </summary>
        public double EndY { get; set; }

        /// <summary>
        /// Ширина препятствия
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Высота препятствия
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Родительский объект (выпускающий препятствие)
        /// </summary>
        public GameObject Parent { get; set; }

        /// <summary>
        /// Состояние объекта на поле (активен/неактивен) 
        /// </summary>
        public GameObjectsStates State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                Redraw?.Invoke();
            }
        }

        /// <summary>
        /// Конструктор для препятствий вида - преследующая стрелка
        /// </summary>
        /// <param name="parBarrierType">Вид препятствия</param>
        /// <param name="parEndX">Конечная координата X</param>
        /// <param name="parEndY">Конечная координата Y</param>
        /// <param name="parWidth">Ширина</param>
        /// <param name="parHeight">Высота</param>
        /// <param name="parParent">Родитель</param>
        public Barrier(BarrierType parBarrierType,
            double parEndX, double parEndY,
            double parWidth, double parHeight,
            GameObject parParent)
        {
            ID = parBarrierType;
            StartX = parParent.X;
            StartY = parParent.Y;
            X = StartX;
            Y = StartY;
            EndX = parEndX;
            EndY = parEndY;
            Width = parWidth;
            Height = parHeight;
            State = GameObjectsStates.BARRIER;
            Parent = parParent;
        }

        /// <summary>
        /// Конструктор для препятствий вида - короткий / длинный выстрел
        /// </summary>
        /// <param name="parBarrierType">Вид препятствия</param>
        /// <param name="parEndX">Конечная координата X</param>
        /// <param name="parEndY">Конечная координата Y</param>
        /// <param name="parWidth">Ширина</param>
        /// <param name="parHeight">Высота</param>
        /// <param name="parParent">Родитель</param>
        /// <param name="parScreenHeight">Высота поля игры</param>
        /// <param name="parScreenWidth">Ширина поля игры</param>
        public Barrier(BarrierType parBarrierType,
            double parEndX, double parEndY,
            double parWidth, double parHeight,
            GameObject parParent,
            double parScreenHeight, double parScreenWidth)
        {
            ID = parBarrierType;
            StartX = parParent.X;
            StartY = parParent.Y;
            X = StartX;
            Y = StartY;
            EndX = parEndX;
            EndY = parEndY;
            GetEndCoordinates(parScreenHeight, parScreenWidth);
            Width = parWidth;
            Height = parHeight;
            State = GameObjectsStates.BARRIER;
            Parent = parParent;
        }

        /// <summary>
        /// Установка конечных координат короткого и длинного выстрелов
        /// </summary>
        /// <param name="parScreenHeight">Высота игрового поля</param>
        /// <param name="parScreenWidth">Ширина игрового поля</param>
        private void GetEndCoordinates(double parScreenHeight, double parScreenWidth)
        {
            if (X > EndX)
            {
                EndX = 0;
            }
            else
            {
                EndX = parScreenWidth;
            }
            if (Y > EndY)
            {
                EndY = 0;
            }
            else
            {
                EndY = parScreenHeight;
            }
        }

        /// <summary>
        /// Движение препятствия по полю
        /// </summary>
        /// <param name="parSpeed"></param>
        public void MoveByStep(double parSpeed)
        {

            if (State == GameObjectsStates.BARRIER)
            {
                if (X > EndX)
                {
                    X -= parSpeed;
                }
                else
                {
                    X += parSpeed;
                }
                if (Y > EndY)
                {
                    Y -= parSpeed;
                }
                else
                {
                    Y += parSpeed;
                }
                Redraw?.Invoke();
            }
        }
    }
}
