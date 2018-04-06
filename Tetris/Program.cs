using System;
using System.Threading.Tasks;

namespace Tetris
{
    class Program
    {
        #region Constants
        const ConsoleColor DEFAULT_BACKGROUND_COLOR = ConsoleColor.Black;
        const ConsoleColor DEFAULT_FOREGROUND_COLOR = ConsoleColor.White;
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
        //static bool[][] _board;
        static Tuple<bool, ConsoleColor>[][] _coloredBoard;
        #endregion

        static void Main(string[] args)
        {
            Initialize();
            _currentTetromino = GetRandomTetromino();

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

                InitializeBoard();

                _timer = new System.Timers.Timer(1000);
                _timer.Elapsed += (sender, e) =>
                {
                    if (TetrominoCanMoveDown())
                    {
                        MoveTetrominoDown();
                    }
                    else
                    {
                        FillBoardWithBlocksFromCurrentTetromino();
                        // TODO: check if there are rows to be cleared
                        _currentTetromino = GetRandomTetromino();
                    }
                };
                    
                _timer.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void InitializeBoard()
        {
            //_board = new bool[_windowHeight][];
            _coloredBoard = new Tuple<bool, ConsoleColor>[_windowHeight][];

            for (int i = 0; i < _windowHeight; i++)
            {
                //_board[i] = new bool[_windowWidth];
                _coloredBoard[i] = new Tuple<bool, ConsoleColor>[_windowWidth];

                for (int j = 0; j < _windowWidth; j++)
                {
                    //_board[i][j] = false;
                    _coloredBoard[i][j] = new Tuple<bool, ConsoleColor>(false, DEFAULT_FOREGROUND_COLOR);
                }
            }
        }

        static void FillBoardWithBlocksFromCurrentTetromino()
        {
            var rows = _currentTetromino.Matrix.Length;
            var columns = _currentTetromino.Matrix[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 2 * columns; j += 2)
                {
                    if ((j % 2 == 0) && _currentTetromino.Matrix[i][j / 2])
                    {
                        //_board[_currentTetromino.Y + i][_currentTetromino.X + j] = true;
                        _coloredBoard[_currentTetromino.Y + i][_currentTetromino.X + j] = new Tuple<bool, ConsoleColor>(true, GetTetrominoColor());
                    }
                }
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
            _currentTetromino.X -= 2;
            DrawTetromino();
        }

        static void MoveTetrominoRight()
        {
            ClearTetromino();
            _currentTetromino.X += 2;
            DrawTetromino();
        }

        static void DrawTetromino()
        {
            var rows = _currentTetromino.Matrix.Length;
            var columns = _currentTetromino.Matrix[0].Length;

            // move tetromino to the left if rotation is invalid on the right edge
            if (_currentTetromino.X + 2 * columns - 1 >= _windowWidth)
            {
                _currentTetromino.X = _windowWidth - 2 * columns;
            }

            // TODO: fix rotation bug on the left side of blocks

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 2 * columns; j += 2)
                {
                    if ((j % 2 == 0) && _currentTetromino.Matrix[i][j / 2])
                    {
                        WriteAt(BLOCK, _currentTetromino.X + j, _currentTetromino.Y + i, GetTetrominoColor());
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

        static bool TetrominoCanMoveDown()
        {
            var rows = _currentTetromino.Matrix.Length;
            var columns = _currentTetromino.Matrix[0].Length;

            // tetromino hits the bottom of the screen
            if (_currentTetromino.Y + rows >= _windowHeight)
            {
                return false;
            }

            // check if Tetromino collides with other blocks
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 2 * columns; j += 2)
                {
                    if ((j % 2 == 0) && _currentTetromino.Matrix[i][j / 2])
                    {
                        if (_coloredBoard[_currentTetromino.Y + i + 1][_currentTetromino.X + j].Item1)
                        {
                            return false;
                        }
                        //if (_board[_currentTetromino.Y + i + 1][_currentTetromino.X + j])
                        //{
                        //    return false;
                        //}
                    }
                }
            }

            return true;
        }

        static bool TetrominoCanMoveToTheLeft()
        {
            var rows = _currentTetromino.Matrix.Length;
            var columns = _currentTetromino.Matrix[0].Length;

            // tetromino is on the left boundary
            if (_currentTetromino.X <= 0)
            {
                return false;
            }

            // check if Tetromino collides with other blocks
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 2 * columns; j += 2)
                {
                    if ((j % 2 == 0) && _currentTetromino.Matrix[i][j / 2])
                    {
                        if (_coloredBoard[_currentTetromino.Y + i][_currentTetromino.X + j - 2].Item1)
                        {
                            return false;
                        }
                        //if (_board[_currentTetromino.Y + i][_currentTetromino.X + j - 2])
                        //{
                        //    return false;
                        //}
                    }
                }
            }

