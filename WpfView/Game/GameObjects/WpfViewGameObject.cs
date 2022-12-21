using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game.GameObjects;
using Model.Game.GameObjects;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Shapes;
using WpfView.Utils;
using System.Windows.Controls;

namespace WpfView.Game.GameObjects
{
    public class WpfViewGameObject : ViewGameObject
    {

        private Shape _shape = null;

        public WpfViewGameObject(GameObject parGameObject) : base(parGameObject)
        {
            
        }

        private void Init()
        {
            _shape = WpfShapesCreator.CreateGameObjectView(GameObject);
        }

        public override void Draw()
        {
            Init();
        }

        protected override void RedrawGameObject()
        {
            if (GameObject.ID != Model.Enums.GameObjectTypes.HEXAGON
                && GameObject.ID != Model.Enums.GameObjectTypes.TRIANGLE)
            {
                X = GameObject.X - GameObject.Width / 2;
                Y = GameObject.Y - GameObject.Height / 2;
                Height = GameObject.Height;
                Width = GameObject.Width;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _shape.Width = Width;
                    _shape.Height = Height;
                    WpfShapesCreator.SetColorByState(GameObject.ID, GameObject.State, _shape);
                    Canvas.SetLeft(_shape, X);
                    Canvas.SetTop(_shape, Y);
                });
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {

                    WpfShapesCreator.SetColorByState(GameObject.ID, GameObject.State, _shape);
                });
            }
        }

        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_shape);
        }
    }
}
