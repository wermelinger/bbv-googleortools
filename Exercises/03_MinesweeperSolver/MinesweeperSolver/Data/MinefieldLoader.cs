using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MinesweeperSolver.Data
{
    internal static class MinefieldLoader
    {
        internal static Minefield LoadFromEmbeddedResource(string resourceName)
        {
            var minefieldAsText = LoadTextFromEmbeddedResource(resourceName);
            var minefield = ParseMinefield(minefieldAsText);
            return minefield;
        }

        private static string LoadTextFromEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                var resourceNames = string.Join("\n", assembly.GetManifestResourceNames());
                var message = string.Format($"Unknown resource name. Available resources:\n{resourceNames}");
                throw new MinesweeperException(message);
            }

            using var reader = new StreamReader(stream);
            var text = reader.ReadToEnd();

            return text;
        }

        internal static Minefield ParseMinefield(string minefieldAsText)
        {
            var isValid = Regex.IsMatch(minefieldAsText, "^[ 0-9X\r\n]*$");
            if (!isValid)
            {
                throw new MinesweeperException("Minefield text uses invalid characters.");
            }
            
            if (minefieldAsText.Length == 0)
            {
                throw new MinesweeperException("Minefield is empty.");
            }

            var lines = SplitInLines(minefieldAsText).ToList();

            var lineLengths = lines.Select(line => line.Length).Distinct().ToList();
            if (lineLengths.Count > 1)
            {
                throw new MinesweeperException("Not all rows of the minefield have the same column count");
            }

            var minefieldWidth = lineLengths.Single();
            var minefieldHeight = lines.Count;

            var minefield = new Minefield(minefieldWidth, minefieldHeight);

            for (var x = 0; x < minefieldWidth; x++)
            {
                for (var y = 0; y < minefieldHeight; y++)
                {
                    var character = lines[y][x];
                    if (char.IsDigit(character))
                    {
                        var numberOfDetectedMines = int.Parse(character.ToString());
                        minefield.PlaceMineDetector(x, y, numberOfDetectedMines);
                    }
                    if (character == 'X')
                    {
                        minefield.PlaceMine(x, y);
                    }
                }
            }

            return minefield;
        }

        private static IEnumerable<string> SplitInLines(string text)
        {
            var lines = new List<string>();
            using var stringReader = new StringReader(text);
           
            var currentLine = stringReader.ReadLine();
            while (currentLine != null)
            {
                lines.Add(currentLine);
                currentLine = stringReader.ReadLine();
            }

            return lines;
        }
    }
}
