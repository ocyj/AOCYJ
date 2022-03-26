using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CommonShared
{
    public abstract class Day
    {
        private string[] _input;
        public string[] Input => UseTestInput ? TestInput : _input;

        public IEnumerable<IEnumerable<string>> InputGroups
        {
            get
            {
                var currentGroup = new List<string>();
                foreach (var line in Input)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        yield return currentGroup;
                        currentGroup = new List<string>();
                        continue;
                    }

                    currentGroup.Add(line);
                }
                // Also return last group
                yield return currentGroup;
            }

        }

        public bool UseTestInput { get; set; } = false; 
        public string[]? TestInput { private get; set; }
        public abstract int Year { get; }
        public abstract int Date { get; }
        public abstract string Name { get; }

        protected Day()
        {
            // Do this once for entire assembly? Use line below to get all resource names
            //string[] names = assembly.GetManifestResourceNames();
            Stream resourceStream = Assembly.GetExecutingAssembly()
                .GetManifestResourceStream($"AOC{Year:D4}.input.input{Date:D2}.txt");
            var StreamReader = new StreamReader(resourceStream);

            _input = StreamReader.ReadToEnd().Trim().Split(Environment.NewLine);
            Prepare();
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

        internal virtual void Prepare() { }
    }
}
