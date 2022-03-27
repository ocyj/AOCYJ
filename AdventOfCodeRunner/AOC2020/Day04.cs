using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 4)]
    public class Day04 : Day
    {
        private readonly List<Dictionary<string, string>> _passports;

        public override string Name => "Passport Processing";

        public Day04(string[] input) : base(input)
        {
            _passports = new List<Dictionary<string, string>>();
            Dictionary<string, string> currentRecord;
            foreach (var group in InputGroups)
            {
                currentRecord = new Dictionary<string, string>();
                foreach (var field in string.Join(' ', group).Split(' '))
                {
                    var keyValuePair = field.Split(':');
                    currentRecord[keyValuePair[0]] = keyValuePair[1];
                }
                _passports.Add(currentRecord);
            }
        }

        public override object SolvePart1() =>
            _passports.Count(p => ValidateFieldsPresent(p));

        public override object SolvePart2() =>
            _passports.Where(p => ValidateFieldsPresent(p))
                .Count(p => ValidatePassportFieldValues(p));

        private static bool ValidateFieldsPresent(Dictionary<string, string> passport)
        {
            var requiredFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            return requiredFields.All(key => passport.TryGetValue(key, out var value));
        }

        private static bool ValidatePassportFieldValues(Dictionary<string, string> passport) =>
            ValidateByr(passport["byr"]) &&
            ValidateIyr(passport["iyr"]) &&
            ValidateEyr(passport["eyr"]) &&
            ValidateHgt(passport["hgt"]) &&
            ValidateHcl(passport["hcl"]) &&
            ValidateEcl(passport["ecl"]) &&
            ValidatePid(passport["pid"]);

        private static bool ValidateByr(string value) =>
            value.OnlyDecimalDigits() && value.Length == 4 && int.Parse(value).WithinRange(1920, 2002);

        private static bool ValidateIyr(string value) =>
            value.OnlyDecimalDigits() && value.Length == 4 && int.Parse(value).WithinRange(2010, 2020);

        private static bool ValidateEyr(string value) =>
            value.OnlyDecimalDigits() && value.Length == 4 && int.Parse(value).WithinRange(2020, 2030);

        private static bool ValidateHgt(string value)
        {
            return value[^2..] switch
            {
                "cm" => int.Parse(value[..^2]).WithinRange(150, 193),
                "in" => int.Parse(value[..^2]).WithinRange(59, 76),
                _ => false
            };
        }

        private static bool ValidateHcl(string value) =>
            value.StartsWith('#') &&
            value[1..].OnlyHexadecimalDigits(allowUppercase: false) &&
            value[1..].Length == 6;

        private static bool ValidateEcl(string value) =>
            (new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }).Count(s => value.Equals(s)) == 1;

        private static bool ValidatePid(string value) =>
            value.Length == 9 && value.OnlyDecimalDigits();
    }
}
