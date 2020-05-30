using System;
namespace Tetris
{
    public class OTetromino : Tetromino
    {
        public OTetromino() {
            _firstPosition = new bool[][]
            { 
                new bool [] { true, true },
                new bool [] { true, true }
            };

            _secondPosition = new bool[][]
            {
                new bool [] { true, true },
                new bool [] { true, true }
            };
            
            _thirdPosition = new bool[][]
            {
                new bool [] { true, true },
                new bool [] { true, true }
            };
            
            _fourthPosition = new bool[][]
            {
                new bool [] { true, true },
                new bool [] { true, true }
            };
        }
    }
}
