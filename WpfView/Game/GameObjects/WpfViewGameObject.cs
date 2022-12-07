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
            _shape = WpfShapesCreator.CreateGameObjectView(Object);
        }

        public override void Draw()
        {
            Init();
        }

        protected override void RedrawGameObject()
        {
            X = Object.X;
            Y = Object.Y;
            Height = Object.Height;
            Width = Object.Width;
            Application.Current.Dispatcher.Invoke(() =>
            {
                _shape.Width = Width;
                _shape.Height = Height;
                WpfShapesCreator.SetColorByState(Object.ID, Object.State, _shape);
                Canvas.SetLeft(_shape, X);
                Canvas.SetTop(_shape, Y);
            });
        }

        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_shape);
        }
    }
}
