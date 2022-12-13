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

        public void MoveByStep(double parSpeed, double parScreenHeight, double parScreenWidth)
        {
            if (MotionDirection == MotionType.UP)
            {
                if (Y >= 0)
                {
                    Y -= parSpeed;
                }
            }
            if (MotionDirection == MotionType.DOWN)
            {
                if (Y <= parScreenHeight - 60)
                {
                    Y += parSpeed;
                }
            }
            if (MotionDirection == MotionType.LEFT)
            {
                if (X >= 0)
                {
                    X -= parSpeed;
                }
            }
            if (MotionDirection == MotionType.RIGHT)
            {
                if (X <= parScreenWidth - 30)
                {
                    X += parSpeed;
                }
            }
        }

        public override GameObject Clone()
        {
            GameSquare gameSquare = new GameSquare(ID, IDName, X, Y, Area);
            return gameSquare;
        }
    
    }
}
