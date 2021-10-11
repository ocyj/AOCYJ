using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonShared;

namespace AOC2019
{
    class Day01 : DayOf2019
    {
        public override int Date => 1;

        public override string Name => "The Tyranny of the Rocket Equation";

        private readonly IEnumerable<decimal> _parsedInput;
        public Day01():base()
        {
            _parsedInput = Input.Select(s => decimal.Parse(s));
        }

        public override object SolvePart1()
        {
            return _parsedInput.Sum(m => Math.Floor(m / 3) - 2);
        }

        public override object SolvePart2()
        {
            return _parsedInput.Sum(m => CalculateFuel(m));

        }
        private decimal CalculateFuel(decimal mass)
        {
            decimal fuelRequiredForOnlyMass = Math.Max(Math.Floor(mass / 3) - 2, 0);
            return fuelRequiredForOnlyMass == 0 ? 0 : fuelRequiredForOnlyMass + CalculateFuel(fuelRequiredForOnlyMass);

        }
    }
}
