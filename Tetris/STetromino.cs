using System;
namespace Tetris
{
    public class STetromino : Tetromino
    {
        public STetromino()         {             _firstPosition = new bool[][]             {                 new bool [] { false, true, true },// false } ,                 new bool [] { true, true, false }// false } ,                 //new bool [] { false, false, false, false } ,                 //new bool [] { false, false, false, false }            };              _secondPosition = new bool[][]             {                 new bool [] { true, false }, // false, false} ,                 new bool [] { true, true}, // false, false } ,                 new bool [] { false, true} // false, false } ,                 //new bool [] { false, false, false, false }             };              _thirdPosition = new bool[][]             {                 new bool [] { false, true, true }, // false} ,                 new bool [] { true, true, false } // false } ,                 //new bool [] { false, false, false, false } ,                 //new bool [] { false, false, false, false }             };              _fourthPosition = new bool[][]             {                 new bool [] { true, false }, // false, false} ,                 new bool [] { true, true }, // false, false } ,                 new bool [] { false, true }, // false, false } ,                 //new bool [] { false, false, false, false }             };         } 
    }
}
