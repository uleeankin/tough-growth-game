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

        private Dictionary<int, ViewGameObject> _gameObjects = null;

        protected ViewGameObject[] Objects => _gameObjects.Values.ToArray();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public ViewGameObject this[int parId]
        {
            get
            {
                return _gameObjects[parId];
            }
        }

        public ViewGame(Model.Game.GameScreen parGameScreen)
        {
            _gameScreen = parGameScreen;
            _gameObjects = new Dictionary<int, ViewGameObject>();

            foreach (Model.Game.GameObjects.GameObject elGameObject in parGameScreen.GameObjects)
            {
                _gameObjects.Add((int)elGameObject.ID, CreateGameObject(elGameObject));
            }
        }

        protected abstract void Redraw();
        protected abstract ViewGameObject CreateGameObject(Model.Game.GameObjects.GameObject parGameObject);
    }
}
