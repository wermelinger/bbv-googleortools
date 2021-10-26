using Google.OrTools.Sat;

namespace SimpleConstraints
{
    class CpSimple
    {
        static void Main(string[] args)
        {
            // Define Model
            var model = new CpModel();

            // Variables x,y,z with constraints 0 - 2
            var x = model.NewIntVar(0, 2, "x");
            var y = model.NewIntVar(0, 2, "y");
            var z = model.NewIntVar(0, 2, "z");

            // Constraint: Variables different
            // model.Add(x != y);
            // model.Add(x != z);
            // model.Add(y != z);
            model.AddAllDifferent(new[] { x, y, z });

            // Constraint: x lower y
            model.Add(x < y);

            // Constraint: The bigger x, the better!
            model.Maximize(x);

            // Solve: all feasible solutions
            var solver = new CpSolver();
            solver.SearchAllSolutions(model, new VarArraySolutionPrinter(new[] { x, y, z }));
        }
    }
}