using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class Extensions
    {
        public static bool WithinRange(this int number, int lower, int upper,
             bool includeLower = true, bool includeUpper = true)
        {
            if(includeLower)
            {
                if(!(lower <= number))
                {
                    return false;
                }
            }
            else if (!(lower < number))
            {
                return false;
            }

            if(includeUpper)
            {
                if(!(number<=upper))
                {
                    return false;
                }
            }
            else if(!(number < upper))
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
            return s.All( c => ('0' <= c && c <= '9') || ('a' <= c && c <= 'f') );
        }
        public static int CountChar(this string s, char c)
        {
            return s.Split(c).Length - 1;
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
