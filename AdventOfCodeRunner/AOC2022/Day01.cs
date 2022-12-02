using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2022;

[AdventOfCode(Year = 2022, Day = 1)]
internal class Day01 : Day
{
    public Day01(string[] input) : base(input)
    {
        TestInput = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000"
            .Split(Environment.NewLine);
        UseTestInput = false;
    }

    public override string Name => "Calorie Counting";
    public override object SolvePart1()=> ElfCalorieItems().Max(e => e);

    public override object SolvePart2() =>
        ElfCalorieItems().OrderByDescending(e => e).Take(3).Sum();

    private IEnumerable<int> ElfCalorieItems()
    {
        var allElfCalorieCounts =
            Input.Select<string, int?>(line => int.TryParse(line, out var result) ? result : null);
        var calories = 0;

        foreach (var caloriesItem in allElfCalorieCounts)
        {
            if (caloriesItem != null)
            {
                calories += caloriesItem.Value;
            }
            else
            {
                yield return calories;
                calories = 0;
            }
        }
        yield return calories;
    }
}