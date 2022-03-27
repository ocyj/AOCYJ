using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 2)]
    public class Day02 : Day
    {
        private readonly List<(int min, int max, char @char, string password)> _passwordAndPolicies;

        public Day02(string[] input) : base(input)
        {
            _passwordAndPolicies = new List<(int min, int max, char @char, string password)>();

            foreach (string line in Input)
            {
                string[] parts = line.Split(' ');
                (int min, int max, char @char, string password) passwordAndPolicy;
                passwordAndPolicy.min = int.Parse(parts[0].Split('-')[0]);
                passwordAndPolicy.max = int.Parse(parts[0].Split('-')[1]);
                passwordAndPolicy.@char = char.Parse(parts[1].Substring(0, 1));
                passwordAndPolicy.password = parts[2];

                _passwordAndPolicies.Add(passwordAndPolicy);
            }
        }

        public override string Name => "Password Philosophy";

        public override object SolvePart1()
        {
            return _passwordAndPolicies.Count(p => p.min <= Extensions.CountChar(p.password, p.@char)
                                             && Extensions.CountChar(p.password, p.@char) <= p.max);
        }

        public override object SolvePart2()
        {
            return _passwordAndPolicies.Count(p => p.password[p.min - 1] == p.@char
                                                ^ p.password[p.max - 1] == p.@char);
        }
    }
}
