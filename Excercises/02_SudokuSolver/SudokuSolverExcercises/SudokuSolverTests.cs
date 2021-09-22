using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SudokuSolver;
using SudokuSolver.Data;

namespace SudokuSolverExcercises
{
    [TestClass]
    public class UnitTest1
    {
        private int[] initialGrid = { 0, 4, 0,   0, 6, 0,   0, 1, 0,
            7, 0, 0,   5, 0, 3,   0, 0, 2,
            0, 0, 3,   0, 2, 0,   7, 0, 0,

            0, 9, 0,   0, 7, 0,   0, 5, 0,
            1, 0, 2,   8, 0, 6,   4, 0, 3,
            0, 6, 0,   0, 3, 0,   0, 2, 0,

            0, 0, 4,   0, 1, 0,   6, 0, 0,
            6, 0, 0,   7, 0, 2,   0, 0, 1,
            0, 7, 0,   0, 5, 0,   0, 3, 0 };
        
        [TestMethod]
        public void Solve01_NoZerosAllowed()
        {
        
            // Arrange
            var sudoku = new Sudoku(initialGrid);
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(sudoku);

            // Assert
            solution.GetAllCells().Select(cell => cell.Value).Should().NotContain(0);
        }
    
        [TestMethod]
        public void Solve02_AllCellsInEachColumnContainDifferentValue()
        {
            // Arrange
            var sudoku = new Sudoku(initialGrid);
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(sudoku);

            // Assert
            for (int x = 0; x < 9; x++)
            {
                var cellsInColumn = solution.GetAllCellsInColumn(x);
                cellsInColumn.GroupBy(_ => _.Value).Count().Should().Be(9);
            }
        }

        [TestMethod]
        public void Solve03_AllCellsInEachRowContainDifferentValue()
        {
            // Arrange
            var sudoku = new Sudoku(initialGrid);
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(sudoku);

            // Assert
            for (int y = 0; y < 9; y++)
            {
                var cellsInColumn = solution.GetAllCellsInRow(y);
                cellsInColumn.GroupBy(_ => _.Value).Count().Should().Be(9);
            }
        }
        
        [TestMethod]
        public void Solve04_AllCellsInEachBoxContainDifferentValue()
        {
            // Arrange
            var sudoku = new Sudoku(initialGrid);
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(sudoku);

            // Assert
            for (var boxX = 0; boxX < 2; boxX++)
            {
                for (var boxY = 0; boxY < 2; boxY++)
                {
                    var cellsInColumn = solution.GetAllCellsInBox(boxX, boxY);
                    cellsInColumn.GroupBy(_ => _.Value).Count().Should().Be(9);
                }                
            }
        }
    }
}