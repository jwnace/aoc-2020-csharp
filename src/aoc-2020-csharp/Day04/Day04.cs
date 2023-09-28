namespace aoc_2020_csharp.Day04;

public static class Day04
{
    private static readonly string Input = File.ReadAllText("Day04/day04.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input) => ParsePassports(input).Count(p => p.HasAllRequiredFields());

    public static int Solve2(string input) => ParsePassports(input).Count(p => p.IsValid());

    private static IEnumerable<Passport> ParsePassports(string input) =>
        input.Split($"{Environment.NewLine + Environment.NewLine}").Select(Passport.Parse);
}
