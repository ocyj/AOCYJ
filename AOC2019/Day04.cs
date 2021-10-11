using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using CommonShared;

namespace AOC2019
{
    class Day04 : DayOf2019
    {
        public override int Date => 4;

        public override string Name => "Secure Container";

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

        public override object SolvePart2()
        {
            return "";
        }
    }
}