            return true;
        }

        static bool TetrominoCanMoveToTheRight()
        {
            var rows = _currentTetromino.Matrix.Length;
            var columns = _currentTetromino.Matrix[0].Length;

            // tetromino is on the right boundary
            if (_currentTetromino.X + 2 * columns  >= _windowWidth)
            {
                return false;
            }

            // check if Tetromino collides with other blocks
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 2 * columns; j += 2)
                {
                    if ((j % 2 == 0) && _currentTetromino.Matrix[i][j / 2])
                    {
                        if (_coloredBoard[_currentTetromino.Y + i][_currentTetromino.X + j + 2].Item1)
                        {
                            return false;
                        }
                        //if (_board[_currentTetromino.Y + i][_currentTetromino.X + j + 2])
                        //{
                        //    return false;
                        //}
                    }
                }
            }

            return true;
        }

        static Tetromino GetRandomTetromino()
        {
            var random = new Random();
            var index = random.Next(1, 8);
            Tetromino tetromino;

            switch (index)
            {
                case 1:
                    tetromino = new ITetromino();
                    break;
                case 2:
                    tetromino = new JTetromino();
                    break;
                case 3:
                    tetromino = new LTetromino();
                    break;
                case 4:
                    tetromino = new OTetromino();
                    break;
                case 5:
                    tetromino = new STetromino();
                    break;
                case 6:
                    tetromino = new TTetromino();
                    break;
                case 7:
                    tetromino = new ZTetromino();
                    break;
                default:
                    tetromino = new ITetromino();
                    break;
            }

            tetromino.X = _windowWidth / 2;
            tetromino.Y = 0;
            tetromino.CurrentPosition = Position.First;


            return tetromino;
        }

        static ConsoleColor GetTetrominoColor()
        {
            var type = _currentTetromino.GetType();

            if (type == typeof(ITetromino))
            {
                return ConsoleColor.Red;
            }
            else if (type == typeof(JTetromino))
            {
                return ConsoleColor.Green;
            }
            else if (type == typeof(LTetromino))
            {
                return ConsoleColor.Blue;
            }
            else if (type == typeof(OTetromino))
            {
                return ConsoleColor.Cyan;
            }
            else if (type == typeof(STetromino))
            {
                return ConsoleColor.Magenta;
            }
            else if (type == typeof(TTetromino))
            {
                return ConsoleColor.Yellow;
            }
            else if (type == typeof(ZTetromino))
            {
                return ConsoleColor.Gray;
            }

            return DEFAULT_FOREGROUND_COLOR;
        }

        static void ReadKey()
        {
            ConsoleKeyInfo keyInfo;

            try
            {
                while (!_gameOver && (keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    if (TetrominoCanMoveDown())
                    {
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                RotateTetromino();
                                break;
                            case ConsoleKey.RightArrow:
                                if(TetrominoCanMoveToTheRight())
                                {
                                    MoveTetrominoRight();    
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                MoveTetrominoDown();
                                break;
                            case ConsoleKey.LeftArrow:
                                if (TetrominoCanMoveToTheLeft())
                                {
                                    MoveTetrominoLeft();
                                }
                                break;
                        }
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

// TODO: limit the width