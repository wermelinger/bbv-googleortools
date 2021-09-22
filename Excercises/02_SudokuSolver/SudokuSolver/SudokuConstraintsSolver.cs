using System;
using Google.OrTools.Sat;
using SudokuSolver.Data;

namespace SudokuSolver
{
    public class SudokuConstraintsSolver
    {
        public Sudoku Solve(Sudoku sudoku)
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
                    fields[x][y] = model.NewIntVar(1, 9, $"{x}-{y}");
                }
            }

            // Constraints: all cells in each column contain a different value
            foreach (var numbersInColumn in FieldsHelper.GetColumns(fields))
            {
                model.AddAllDifferent(numbersInColumn);
            }

            // Constraint: all cells in each row contain a different value
            foreach (var numbersInRow in FieldsHelper.GetRows(fields))
            {
                model.AddAllDifferent(numbersInRow);
            }

            // Constraint: all cells in each box contain a different value
            foreach (var numbersInBox in FieldsHelper.GetBoxes(fields))
            {
                //model.AddAllDifferent(numbersInBox);
            }

            // Add constraints of our specific sudoku
            foreach (var cellWithFixedNumber in sudoku.GetCellsWithValue())
            {
                //model.Add(fields[cellWithFixedNumber.X][cellWithFixedNumber.Y] == cellWithFixedNumber.Value);
            }

            // Solve
            var solver = new CpSolver();
            solver.Solve(model);
            var solution = FieldsHelper.GetFieldValuesFromSolver(solver, fields);
            return new Sudoku(solution);

            throw new InvalidOperationException("Sudoku not solvable");
        }
    }
}