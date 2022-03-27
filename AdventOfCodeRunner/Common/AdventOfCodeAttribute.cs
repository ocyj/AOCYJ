using System;

namespace AdventOfCodeRunner.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AdventOfCodeAttribute : System.Attribute
    {
        public int Year { get; set; }
        public int Day { get; set; }
        
    }
}