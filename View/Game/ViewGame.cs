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
        private Model.Game.GameScreen _gameScreen = null;

        private List<ViewGameObject> _gameObjects = null;

        protected ViewGameObject[] Objects => _gameObjects.ToArray();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewGameObject this[int parId]
        {
            get
            {
                return _gameObjects.Find((x) => (int)x.Object.ID == parId);
            }
        }

        public ViewGame(Model.Game.GameScreen parGameScreen)
        {
            _gameScreen = parGameScreen;
            _gameObjects = new List<ViewGameObject>();

            foreach (Model.Game.GameObjects.GameObject elGameObject in parGameScreen.GameObjects)
            {
                _gameObjects.Add(CreateGameObject(elGameObject));
            }
        }

        protected abstract void Redraw();
        protected abstract ViewGameObject CreateGameObject(Model.Game.GameObjects.GameObject parGameObject);
    }
}
