namespace MinesweeperSolver.Data
{
    internal class CellWithMineDetector : Cell
    {
        public int NumberOfDetectedMines { get; }

        public CellWithMineDetector(int x, int y, int numberOfDetectedMines) : base (x, y)
        {
            this.NumberOfDetectedMines = numberOfDetectedMines;
        }
    }
}
