using System;
namespace Tetris
{
    public class TTetromino : Tetromino
    {
        public TTetromino()
        {
            _firstPosition = new bool[][]
            {
                new bool [] { true, true, true },
                new bool [] { false, true, false }
            };
            
            _secondPosition = new bool[][]
            {
                new bool [] { false, true },
                new bool [] { true, true },
                new bool [] { false, true }
            };
            
            _thirdPosition = new bool[][]
            {
                new bool [] { false, true, false },
                new bool [] { true, true, true}
            };
            
            _fourthPosition = new bool[][]
            {
                new bool [] { true, false, false, false},
                new bool [] { true, true, false, false },
                new bool [] { true, false, false, false },
            };
        }
    }
}
