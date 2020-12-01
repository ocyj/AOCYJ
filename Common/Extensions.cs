using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class Extensions
    {
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
