using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    /// <summary>
    /// Базовый класс игровых объектов
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Делегат на перерисовку
        /// </summary>
        public delegate void dRedraw();
        /// <summary>
        /// Событие на перерисовку
        /// </summary>
        public event dRedraw Redraw = null;

        /// <summary>
        /// Координата X
        /// </summary>
        private double _x;
        /// <summary>
        /// Координата Y
        /// </summary>
        private double _y;
        /// <summary>
        /// Площадь
        /// </summary>
        private double _area;
        /// <summary>
        /// Состояние объекта в игре
        /// </summary>
        private GameObjectsStates _state = GameObjectsStates.INACTIVE;

        public GameObjectTypes ID { get; set; }
        public string IDName { get; set; }

        /// <summary>
        /// Координата X
        /// </summary>
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Координата Y
        /// </summary>
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Площадь
        /// </summary>
        public double Area
        {
            get
            {
                return _area;
            }
            set
            {
                _area = value;
                SetHeight();
                SetWidth();
            }
        }

        /// <summary>
        /// Состояние объекта в игре
        /// </summary>
        public virtual GameObjectsStates State
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
        /// Высота объекта
        /// </summary>
        public double Height { get; protected set; }

        /// <summary>
        /// Ширина объекта
        /// </summary>
        public double Width { get; protected set; }
        
        /// <summary>
        /// Базовый конструктор
        /// </summary>
        /// <param name="parID">Тип объекта</param>
        /// <param name="parIDName">Наименование типа</param>
        /// <param name="parX">Координата X</param>
        /// <param name="parY">Координата Y</param>
        /// <param name="parArea">Площадь</param>
        public GameObject(GameObjectTypes parID, string parIDName, 
                        double parX, double parY, double parArea)
        {
            ID = parID;
            IDName = parIDName;
            X = parX;
            Y = parY;
            Area = parArea;
        }

        /// <summary>
        /// Клонировать объект
        /// </summary>
        /// <returns></returns>
        public abstract GameObject Clone();
        /// <summary>
        /// Установить высоту
        /// </summary>
        public abstract void SetHeight();
        /// <summary>
        /// Установить ширину
        /// </summary>
        public abstract void SetWidth();

        /// <summary>
        /// Вызывает событие перерисовки игрового объекта
        /// </summary>
        public void RedrawGameObject()
        {
            Redraw?.Invoke();
        }
    }
}
