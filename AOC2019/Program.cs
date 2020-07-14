using Common;
using System;
using System.Linq;
using System.Reflection;

namespace AOC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            var dayTypes = Assembly.GetExecutingAssembly().GetTypes()
                                   .Where(t => t.BaseType == typeof(Day));
            foreach (var dayType in dayTypes)
            {
                Day day = (Day)Activator.CreateInstance(dayType);
                day.Solve();
            }
            Other();
        }

        private static void Other()
        {
        }
    }
}
