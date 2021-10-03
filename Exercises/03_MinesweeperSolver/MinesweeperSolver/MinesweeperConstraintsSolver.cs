using Google.OrTools.Sat;

using MinesweeperSolver.Data;

namespace MinesweeperSolver
{
    internal class MinesweeperConstraintsSolver
    {
        internal Minefield Solve(Minefield minefield)
        {
            var model = new CpModel();

            // Solve
            var solver = new CpSolver();
            var status = solver.Solve(model);

            if (status == CpSolverStatus.Infeasible)
            {
                throw new MinesweeperException("No solution found.");
            }

            // Update minefield with solution
            for (var x = 0; x < minefield.Width; x++)
            {
                for (var y = 0; y < minefield.Height; y++)
                {
                    // Call method below if solver found a mine at the coordinates.
                    // minefield.PlaceMine(x, y);
                }
            }
            
            return minefield;
        }

    }
}