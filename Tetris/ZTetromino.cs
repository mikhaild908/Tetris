using System;
namespace Tetris
{
    public class ZTetromino : Tetromino
    {
        public ZTetromino()
        {
            _firstPosition = new bool[][]
            {
                new bool [] { true, true, false },
                new bool [] { false, true, true }, 
            };
            
            _secondPosition = new bool[][]
            {
                new bool [] { false, true },
                new bool [] { true, true },
                new bool [] { true, false }
            };
                
            _thirdPosition = new bool[][]
            {
                new bool [] { true, true, false },
                new bool[] { false, true, true }
            };
            
            _fourthPosition = new bool[][]
            {
                new bool [] { false, true },
                new bool [] { true, true },
                new bool [] { true, false }
            };
        }
    }
}
