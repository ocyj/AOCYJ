using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeRunner.Common
{
    public static class Extensions
    {
        public static bool WithinRange(this int number, int lower, int upper,
             bool includeLower = true, bool includeUpper = true)
        {
            if (includeLower)
            {
                if (!(lower <= number))
                {
                    return false;
                }
            }
            else if (!(lower < number))
            {
                return false;
            }

            if (includeUpper)
            {
                if (!(number <= upper))
                {
                    return false;
                }
            }
            else if (!(number < upper))
            {
                return false;
            }
            return true;
        }

        public static bool OnlyDecimalDigits(this string s) => s.All(c => '0' <= c && c <= '9');

        public static bool OnlyHexadecimalDigits(this string s, bool allowUppercase = true)
        {
            if (allowUppercase)
                s = s.ToLowerInvariant();
            return s.All(c => ('0' <= c && c <= '9') || ('a' <= c && c <= 'f'));
        }
        public static int CountChar(this string s, char c)
        {
            return s.Split(c).Length - 1;
        }

        public static IEnumerable<IEnumerable<T>> ContiguousRanges<T>(this IReadOnlyList<T> inputSequence, int rangeLength = 2)
        {
            // Count of ranges = inputSequence.Count - rangeLenght + 1
            int lastStartIdx = inputSequence.Count - rangeLength;
            List<T> returnList;
            for (int currentStartIdx = 0; currentStartIdx <= lastStartIdx; currentStartIdx++)
            {
                returnList = new List<T>(rangeLength);
                for (int i = currentStartIdx; i < currentStartIdx + rangeLength; i++)
                {
                    returnList.Add(inputSequence[i]);
                }
                yield return returnList;
            }
        }

        public static IEnumerable<IEnumerable<T>> SlidingWindows<T>(this IReadOnlyList<T> inputSequence, int windowLength)
        {   
            for (int i = 0; i <= inputSequence.Count - windowLength; i++)
            {
                var window = new T[windowLength];
                int windowIndex = 0;
                for (int j = i; j <= i + (windowLength - 1); j++)
                {
                    window[windowIndex++] = inputSequence[j];
                }
                yield return window;
            }
        }

        public static IEnumerable<Pair<T>> Pairs<T>(this IReadOnlyList<T> inputSequence)
        {
            for (int i = 0; i < inputSequence.Count - 1; i++)
            {
                for(int j = i + 1; j < inputSequence.Count; j++)
                {
                    yield return new Pair<T>(inputSequence[i], inputSequence[j]);
                }
            }
        }

    }
}
