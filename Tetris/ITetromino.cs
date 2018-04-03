using System;
namespace Tetris
{
    public class ITetromino : Tetromino
    {
        public ITetromino()
        {
            _firstPosition = new bool[][]
            {
                new bool [] { true, true, true, true},
                //new bool [] { false, false, false, false },
                //new bool [] { false, false, false, false },
                //new bool [] { false, false, false, false }
           };

            _secondPosition = new bool[][]
            {
                new bool [] { true, },//false, false, false},
                new bool [] { true, },//false, false, false },
                new bool [] { true, },//false, false, false },
                new bool [] { true, }//false, false, false }
            };

            _thirdPosition = new bool[][]
            {
                new bool [] { true, true, true, true},
                //new bool [] { false, false, false, false },
                //new bool [] { false, false, false, false },
                //new bool [] { false, false, false, false }
            };

            _fourthPosition = new bool[][]
            {
                new bool [] { true, },//false, false, false},
                new bool [] { true, },//false, false, false },
                new bool [] { true, },//false, false, false },
                new bool [] { true, }//false, false, false }
                //new bool [] { true, false, false, false},
                //new bool [] { true, false, false, false },
                //new bool [] { true, false, false, false },
                //new bool [] { true, false, false, false }
            };
        }
    }
}
