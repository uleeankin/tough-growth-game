using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Shapes;
using View.Game.GameObjects;
using WpfView.Utils;

namespace WpfView.Game.GameObjects
{
    public class WpfViewBarrier : ViewBarrier
    {
        private Shape _shape = null;

        public Shape Shape
        {
            get
            {
                return _shape;
            }
        }

        public WpfViewBarrier(Barrier parBarrier) : base(parBarrier)
        {
        }

        private void Init()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _shape = WpfShapesCreator.CreateBarrierView(Barrier);
            });
        }

        public override void Draw()
        {
            Init();
        }

        protected override void RedrawBarrier()
        {
            if (Barrier.ID == Model.Enums.BarrierType.ARROW)
            {
                X = Barrier.X;
                Y = Barrier.Y;
                Application.Current.Dispatcher.Invoke(() =>
                {
                    WpfShapesCreator.SetBarrierColorByState(Barrier.ID, Barrier.State, _shape);
                    Canvas.SetLeft(_shape, X);
                    Canvas.SetTop(_shape, Y);
                });
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    WpfShapesCreator.SetBarrierColorByState(Barrier.ID, Barrier.State, _shape);
                    _shape = WpfShapesCreator.SetLineCoordinates(Barrier, _shape);
                });
            }

        }

        public void SetParentControl(FrameworkElement parControl)
        {
            Application.Current.Dispatcher.Invoke(() => {
                ((IAddChild)parControl).AddChild(_shape);
            });
        }
    }
}
