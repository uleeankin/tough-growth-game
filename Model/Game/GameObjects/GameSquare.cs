using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    public class GameSquare : GameObject
    {
        //private bool _isNeedStop = false;
        private MotionType _motionDirection = MotionType.NO_MOTION;
        private GameObjectsStates _state = GameObjectsStates.NO_STATE;
        public MotionType MotionDirection
        {
            get
            {
                return _motionDirection;
            }
            set
            {
                _motionDirection = value;
            }
        }
        public override GameObjectsStates State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public GameSquare(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        public override void SetHeight()
        {
            Height = Math.Sqrt(Area);
        }

        public override void SetWidth()
        {
            Width = Math.Sqrt(Area);
        }

        /*public void StartMotion(double parStep, double parScreenYBound, double parScreenXBound)
        {
            _isNeedStop = false;
            new Thread(() =>
            {
                while (!_isNeedStop)
                {
                    if (this.Y - parStep > 0
                            && this.Y + parStep < parScreenYBound
                            && this.X - parStep > 0
                            && this.X + parStep < parScreenXBound)
                    {
                        if (MotionDirection == MotionType.UP)
                        {
                            MoveUp(parStep);
                        }
                        if (MotionDirection == MotionType.DOWN)
                        {
                            MoveDown(parStep);
                        }
                        if (MotionDirection == MotionType.LEFT)
                        {
                            MoveLeft(parStep);
                        }
                        if (MotionDirection == MotionType.RIGHT)
                        {
                            MoveRight(parStep);
                        }
                    }

                    Console.WriteLine($"{X};{Y}");
                    Thread.Sleep(1000);
                }
            }
            ).Start();

        }*/

        /*public void ChangeDirection(MotionType parMotionType)
        {
            MotionDirection = parMotionType;
        }

        public void StopMotion()
        {
            _isNeedStop = true;
        }

        private void MoveUp(int parStep)
        {
            Y -= parStep;
        }

        private void MoveDown(int parStep)
        {
            Y += parStep;
        }
        private void MoveLeft(int parStep)
        {
            X -= parStep;
        }
        private void MoveRight(int parStep)
        {
            X += parStep;
        }*/
    }
}
