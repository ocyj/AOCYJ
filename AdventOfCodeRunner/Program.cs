using System;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCodeFSharp.AOC2024;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Running AdventOfCodeRunner");
            //AdventOfCodeFSharp.Common.runSolver(Day01.solver);
            var isSafe = Day02.isSafeIncreasing(Day02.report);
            Console.WriteLine("Day 2 report is: " + isSafe);
            Console.WriteLine("Bye");
            return;

            var dayToTry = DateTime.Today;

            while (dayToTry.Day > 0)
            {
                if (TryGetDay(dayToTry, out var dayType))
                {
                    // Do this once for entire assembly? Use line below to get all resource names
                    // string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
                    var resourceStream = Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"AdventOfCodeRunner.AOC{dayToTry.Year:D4}.input.input{dayToTry.Day:D2}.txt");
                    if (resourceStream != null)
                    {
                        var streamReader = new StreamReader(resourceStream);

                        var input = streamReader.ReadToEnd().Trim().Split(Environment.NewLine);
                        var day = Activator.CreateInstance(dayType, new object[] { input }) as Day;
                        Solver.Solve(day);
                        return;
                    }
                }
                else
                {
                    dayToTry = dayToTry.AddDays(-1);
                }
            }

            Console.WriteLine("Couldn't find any days to run!");
        }

        private static bool TryGetDay(DateTime dayToGet, out Type day)
        {
            day = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Day))).FirstOrDefault(t =>
                    t.GetCustomAttribute(typeof(AdventOfCodeAttribute)) is AdventOfCodeAttribute attr &&
                    attr.Year == dayToGet.Year && attr.Day == dayToGet.Day);

            return day != null;
        }
    }
}
