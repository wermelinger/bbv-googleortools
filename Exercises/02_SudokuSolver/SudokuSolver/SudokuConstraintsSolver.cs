using Google.OrTools.Sat;
using SudokuSolver.Data;

namespace SudokuSolver
{
    internal class SudokuConstraintsSolver
    {
        internal Sudoku Solve(Sudoku sudoku)
        {
            // Initialize fields 9x9
            var fields = new IntVar[9][];
            for (int x = 0; x < fields.Length; x++)
            {
                fields[x] = new IntVar[9];
            }

            var model = new CpModel();

            // Constraint: Every cell contains a number 1-9
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {

                }
            }

            // Constraints: all cells in each column contain a different value
            foreach (var numbersInColumn in FieldsHelper.GetColumns(fields))
            {

            }

            // Constraint: all cells in each row contain a different value
            foreach (var numbersInRow in FieldsHelper.GetRows(fields))
            {

            }

            // Constraint: all cells in each box contain a different value
            foreach (var numbersInBox in FieldsHelper.GetBoxes(fields))
            {

            }

            // Add constraints of our specific sudoku
            foreach (var cellWithFixedNumber in sudoku.GetCellsWithValue())
            {

            }

            // Solve
            var solver = new CpSolver();
            solver.Solve(model);
            var solution = FieldsHelper.GetFieldValuesFromSolver(solver, fields);
            return new Sudoku(solution);
        }
    }
}