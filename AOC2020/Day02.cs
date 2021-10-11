using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using CommonShared;

namespace AOC2020
{
    public class Day02 : DayOf2020
    {
        private List<(int min, int max, char @char, string password)> passwordAndPolicies;
        public override int Date => 2;

        public override string Name => "Password Philosophy";

        public override object SolvePart1()
        {
            return passwordAndPolicies.Count(p => p.min <= p.password.CountChar(p.@char)
                                             && p.password.CountChar(p.@char) <= p.max);
        }

        public override object SolvePart2()
        {
            return passwordAndPolicies.Count(p => p.password[p.min - 1] == p.@char
                                                ^ p.password[p.max - 1] == p.@char);
        }

        internal override void Prepare()
        {
            passwordAndPolicies = new List<(int min, int max, char @char, string password)>();

            foreach(string line in Input)
            {
                string[] parts = line.Split(' ');
                (int min, int max, char @char, string password) passwordAndPolicy;
                passwordAndPolicy.min = int.Parse(parts[0].Split('-')[0]);
                passwordAndPolicy.max = int.Parse(parts[0].Split('-')[1]);
                passwordAndPolicy.@char = char.Parse(parts[1].Substring(0,1));
                passwordAndPolicy.password = parts[2];

                passwordAndPolicies.Add(passwordAndPolicy);
            }
        }
    }
}
