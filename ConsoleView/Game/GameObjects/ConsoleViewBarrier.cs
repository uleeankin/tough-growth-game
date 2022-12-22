using ConsoleView.Utils;
using Model.Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Game.GameObjects;

namespace ConsoleView.Game.GameObjects
{
    /// <summary>
    /// Консольное представление препятствия
    /// </summary>
    public class ConsoleViewBarrier : ViewBarrier
    {
        /// <summary>
        /// Выводитель
        /// </summary>
        private Utils.GameCustomOutput _output = GameCustomOutput.GetInstance();

        /// <summary>
        /// Конструктор консольного представления препятствия
        /// </summary>
        /// <param name="parBarrier">Модель препятствия</param>
        public ConsoleViewBarrier(Barrier parBarrier) : base(parBarrier)
        {

        }

        /// <summary>
        /// Обработчик события рисования препятствия
        /// </summary>
        public override void Draw()
        {
            Console.OutputEncoding = Encoding.Unicode;
            X = ConsoleCoordinatesConverter.ConvertX(Barrier.X);
            Y = ConsoleCoordinatesConverter.ConvertY(Barrier.Y);
            _output.CreateBarrierView(Barrier, (int)X, (int)Y);
        }

        /// <summary>
        /// Обработчик события перерисовки препятствия
        /// </summary>
        protected override void RedrawBarrier()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int newX = ConsoleCoordinatesConverter.ConvertX(Barrier.X);
            int newY = ConsoleCoordinatesConverter.ConvertY(Barrier.Y);
            if ((newX != X || newY != Y) && newX >= 0 && newY >= 0)
            {
                _output.RedrawBarrier(Barrier, (int)X, (int)Y, newX, newY);
                X = newX;
                Y = newY;
            }
        }
    }
}
