using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Data
{
    public class Sudoku
    {
        private readonly Cell[][] cells = new Cell[9][];

        /// <summary>
        /// constructor that initializes the board with 81 cells
        /// </summary>
        /// <param name="cells">The cells to initialize the Sudoku. We use a list for easier access to cells,</param>
        public Sudoku(IList<int> cells)
        {
            var cellsList = cells.ToList();
            if (cellsList.Count != 81)
            {
                throw new ArgumentException("Sudoku should have exactly 81 cells", nameof(cells));
            }

            // Initialize cells 9x9
            for (int x = 0; x < 9; x++)
            {
                this.cells[x] = new Cell[9];
            }
            int y = 0;
            for (int i = 0; i < 81; i++)
            {
                int x = i - (y * 9);
                this.cells[x][y] = new Cell(x, y, cells[i]);
                if ((i + 1) % 9 == 0)
                {
                    y++;
                }
            }
        }

        /// <summary>
        /// Easy access by x and y
        /// </summary>
        /// <param name="x">X coordinate (between 0 and 8)</param>
        /// <param name="y">Y coordinate (between 0 and 8)</param>
        /// <returns>value of the cell</returns>
        public int GetCell(int x, int y)
        {
            return this.cells[x][y].Value;
        }

        /// <summary>
        /// Easy setter by x and y
        /// </summary>
        /// <param name="x">X coordinate (between 0 and 8)</param>
        /// <param name="y">Y coordinate (between 0 and 8)</param>
        /// <param name="value">value of the cell to set</param>
        public void SetCell(int x, int y, int value)
        {
            cells[x][y].Value = value;
        }

        /// <summary>
        /// Displays a Sudoku in an easy to read format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var lineSep = new string('-', 31);

            var output = new StringBuilder();
            output.Append(lineSep);
            output.AppendLine();

            for (int y = 0; y < 9; y++)
            {
                // we start each line with |
                output.Append("| ");
                for (int x = 0; x < 9; x++)
                {
                    var value = this.cells[x][y].Value;
                    output.Append(value);
                    //we identify boxes with | within lines
                    output.Append((x + 1) % 3 == 0 ? " | " : "  ");
                }
                
                output.AppendLine();
                if ((y + 1) % 3 == 0)
                {
                    output.Append(lineSep);
                }

                output.AppendLine();
            }

            return output.ToString();
        }

        public IEnumerable<Cell> GetAllCells()
        {
            return this.cells.SelectMany(x => x);
        }
        
        public IEnumerable<Cell> GetAllCellsInColumn(int x)
        {
            return this.cells[x];
        }
        
        public IEnumerable<Cell> GetAllCellsInRow(int y)
        {
            return this.cells.Select(col => col.ElementAt(y));
        }
        
        public IEnumerable<Cell> GetAllCellsInBox(int boxX, int boxY)
        {
            // TODO: 
        }

        public IEnumerable<Cell> GetCellsWithValue()
        {
            return this.GetAllCells().Where(cell => cell.Value != 0);
        }
    }
}