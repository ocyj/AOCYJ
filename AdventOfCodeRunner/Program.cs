using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var executeList = new List<(int year, int date)>()
            {
                (2019, 1),
                (2019, 2),
                (2019, 3),
                (2019, 4),
                (2019, 5),
                (2019, 6),
                (2019, 7),
                (2020, 1),
                (2020, 2),
                (2020, 3),
                (2020, 4),
                (2020, 5),
                (2020, 6),
                (2020, 8),
                (2020, 9),
                (2021, 1),
                (2021, 2),
                (2021, 3),
                (2021, 4),
                (2021, 5),
                (2021, 6),
                (2021, 7),
                (2021, 8),
                (2021, 9)
            };

            var dayTypesToRun = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Day)))
                .Where(t => t.GetCustomAttribute(typeof(AdventOfCodeAttribute)) is AdventOfCodeAttribute attr &&
                executeList.Contains((attr.Year, attr.Day)));

            foreach (var dayType in dayTypesToRun)
            {
                if (dayType.GetCustomAttribute(typeof(AdventOfCodeAttribute)) is AdventOfCodeAttribute attribute)
                {
                    // Do this once for entire assembly? Use line below to get all resource names
                    string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();

                    Stream resourceStream = Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream($"AdventOfCodeRunner.AOC{attribute.Year:D4}.input.input{attribute.Day:D2}.txt");
                    if (resourceStream != null)
                    {
                        var streamReader = new StreamReader(resourceStream);

                        var input = streamReader.ReadToEnd().Trim().Split(Environment.NewLine);
                        var day = Activator.CreateInstance(dayType, new object[] { input }) as Day;
                        Solver.Solve(day, attribute);
                    }
                }
            }
        }
    }
}
