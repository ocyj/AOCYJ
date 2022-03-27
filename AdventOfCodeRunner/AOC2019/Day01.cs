using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2019
{
    [AdventOfCode(Year = 2019, Day = 1)]
    internal class Day01 : Day
    {
        public override string Name => "The Tyranny of the Rocket Equation";

        private readonly IEnumerable<decimal> _parsedInput;

        public Day01(string[] input) : base(input)
        {
            _parsedInput = Input.Select(decimal.Parse);
        }

        public override object SolvePart1()
        {
            return _parsedInput.Sum(m => Math.Floor(m / 3) - 2);
        }

        public override object SolvePart2()
        {
            return _parsedInput.Sum(CalculateFuel);

        }

        private static decimal CalculateFuel(decimal mass)
        {
            decimal fuelRequiredForOnlyMass = Math.Max(Math.Floor(mass / 3) - 2, 0);
            return fuelRequiredForOnlyMass == 0 ? 0 : fuelRequiredForOnlyMass + CalculateFuel(fuelRequiredForOnlyMass);
        }
    }
}
