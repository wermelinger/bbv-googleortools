using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperSolver.Data
{
    internal class Minefield
    {
        private readonly Cell[,] cells;

        public int Width { get; }
        public int Height { get; }

        public Minefield(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this.cells = new Cell[this.Width, this.Height];

            for (var x = 0; x < this.Width; x++)
            {
                for (var y = 0; y < this.Height; y++)
                {
                    this.cells[x,y] = new Cell(x, y);
                }
            }
        }

        public void PlaceMineDetector(int x, int y, int numberOfDetectedMines)
        {
            this.cells[x, y] = new CellWithMineDetector(x, y, numberOfDetectedMines);
        }

        public void PlaceMine(int x, int y)
        {
            this.cells[x, y] = new CellWithMine(x, y);
        }

        public IEnumerable<Cell> GetAllCells()
        {
            return this.cells.Cast<Cell>().ToArray();
        }

        public IEnumerable<Cell> GetCellsInDetectionRadius(CellWithMineDetector cellWithMineDetector)
        {
            var cellsInDetectionRadius = new List<Cell>();
            for (var xOffset = -1; xOffset <= 1; xOffset++)
            {
                for (var yOffset = -1; yOffset <= 1; yOffset++)
                {
                    var x = cellWithMineDetector.X + xOffset;
                    var y = cellWithMineDetector.Y + yOffset;
                    if (x >= 0 && y >=0 && x < this.Width && y < this.Height)
                    {
                        cellsInDetectionRadius.Add(this.cells[x, y]);
                    }
                }
            }

            return cellsInDetectionRadius;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            
            for (var y = 0; y < this.Height; y++)
            {
                for (var x = 0; x < this.Width; x++)
                {
                    var cell = this.cells[x,y];
                    if (cell is CellWithMineDetector cellWithMineDetector)
                    {
                        output.Append(cellWithMineDetector.NumberOfDetectedMines);
                    }
                    else
                    {
                        output.Append(cell is CellWithMine ? 'X' : '█');
                    }
                }
               
                output.AppendLine();
            }

            return output.ToString();
        }
    }
}