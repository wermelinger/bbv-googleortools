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
        public void Solve02_Rule_NumberOfMinesInDetectionRadiusIsEqualsNumberOfMinesDetected()
        {
            // Arrange
            var solver = new MinesweeperConstraintsSolver();
            var minefield = MinefieldLoader.ParseMinefield("   " + Environment.NewLine +
                                                           "   " + Environment.NewLine +
                                                           "  3" + Environment.NewLine);

            // Act
            var solution = solver.Solve(minefield);

            // Assert
            solution.ToString().Should().Be("███" + Environment.NewLine +
                                            "█XX" + Environment.NewLine +
                                            "█X3" + Environment.NewLine);
        }

        [TestMethod]
        public void Solve03_Rule_NoMinesOnCellsWithMineDetector()
        {
            // Arrange
            var solver = new MinesweeperConstraintsSolver();
            var minefield = MinefieldLoader.ParseMinefield("   " + Environment.NewLine +
                                                           " 9 " + Environment.NewLine +
                                                           "   " + Environment.NewLine);

            // Act
            Action act = () => solver.Solve(minefield);

            // Assert
            act.Should().Throw<MinesweeperException>().WithMessage("No solution found.");
        }

        [TestMethod]
        public void Solve04_ComplexMinefield1()
        {
            // Arrange
            var minefield = MinefieldLoader.LoadFromEmbeddedResource("MinesweeperSolver.Minefields.Minefield1.txt");
            var solver = new MinesweeperConstraintsSolver();

            // Act
            var solution = solver.Solve(minefield);

            // Assert
            var expectedMinefield = MinefieldLoader.LoadFromEmbeddedResource("MinesweeperSolver.Minefields.Minefield1_Solution.txt");
            solution.ToString().Should().Be(expectedMinefield.ToString());
        }

        [TestMethod]
        public void Solve04_ComplexMinefield2()
        {
            // Arrange
            var minefield = MinefieldLoader.LoadFromEmbeddedResource("MinesweeperSolver.Minefields.Minefield2.txt");
            var solver = new MinesweeperConstraintsSolver();

            // Act
            var solution = solver.Solve(minefield);

            // Assert
            var expectedMinefield = MinefieldLoader.LoadFromEmbeddedResource("MinesweeperSolver.Minefields.Minefield2_Solution.txt");
            solution.ToString().Should().Be(expectedMinefield.ToString());
        }
    }
}