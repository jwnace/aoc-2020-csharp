using aoc_2020_csharp.Extensions;

namespace aoc_2020_csharp.Day10;

public static class Day10
{
    private static readonly int[] Input = File.ReadAllLines("Day10/day10.txt").Select(int.Parse).ToArray();

    public static int Part1() => Solve1(Input);

    public static long Part2() => Solve2(Input);

    public static int Solve1(int[] input)
    {
        var dictionary = input
            .OrderBy(x => x)
            .Prepend(0)
            .Append(input.Max() + 3)
            .Windowed(2)
            .GroupBy(x => x[1] - x[0])
            .ToDictionary(g => g.Key, g => g.Count());

        return dictionary[1] * dictionary[3];
    }

    public static long Solve2(int[] input)
    {
        var memo = new Dictionary<int, long> { { input.Max() + 3, 1 } };
        var adapters = input.OrderByDescending(x => x).Append(0);

        foreach (var adapter in adapters)
        {
            memo[adapter] = Enumerable.Range(1, 3).Select(i => memo.GetValueOrDefault(adapter + i, 0L)).Sum();
        }

        return memo[0];
    }
}
