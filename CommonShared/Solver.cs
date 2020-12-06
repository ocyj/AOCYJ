using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommonShared
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
                if (dayType.GetCustomAttribute(typeof(ParseInputGroupAttribute)) != null)
                {
                    Day day = (Day)Activator.CreateInstance(dayType, new[] { true });

                }
                else
                {
                    Day day = (Day)Activator.CreateInstance(dayType);
                }
                day.Solve();
            }
        }
    }
}
