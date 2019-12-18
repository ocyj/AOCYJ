using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Utilities
    {
        public static (int Thousands, int Hundreds, int Tens, int Ones) ExtractThousandsHundredsTensAndOnes(this int integer)
        {
            if(integer < 0 || integer > 9_999)
                throw new ArgumentException();

            int[] results = new[] { 0, 0, 0, 0 };

            int index = 0;
            decimal x = integer;
            while(x >= 1)
            {
                x = x / 10;
                decimal intPart = Math.Truncate(x);
                results[index++] = (int)((x - intPart) * 10);
                x = intPart;
            }
            return (results[3], results[2], results[1], results[0]);
        }
    }
}
