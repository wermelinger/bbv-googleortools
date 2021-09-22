using System;
using Google.OrTools.Sat;

namespace SimpleConstraints
{
    public class VarArraySolutionPrinter : CpSolverSolutionCallback
    {
        private int solutionCount = 1;
        private readonly IntVar[] variables;

        public VarArraySolutionPrinter(IntVar[] variables)
        {
            this.variables = variables;
        }

        public override void OnSolutionCallback()
        {
            Console.WriteLine($"Solution #{solutionCount}: time = {WallTime():F2} s");
            foreach (IntVar v in variables)
            {
                Console.WriteLine($"  {v.ShortString()} = {Value(v)}");
            }
            solutionCount++;
        }
    }
}
