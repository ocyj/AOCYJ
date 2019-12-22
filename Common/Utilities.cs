using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Utilities
    {
        public static (int Thousands, int Hundreds, int Tens, int Ones) ExtractThousandsHundredsTensAndOnes(this int integer)
        {
            if (integer < 0 || integer > 9_999)
                throw new ArgumentException();

            int[] results = new[] { 0, 0, 0, 0 };

            int index = 0;
            decimal x = integer;
            while (x >= 1)
            {
                x = x / 10;
                decimal intPart = Math.Truncate(x);
                results[index++] = (int)((x - intPart) * 10);
                x = intPart;
            }
            return (results[3], results[2], results[1], results[0]);
        }

        public static IEnumerable<int[]> AllPermutations(this int[] array)
        {
            List<int[]> outputList = new List<int[]>();
            Permutate(array, 0, array.Length - 1, outputList);
            return outputList;
        }

        private static void Permutate(int[] array, int startIndex, int stopIndex, List<int[]> outputList)
        {
            int[] permutation = (int[])array.Clone();

            if(startIndex != stopIndex)
            {
                for(int i = startIndex; i<=stopIndex; i++)
                {
                    SwapElements(permutation, startIndex, i);
                    Permutate(permutation, startIndex + 1, stopIndex, outputList);
                }
                return;
            }
            outputList.Add(permutation);
        }

        private static void SwapElements(int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
