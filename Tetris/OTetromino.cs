using System;
namespace Tetris
{
    public class OTetromino : Tetromino
    {
        public OTetromino()         {             _firstPosition = new bool[][]             {                 new bool [] { true, true }, // false, false } ,                 new bool [] { true, true } // false, false } ,                 //new bool [] { false, false, false, false } ,                 //new bool [] { false, false, false, false }            };              _secondPosition = new bool[][]             {                 new bool [] { true, true }, // false, false } ,
                new bool [] { true, true } // false, false } ,
                //new bool [] { false, false, false, false } ,
                //new bool [] { false, false, false, false }             };              _thirdPosition = new bool[][]             {                 new bool [] { true, true }, // false, false } ,
                new bool [] { true, true } // false, false } ,
                //new bool [] { false, false, false, false } ,
                //new bool [] { false, false, false, false }             };              _fourthPosition = new bool[][]             {                 new bool [] { true, true }, // false, false } ,
                new bool [] { true, true } // false, false } ,
                //new bool [] { false, false, false, false } ,
                //new bool [] { false, false, false, false }             };         } 
    }
}
