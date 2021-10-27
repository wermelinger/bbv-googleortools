using System.Collections.Generic;
using Google.OrTools.Sat;

namespace SudokuSolver
{
    /// <summary>
    /// Provides helper methods to access the solver-fields variables.
    /// </summary>
    internal static class FieldsHelper
    {
        public static IEnumerable<IEnumerable<IntVar>> GetColumns(IntVar[][] fields)
        {
            var columns = new List<IEnumerable<IntVar>>();
            for (int x = 0; x < fields.Length; x++)
            {
                // hint: 2 dimensional array -> list of y-positions must be different 
                var yPositionsOfColumn = fields[x];
                columns.Add(yPositionsOfColumn);
            }

            return columns;
        }

        public static IEnumerable<IEnumerable<IntVar>> GetRows(IntVar[][] fields)
        {
            var rows = new List<IEnumerable<IntVar>>();
            for (int y = 0; y < fields[0].Length; y++)
            {
                var row = new IntVar[9];
                for (int x = 0; x < fields.Length; x++)
                {
                    row[x] = fields[x][y];
                }
                rows.Add(row);
            }

            return rows;
        }

        public static IEnumerable<IEnumerable<IntVar>> GetBoxes(IntVar[][] fields)
        {
            var boxes = new List<IEnumerable<IntVar>>();
            for (int xBegin = 0; xBegin < 7; xBegin += 3)
            {
                for (int yBegin = 0; yBegin < 7; yBegin += 3)
                {
                    var box = new List<IntVar>();
                    for (int xOffset = 0; xOffset < 3; xOffset++)
                    {
                        for (int yOffset = 0; yOffset < 3; yOffset++)
                        {
                            box.Add(fields[xBegin + xOffset][yBegin + yOffset]);
                        }
                    }

                    boxes.Add(box);
                }
            }

            return boxes;
        }

        public static IList<int> GetFieldValuesFromSolver(CpSolver solver, IntVar[][] fields)
        {
            var solution = new List<int>();
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    var linearExpr = fields[x][y];
                    solution.Add(linearExpr == null ? 0 : (int)solver.Value(linearExpr));
                }
            }

            return solution;
        }
    }
}