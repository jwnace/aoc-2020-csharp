using aoc_2020_csharp.Extensions;

namespace aoc_2020_csharp.Day05;

public static class Day05
{
    private static readonly string[] Input = File.ReadAllLines("Day05/day05.txt");

    public static int Part1() => Input.Select(GetSeatId).Max();

    public static int Part2() => Input.Select(GetSeatId)
        .OrderBy(x => x)
        .Windowed(2)
        .Where(x => x[1] - x[0] == 2)
        .Select(x => x[0] + 1)
        .Single();

    public static int GetSeatId(string input) => GetRow(input[..7]) * 8 + GetColumn(input[7..]);

    private static int GetRow(string input) => FindPartition(input, Enumerable.Range(0, 128).ToArray());

    private static int GetColumn(string input) => FindPartition(input, Enumerable.Range(0, 8).ToArray());

    private static int FindPartition(string input, int[] range)
    {
        foreach (var c in input)
        {
            var half = range.Length / 2;

            range = c switch
            {
                'F' or 'L' => range.Take(half).ToArray(),
                'B' or 'R' => range.Skip(half).ToArray(),
                _ => throw new ArgumentException($"Invalid character: {c}")
            };
        }

        return range.Single();
    }
}
