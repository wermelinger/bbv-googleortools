namespace MinesweeperSolver.Data
{
    internal class Cell
    {
        public int X { get; }

        public int Y { get; }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}