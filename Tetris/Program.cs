using System;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        #region Constants
        const ConsoleColor DEFAULT_BACKGROUND_COLOR = ConsoleColor.Black;
        const ConsoleColor DEFAULT_FOREGROUND_COLOR = ConsoleColor.Green;
        const string BLOCK = "*";
        const string SPACE = " ";
        #endregion

        #region Private Members
        static int _windowWidth;
        static int _windowHeight;
        static int _origX;
        static int _origY;
        static System.Timers.Timer _timer;
        static bool _gameOver = false;
        static Tetromino _currentTetromino;
        #endregion

        static void Main(string[] args)
        {
            Initialize();

            _currentTetromino = new ZTetromino()
            {
                X = _windowWidth / 2,
                Y = 0,
                CurrentPosition = Position.First
            };

            ReadKey();
        }

        static void Initialize()
        {
            try
            {
                Console.CursorVisible = false;

                Console.ForegroundColor = DEFAULT_FOREGROUND_COLOR;
                Console.BackgroundColor = DEFAULT_BACKGROUND_COLOR;
                Console.Clear();

                _origY = Console.CursorTop;
                _origX = Console.CursorLeft;

                _windowWidth = Console.WindowWidth;
                _windowHeight = Console.WindowHeight;

                //_currX = _windowWidth / 2;
                //_currY = _windowHeight;

                _timer = new System.Timers.Timer(1000);
                _timer.Elapsed += (sender, e) => MoveTetrominoDown();
                _timer.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void WriteAt(string s, int x, int y,
                            ConsoleColor foregroundColor = DEFAULT_FOREGROUND_COLOR,
                            ConsoleColor backgroundColor = DEFAULT_BACKGROUND_COLOR)
        {
            try
            {
                if (_origX + x > _windowWidth || _origX + x < 0
                    || _origY + y > _windowHeight || _origY + y < 0)
                {
                    return;
                }

                Console.ForegroundColor = foregroundColor;
                Console.SetCursorPosition(_origX + x, _origY + y);

                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    
        static void MoveTetrominoDown()
        {
            ClearTetromino();
            _currentTetromino.Y += 1;
            DrawTetromino();
        }

        static void MoveTetrominoLeft()
        {
            ClearTetromino();
            _currentTetromino.X -= 1;
            DrawTetromino();
        }

        static void MoveTetrominoRight()
        {
            ClearTetromino();
            _currentTetromino.X += 1;
            DrawTetromino();
        }

        static void DrawTetromino()
        {
            var rows = _currentTetromino.Matrix.Length;
            var columns = _currentTetromino.Matrix[0].Length; 

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 2 * columns; j += 2)
                {
                    if ((j % 2 == 0) && _currentTetromino.Matrix[i][j / 2])
                    {
                        WriteAt(BLOCK, _currentTetromino.X + j, _currentTetromino.Y + i);
                    }
                }
            }
        }

        static void ClearTetromino()
        {
            var rows = _currentTetromino.Matrix.Length;
            var columns = _currentTetromino.Matrix[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 2 * columns; j += 2)
                {
                    if ((j % 2 == 0) && _currentTetromino.Matrix[i][j / 2])
                    {
                        WriteAt(SPACE, _currentTetromino.X + j, _currentTetromino.Y + i);
                    }
                }
            }
        }

        static void RotateTetromino()
        {
            ClearTetromino();
            _currentTetromino.Rotate();
            DrawTetromino();
        }

        static void ReadKey()
        {
            ConsoleKeyInfo keyInfo;

            try
            {
                while (!_gameOver && (keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            RotateTetromino();
                            break;
                        case ConsoleKey.RightArrow:
                            MoveTetrominoRight();
                            break;
                        case ConsoleKey.DownArrow:
                            MoveTetrominoDown();
                            break;
                        case ConsoleKey.LeftArrow:
                            MoveTetrominoLeft();
                            break;
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
