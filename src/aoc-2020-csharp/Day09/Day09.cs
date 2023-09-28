using aoc_2020_csharp.Extensions;

namespace aoc_2020_csharp.Day09;

public static class Day09
{
    private static readonly long[] Input = File.ReadAllLines("Day09/day09.txt").Select(long.Parse).ToArray();

    public static long Part1() => Solve1(Input);

    public static long Part2() => Solve2(Input);

    public static long Solve1(long[] input, int preambleLength = 25)
    {
        var windows = input.Windowed(preambleLength + 1);

        foreach (var window in windows)
        {
            var preamble = window[..preambleLength];
            var target = window[^1];

            if (preamble.Any(x => preamble.Contains(target - x)))
            {
                continue;
            }

            return target;
        }

        throw new Exception("No solution found");
    }

    public static long Solve2(long[] input, int preambleLength = 25)
    {
        var target = Solve1(input, preambleLength);

        for (var i = 0; i < input.Length; i++)
        {
            for (var j = i + 1; j < input.Length; j++)
            {
                var range = input[i..j];
                var sum = range.Sum();

                if (sum == target)
                {
                    return range.Min() + range.Max();
                }

                if (sum > target)
                {
                    break;
                }
            }
        }

        throw new Exception("No solution found");
    }
}
