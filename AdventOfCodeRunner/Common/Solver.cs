using System;

namespace AdventOfCodeRunner.Common
{
    public static class Solver
    {
        public static void Solve(Day day, AdventOfCodeAttribute adventOfCodeAttribute)
        {
            Console.WriteLine($" Day {adventOfCodeAttribute.Day:D2} of {adventOfCodeAttribute.Year:D4} - {day.Name.ToUpper()} ");
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
