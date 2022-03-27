using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2019
{
    [AdventOfCode(Year = 2019, Day = 4)]
    internal class Day04 : Day
    {
        public override string Name => "Secure Container";

        public Day04(string[] input) : base(input) { }

        public override object SolvePart1()
        {
            var bounds = Input[0].Split('-');
            var passwordRange = new Sequence(int.Parse(bounds[0]), int.Parse(bounds[1]));
            var validPasswords = new List<string>();
            foreach(var password in passwordRange.Select(p=>p.ToString()))
            {
                if (IsValidPassword(password))
                    validPasswords.Add(password);
            }
            return validPasswords.Count.ToString();
        }

        public override object SolvePart2()
        {
            return "";
        }

        private bool IsValidPassword(string password)
        {
            bool adjacentPairs = false;
            char lastCharacter = password[0];
            foreach (char c in password[1..])
            {
                if (c < lastCharacter)
                {
                    // Not a valid password. Can check next!
                    return false;
                }
                if (c == lastCharacter)
                {
                    adjacentPairs = true;
                }
                lastCharacter = c;
            }
            return adjacentPairs;
        }
    }
}
