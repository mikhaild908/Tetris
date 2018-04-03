using System;
namespace Tetris
{
    public abstract class Tetromino
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected bool[][] _firstPosition;
        protected bool[][] _secondPosition;
        protected bool[][] _thirdPosition;
        protected bool[][] _fourthPosition;

        protected bool[][] FirstPosition { get { return _firstPosition; } }
        protected virtual bool[][] SecondPosition { get { return _secondPosition; } }
        protected virtual bool[][] ThirdPosition { get { return _thirdPosition; } }
        protected virtual bool[][] FourthPosition { get { return _fourthPosition; } }

        public Position CurrentPosition { get; set; } = Position.First;

        public void Rotate()
        {
            switch (CurrentPosition)
            {
                case Position.First:
                    CurrentPosition = Position.Second;
                    break;
                case Position.Second:
                    CurrentPosition = Position.Third;
                    break;
                case Position.Third:
                    CurrentPosition = Position.Fourth;
                    break;
                case Position.Fourth:
                    CurrentPosition = Position.First;
                    break;
                default:
                    CurrentPosition = Position.First;
                    break;
            }
        }

        public bool[][] Matrix
        {
            get
            {
                switch (CurrentPosition)
                {
                    case Position.First:
                        return FirstPosition;
                    case Position.Second:
                        return SecondPosition;
                    case Position.Third:
                        return ThirdPosition;
                    case Position.Fourth:
                        return FourthPosition;
                    default:
                        return FirstPosition;
                }    
            }
        }
    }
}