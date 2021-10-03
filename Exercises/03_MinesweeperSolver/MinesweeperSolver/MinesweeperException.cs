using System;

namespace MinesweeperSolver
{
    internal class MinesweeperException : Exception
    {
        public MinesweeperException()
        {
        }

        public MinesweeperException(string message)
            : base(message)
        {
        }

        public MinesweeperException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
