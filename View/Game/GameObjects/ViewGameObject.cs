using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Game.GameObjects;

namespace View.Game.GameObjects
{
    /// <summary>
    /// Базовое представление игрового объекта
    /// </summary>
    public abstract class ViewGameObject : View
    {
        /// <summary>
        /// Игровой объект
        /// </summary>
        private GameObject _gameObject = null;

        /// <summary>
        /// Игровой объект
        /// </summary>
        public GameObject GameObject
        {
            get
            {
                return _gameObject;
            }
        }

        /// <summary>
        /// Координата X на представлении
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Координата Y на представлении
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Ширина на представлении
        /// </summary>
        public double Width { get; protected set; }
        /// <summary>
        /// Высота на представлении
        /// </summary>
        public double Height { get; protected set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        public ViewGameObject(GameObject parGameObject)
        {
            _gameObject = parGameObject;
            _gameObject.Redraw += RedrawGameObject;
        }

        /// <summary>
        /// Обработчик события перерисовки игрового объекта
        /// </summary>
        protected abstract void RedrawGameObject();
    }
}
