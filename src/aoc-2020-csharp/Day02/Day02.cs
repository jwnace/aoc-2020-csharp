namespace aoc_2020_csharp.Day02;

public static class Day02
{
    private static readonly string[] Input = File.ReadAllLines("Day02/day02.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input) =>
        input.Select(Password.Parse).Count(p => p.IsValidForPart1());

    public static int Solve2(string[] input) =>
        input.Select(Password.Parse).Count(p => p.IsValidForPart2());
}
