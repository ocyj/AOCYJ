using System;
using System.Linq;
using System.Reflection;

namespace AdventOfCodeRunner.Common
{
    public static class Solver
    {
        public static void Solve(Day day)
        {
            var aocAttribute = day.GetType().GetCustomAttributes(typeof(AdventOfCodeAttribute)).FirstOrDefault() as AdventOfCodeAttribute;
            if (aocAttribute == null)
            {
                throw new ArgumentException(
                    $"Cannot solve on day type without {nameof(AdventOfCodeAttribute)} attribute set");
            }
            Console.WriteLine($" Day {aocAttribute.Day:D2} of {aocAttribute.Year:D4} - {day.Name.ToUpper()} ");
            Console.WriteLine();

            Console.Write($"\tPart 1 answer:");
            try
            {
                Console.WriteLine($"\t{day.SolvePart1()}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"\tNOT SOLVED YET!");
            }

            Console.Write($"\tPart 2 answer:");
            try
            {
                Console.WriteLine($"\t{day.SolvePart2()}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"\tNOT SOLVED YET!");
            }
            Console.WriteLine("=============================================");
        }
    }
}
