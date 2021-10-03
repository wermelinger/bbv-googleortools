using System;
using MinesweeperSolver.Data;

namespace MinesweeperSolver
{
    public class MinesweeperProgram
    {
        public static void Main()
        {
            try
            {
                var minefield = MinefieldLoader.LoadFromEmbeddedResource("MinesweeperSolver.Minefields.Minefield1.txt");
                var solver = new MinesweeperConstraintsSolver();
                var solution = solver.Solve(minefield);

                Console.WriteLine(solution.ToString());

            }
            catch (MinesweeperException minesweeperException)
            {
                Console.WriteLine(minesweeperException.Message);
            }

        }
    }
}