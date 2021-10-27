namespace SudokuSolver.Data
{
    internal class Cell
    {
        public Cell(int x, int y, int value)
        {
            X = x;
            Y = y;
            this.Value = value;
        }

        public int Value { get; set; }

        public int X { get; }

        public int Y { get; }
    }
}