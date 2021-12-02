namespace AOC2021
{
    public class Day02 : DayOf2021
    {
        public override int Date => 2;

        public override string Name => "Dive!";

        public override object SolvePart1()
        {
            var (depth, horizontal) = (0, 0);

            foreach (var command in Input)
            {
                var parts = command.Split(" ");
                int displacement = int.Parse(parts[1]);
                var (depthMov, horizMov) = parts[0] switch
                {
                    "forward" => (0, displacement),
                    "up" => (-1 * displacement, 0),
                    "down" => (displacement, 0),
                    _ => throw new Exception("Something's wrong")
                };

                depth += depthMov;
                horizontal += horizMov;
            }
            return horizontal * depth;
        }

        public override object SolvePart2()
        {
            var (depth, horizontal) = (0, 0);
            int aim = 0;
            foreach (var command in Input)
            {
                var parts = command.Split(" ");
                int displacement = int.Parse(parts[1]);
                switch (parts[0])
                {
                    case "up":
                        aim -= displacement;
                        break;
                    case "down":
                        aim += displacement;
                        break;
                    case "forward":
                        depth += aim * displacement;
                        horizontal += displacement;
                        break;
                }
            }
            return horizontal * depth;
        }
    }
}
