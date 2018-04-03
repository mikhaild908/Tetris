using System;
namespace Tetris
{
    public class JTetromino : Tetromino
    {
        public JTetromino()
        {
            _firstPosition = new bool[][]
            {
                new bool [] { false, true }, // false, false },
                new bool [] { false, true }, // false, false },
                new bool [] { true, true } //false, false },
                //new bool [] { false, false, false, false }
           };

            _secondPosition = new bool[][]
            {
                new bool [] { true, false, false }, // false, false, false},
                new bool [] { true, true, true },// false },
                //new bool [] { false, false, false, false },
                //new bool [] { false, false, false, false }
            };

            _thirdPosition = new bool[][]
            {
                new bool [] { true, true }, //  false, false},
                new bool [] { true, false}, // false, false, false },
                new bool [] { true, false } // false, false, false },
                //new bool [] { false, false, false, false }
            };

            _fourthPosition = new bool[][]
            {
                new bool [] { true, true, true }, // false},
                new bool [] { false, false, true } // false },
                //new bool [] { false, false, false, false },
                //new bool [] { false, false, false, false }
            };
        }
    }
}
