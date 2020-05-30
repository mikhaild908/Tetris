using System;
namespace Tetris
{
    public class STetromino : Tetromino
    {
        public STetromino()
        {
            _firstPosition = new bool[][]
            {
                new bool [] { false, true, true },
                new bool [] { true, true, false }
            };            
                
            _secondPosition = new bool[][]
            {
                new bool [] { true, false },
                new bool [] { true, true},
                new bool [] { false, true}
            };
            
            _thirdPosition = new bool[][]
            {
                new bool [] { false, true, true }, 
                new bool [] { true, true, false }
            };
            
            _fourthPosition = new bool[][]
            {
                new bool [] { true, false },
                new bool [] { true, true },
                new bool [] { false, true }
            };
        }
    }
}
