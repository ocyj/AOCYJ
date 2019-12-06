using System;
using System.IO;

namespace Common
{
    public abstract class Day
    {
        public string[] Input { get; }
        public abstract int Date { get; }
        public abstract string Name { get; }
        public Day()
        {
            Input = File.ReadAllLines($@"input\input{Date:D2}.txt");
        }
        public void Solve()
        {
            Console.WriteLine($" Day {Date:D2} - {Name.ToUpper()} ");
            Console.WriteLine();
            Console.Write($"\tPart 1 answer:");
            Console.WriteLine($"\t{SolvePart1().ToString()}");
            Console.Write($"\tPart 2 answer:");
            Console.WriteLine($"\t{SolvePart2().ToString()}");
            Console.WriteLine("=============================================");
        }
        public abstract object SolvePart1();
        public abstract object SolvePart2();
    }
}
