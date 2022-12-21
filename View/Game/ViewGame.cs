using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game.GameObjects;

namespace View.Game
{
    /// <summary>
    /// Базовый класс представления игры
    /// </summary>
    public abstract class ViewGame : View
    {
        /// <summary>
        /// Список представлений игровых объектов
        /// </summary>
        private List<ViewGameObject> _gameObjects = null;

        /// <summary>
        /// Список представлений препятствий
        /// </summary>
        private List<ViewBarrier> _barriers = null;

        /// <summary>
        /// Список представлений игровых объектов
        /// </summary>
        protected List<ViewGameObject> GameObjects => _gameObjects;

        /// <summary>
        /// Список представлений препятствий
        /// </summary>
        protected List<ViewBarrier> Barriers
        {
            get
            {
                return _barriers;
            }
            set
            {
                _barriers = value;
            }
        }

        /// <summary>
        /// Координата X окна
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y окна
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина окна
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Высота окна
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Модель игры
        /// </summary>
        protected Model.Game.GameScreen Screen { get; set; }

        /// <summary>
        /// Конструктор представления игры
        /// </summary>
        /// <param name="parGameScreen">Модель игры</param>
        public ViewGame(Model.Game.GameScreen parGameScreen)
        {
            Screen = parGameScreen;
            Screen.NeedRedraw += Redraw;
            Screen.OnBarriersChange += OnBarriersChange;
            _gameObjects = new List<ViewGameObject>();
            _barriers = new List<ViewBarrier>();

            foreach (Model.Game.GameObjects.GameObject elGameObject in parGameScreen.GameObjects)
            {
                _gameObjects.Add(CreateGameObject(elGameObject));
            }
            foreach (Model.Game.GameObjects.Barrier elBarrier in parGameScreen.Barriers)
            {
                _barriers.Add(CreateBarrier(elBarrier));
            }
        }

        /// <summary>
        /// Базовый обработчик события перерисовки окна
        /// </summary>
        protected abstract void Redraw();

        /// <summary>
        /// Создает представление игрового объекта
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        /// <returns>Представление игрового объекта</returns>
        protected abstract ViewGameObject CreateGameObject(Model.Game.GameObjects.GameObject parGameObject);

        /// <summary>
        /// Создает представление препятствия
        /// </summary>
        /// <param name="parBarrier">Препятствие</param>
        /// <returns>Представление препятствия</returns>
        protected abstract ViewBarrier CreateBarrier(Model.Game.GameObjects.Barrier parBarrier);

        /// <summary>
        /// Обработчик события изменения количества препятствий на уровне
        /// </summary>
        protected abstract void OnBarriersChange();

        /// <summary>
        /// Очищает списки представлений игровых объектов и препятствий.
        /// В начале нового уровня.
        /// </summary>
        protected void ClearObjects()
        {
            _gameObjects = new List<ViewGameObject>();
            _barriers = new List<ViewBarrier>();
        }
    }
}
