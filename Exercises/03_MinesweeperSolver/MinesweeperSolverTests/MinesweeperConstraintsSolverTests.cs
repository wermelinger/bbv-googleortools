using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperSolver;
using MinesweeperSolver.Data;

namespace MinesweeperSolverTests
{
    [TestClass]
    public class MinesweeperConstraintsSolverTests
    {
        [TestMethod]
        public void Solve01_Rule_NoDetectors_NoMineOnField()
        {
            // Arrange
            var solver = new MinesweeperConstraintsSolver();
            var minefield = new Minefield(3, 3);

            // Act
            var solution = solver.Solve(minefield);

            // Assert
            solution.ToString().Should().Be("███" + Environment.NewLine +
                                            "███" + Environment.NewLine +
                                            "███" + Environment.NewLine);
        }

        [TestMethod]
        public void Solve02_Rule_DetectorsWith1NeighbouringMineAroundCorner_MineIsInTopRightCorner()
        {
            // Arrange
            var solver = new MinesweeperConstraintsSolver();
            var minefield = MinefieldLoader.ParseMinefield(" 1 " + Environment.NewLine +
                                                           " 11" + Environment.NewLine +
                                                           "   " + Environment.NewLine);

            // Act
            var solution = solver.Solve(minefield);

            // Assert
            solution.ToString().Should().Be("█1X" + Environment.NewLine +
                                            "█11" + Environment.NewLine +
                                            "███" + Environment.NewLine);
        }

        [TestMethod]
        public void Solve03_Rule_DetectorWith2NeighbouringMines_MinesAreInTopCorners()
        {
            // Arrange
            var solver = new MinesweeperConstraintsSolver();
            var minefield = MinefieldLoader.ParseMinefield(" 2 " + Environment.NewLine +
                                                           "121" + Environment.NewLine +
                                                           "   " + Environment.NewLine);

            // Act
            var solution = solver.Solve(minefield);

            // Assert
            solution.ToString().Should().Be("X2X" + Environment.NewLine +
                                            "121" + Environment.NewLine +
                                            "███" + Environment.NewLine);
        }
    }
}