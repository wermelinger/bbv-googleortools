using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using SudokuSolver.Data;

namespace SudokuSolverExercises
{
    [TestClass]
    public class SudokuSolverExercises
    {
        [TestMethod]
        public void Solve01_Rule_NoZerosAllowed()
        {
            // Arrange
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(new Sudoku(GenerateInitialGrid()));

            // Assert
            solution.GetAllCells().Select(cell => cell.Value).Should().NotContain(0);
        }
    
        [TestMethod]
        public void Solve02_Rule_AllCellsInEachColumnContainDifferentValue()
        {
            // Arrange
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(new Sudoku(GenerateInitialGrid()));

            // Assert
            for (int x = 0; x < 9; x++)
            {
                var cellsInColumn = solution.GetAllCellsInColumn(x);
                cellsInColumn.GroupBy(_ => _.Value).Count().Should().Be(9);
            }
        }

        [TestMethod]
        public void Solve03_Rule_AllCellsInEachRowContainDifferentValue()
        {
            // Arrange
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(new Sudoku(GenerateInitialGrid()));

            // Assert
            for (int y = 0; y < 9; y++)
            {
                var cellsInColumn = solution.GetAllCellsInRow(y);
                cellsInColumn.GroupBy(_ => _.Value).Count().Should().Be(9);
            }
        }
        
        [TestMethod]
        public void Solve04_Rule_AllCellsInEachBoxContainDifferentValue()
        {
            // Arrange
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(new Sudoku(GenerateInitialGrid()));

            // Assert
            for (var boxX = 0; boxX < 3; boxX++)
            {
                for (var boxY = 0; boxY < 3; boxY++)
                {
                    var cellsInColumn = solution.GetAllCellsInBox(boxX, boxY);
                    cellsInColumn.GroupBy(_ => _.Value).Count().Should().Be(9);
                }                
            }
        }

        [TestMethod]
        public void Solve05_SolveActualSudoku()
        {
            // Arrange
            var solver = new SudokuConstraintsSolver();

            // Act
            var solution = solver.Solve(new Sudoku(GenerateInitialGrid()));

            // Assert
            int[] expectedSolution = { 2, 4, 5,   9, 6, 7,   3, 1, 8,
                                       7, 1, 6,   5, 8, 3,   9, 4, 2,
                                       9, 8, 3,   4, 2, 1,   7, 6, 5,

                                       3, 9, 8,   2, 7, 4,   1, 5, 6,
                                       1, 5, 2,   8, 9, 6,   4, 7, 3,
                                       4, 6, 7,   1, 3, 5,   8, 2, 9,

                                       5, 2, 4,   3, 1, 8,   6, 9, 7,
                                       6, 3, 9,   7, 4, 2,   5, 8, 1,
                                       8, 7, 1,   6, 5, 9,   2, 3, 4 };
            solution.GetAllCells().Select(cell => cell.Value).Should().BeEquivalentTo(expectedSolution);
        }

        private int[] GenerateInitialGrid()
        {
            int[] initialGrid = { 0, 4, 0,   0, 6, 0,   0, 1, 0,
                                  7, 0, 0,   5, 0, 3,   0, 0, 2,
                                  0, 0, 3,   0, 2, 0,   7, 0, 0,

                                  0, 9, 0,   0, 7, 0,   0, 5, 0,
                                  1, 0, 2,   8, 0, 6,   4, 0, 3,
                                  0, 6, 0,   0, 3, 0,   0, 2, 0,

                                  0, 0, 4,   0, 1, 0,   6, 0, 0,
                                  6, 0, 0,   7, 0, 2,   0, 0, 1,
                                  0, 7, 0,   0, 5, 0,   0, 3, 0 };
            return initialGrid;
        }
    }
}