using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public static class Solver
    {
        public static void Solve()
        {
            Console.WriteLine();
            var dayTypes = Assembly.GetExecutingAssembly().GetTypes()
                                   .Where(t => t.BaseType == typeof(Day));
            foreach (var dayType in dayTypes)
            {
                Day day = (Day)Activator.CreateInstance(dayType);
                day.Solve();
            }
        }
    }
}
