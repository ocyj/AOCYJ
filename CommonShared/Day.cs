using System;
using System.Collections.Generic;
using System.IO;

namespace CommonShared
{
    public abstract class Day
    {
        private string[] _input;
        public string[] Input => UseTestInput ? TestInput : _input;

        public List<string[]> InputGroups { get; private set; }

        public bool UseTestInput { get; set; } = false; 
        public string[] TestInput { private get; set; }
        public abstract int Date { get; }
        public abstract string Name { get; }

        public Day(bool parseInputGroups = false)
        {
            ParseInput(parseInputGroups);
            Prepare();
        }

        private void ParseInput(bool parseInputGroups)
        {
            _input = File.ReadAllLines($@"input\input{Date:D2}.txt");
            if (parseInputGroups)
            {
                InputGroups = new List<string[]>();
                var currentGroup = new List<string>();
                foreach (var line in Input)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        InputGroups.Add(currentGroup.ToArray());
                        currentGroup = new List<string>();
                        continue;
                    }
                    foreach (var part in line)
                    {
                        currentGroup.Add(part);
                    }
                }

                // Also add last currentForm
                InputGroups.Add(currentForm);
            }
        }

        public void Solve()
        {
            Console.WriteLine($" Day {Date:D2} - {Name.ToUpper()} ");
            Console.WriteLine();

            Console.Write($"\tPart 1 answer:");
            try
            {
                Console.WriteLine($"\t{SolvePart1()}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"\tNOT SOLVED YET!");
            }

            Console.Write($"\tPart 2 answer:");
            try
            {
                Console.WriteLine($"\t{SolvePart2()}");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine($"\tNOT SOLVED YET!");
            }

            Console.WriteLine("=============================================");
        }
        public abstract object SolvePart1();
        public abstract object SolvePart2();

        internal virtual void Prepare()
        {
        }
    }
}
