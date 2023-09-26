namespace aoc_2020_csharp.Day01;

public static class Day01
{
    private static readonly int[] Input = File.ReadAllLines("Day01/day01.txt").Select(int.Parse).ToArray();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(int[] input)
    {
        var a = input.First(x => input.Contains(2020 - x));
        var b = 2020 - a;

        return a * b;
    }

    public static int Solve2(int[] input)
    {
        var a = input.First(x => input.Any(y => input.Contains(2020 - x - y)));
        var b = input.First(x => input.Contains(2020 - a - x));
        var c = 2020 - a - b;

        return a * b * c;
    }
}
