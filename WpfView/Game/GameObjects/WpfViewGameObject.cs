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
    /// <summary>
    /// Представление игрового объекта в графической версии
    /// </summary>
    public class WpfViewGameObject : ViewGameObject
    {

        /// <summary>
        /// Фигура, представляющая игровой объект
        /// </summary>
        private Shape _shape = null;

        /// <summary>
        /// Конструктор прдставления игровых объектов графической версии
        /// </summary>
        /// <param name="parGameObject">Модель игрового объекта</param>
        public WpfViewGameObject(GameObject parGameObject) : base(parGameObject)
        {
            
        }

        /// <summary>
        /// Создает фигуры игрового объекта
        /// </summary>
        private void Init()
        {
            _shape = WpfShapesCreator.CreateGameObjectView(GameObject);
        }

        /// <summary>
        /// Обработчик события рисования игрового объекта
        /// </summary>
        public override void Draw()
        {
            Init();
        }

        /// <summary>
        /// Обработчик события перерисовки игрового объекта
        /// </summary>
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

        /// <summary>
        /// Размещает фигуру на игровом поле
        /// </summary>
        /// <param name="parControl"></param>
        public void SetParentControl(FrameworkElement parControl)
        {
            ((IAddChild)parControl).AddChild(_shape);
        }
    }
}
