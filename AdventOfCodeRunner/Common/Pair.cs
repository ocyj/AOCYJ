namespace AdventOfCodeRunner.Common
{
    public class Pair<T>
    {
        public readonly T Value1, Value2;

        public Pair(T value1, T value2)
        {
            Value1 = value1;
            Value2 = value2;
        }
        public override string ToString()
        {
            return $"{Value1?.ToString()} {Value2?.ToString()}";
        }
    }
}
