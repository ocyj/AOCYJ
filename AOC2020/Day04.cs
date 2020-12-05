using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2020
{
    public class Day04 : Day
    {
        private List<Dictionary<string, string>> Passports;
        public override int Date => 4;

        public override string Name => "Passport Processing";

        public override object SolvePart1() =>
            Passports.Count(p => ValidateFieldsPresent(p));

        public override object SolvePart2() =>
            Passports.Where(p => ValidateFieldsPresent(p))
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

        public override void Prepare()
        {
            Passports = new List<Dictionary<string, string>>();
            var currentRecord = new Dictionary<string, string>();
            foreach (var line in Input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    Passports.Add(currentRecord);
                    currentRecord = new Dictionary<string, string>();
                    continue;
                }
                foreach (var part in line.Split(' '))
                {
                    var keyValue = part.Split(':');
                    currentRecord[keyValue[0]] = keyValue[1];
                }
            }
            // Also add last passport
            Passports.Add(currentRecord);
        }
    }
}
