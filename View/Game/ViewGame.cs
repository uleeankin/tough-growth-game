using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game.GameObjects;

namespace View.Game
{
    public abstract class ViewGame : View
    {

        private List<ViewGameObject> _gameObjects = null;
        private List<ViewBarrier> _barriers = null;

        protected List<ViewGameObject> Objects => _gameObjects;
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

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        protected Model.Game.GameScreen Screen { get; set; }

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

        protected abstract void Redraw();
        protected abstract ViewGameObject CreateGameObject(Model.Game.GameObjects.GameObject parGameObject);
        protected abstract ViewBarrier CreateBarrier(Model.Game.GameObjects.Barrier parBarrier);
        protected abstract void OnBarriersChange();

        protected void ClearObjects()
        {
            _gameObjects = new List<ViewGameObject>();
            _barriers = new List<ViewBarrier>();
        }
    }
}
