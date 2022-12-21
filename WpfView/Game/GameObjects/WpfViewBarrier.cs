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
    /// <summary>
    /// Представление препятствий (wpf)
    /// </summary>
    public class WpfViewBarrier : ViewBarrier
    {
        /// <summary>
        /// Фигура, представляющая препятствие
        /// </summary>
        private Shape _shape = null;

        /// <summary>
        /// Фигура, представляющая препятствие
        /// </summary>
        public Shape Shape
        {
            get
            {
                return _shape;
            }
        }

        /// <summary>
        /// Конструктор прдставления препятствий графической версии
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        public WpfViewBarrier(Barrier parBarrier) : base(parBarrier)
        {
        }

        /// <summary>
        /// Создает фигуры препятствия
        /// </summary>
        private void Init()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _shape = WpfShapesCreator.CreateBarrierView(Barrier);
            });
        }

        /// <summary>
        /// Обработчик события рисования препятствия
        /// </summary>
        public override void Draw()
        {
            Init();
        }

        /// <summary>
        /// Обработчик события перерисовки препятствия
        /// </summary>
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

        /// <summary>
        /// Размещает фигуру на игровом поле
        /// </summary>
        /// <param name="parControl"></param>
        public void SetParentControl(FrameworkElement parControl)
        {
            Application.Current.Dispatcher.Invoke(() => {
                ((IAddChild)parControl).AddChild(_shape);
            });
        }
    }
}
