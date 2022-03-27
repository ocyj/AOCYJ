using System.Collections.Generic;

namespace AdventOfCodeRunner.Common
{
    public abstract class Day
    {
        private readonly string[] _input;
        public string[] Input => UseTestInput ? TestInput : _input;
        public bool UseTestInput { get; set; } = false; 
        public string[] TestInput { private get; set; }
        public abstract string Name { get; }

        protected Day(string[] input)
        {
            _input = input;
        }

        public abstract object SolvePart1();
        public abstract object SolvePart2();

        protected IEnumerable<IEnumerable<string>> InputGroups
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
    }
}
