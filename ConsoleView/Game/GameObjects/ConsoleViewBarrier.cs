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
    public class ConsoleViewBarrier : ViewBarrier
    {

        private Utils.GameCastomOutput _output = GameCastomOutput.GetInstance();

        public ConsoleViewBarrier(Barrier parBarrier) : base(parBarrier)
        {

        }

        public override void Draw()
        {
            Console.OutputEncoding = Encoding.Unicode;
            X = ConsoleCoordinatesConverter.ConvertX(Barrier.X);
            Y = ConsoleCoordinatesConverter.ConvertY(Barrier.Y);
            _output.CreateBarrierView(Barrier, (int)X, (int)Y);
        }

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
