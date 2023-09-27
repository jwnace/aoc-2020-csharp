namespace aoc_2020_csharp.Day06;

public static class Day06
{
    private static readonly string Input = File.ReadAllText("Day06/day06.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input) => GetFlattenedGroups(input).Sum(CountDistinctAnswers);

    public static int Solve2(string input) => GetGroups(input).Sum(CountUnanimousAnswers);

    private static IEnumerable<string> GetFlattenedGroups(string input) => GetGroups(input).Select(FlattenGroup);

    private static IEnumerable<string> GetGroups(string input) =>
        input.Split($"{Environment.NewLine}{Environment.NewLine}");

    private static string FlattenGroup(string group) => group.Replace(Environment.NewLine, string.Empty);

    private static int CountDistinctAnswers(string group) => group.Distinct().Count();

    private static int CountUnanimousAnswers(string group) =>
        FlattenGroup(group).GroupBy(answer => answer).Count(g => g.Count() == CountPeople(group));

    private static int CountPeople(string group) => group.Split(Environment.NewLine).Length;
}
