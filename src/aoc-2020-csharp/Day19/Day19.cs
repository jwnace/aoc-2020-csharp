using System.Text.RegularExpressions;
using aoc_2020_csharp.Extensions;

namespace aoc_2020_csharp.Day19;

public static class Day19
{
    private static readonly string Input = File.ReadAllText("Day19/day19.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input)
    {
        var (rules, messages) = input.Split("\n\n").Select(group => group.Split("\n")).ToArray();
        var map = rules.Select(x => x.Split(": ")).ToDictionary(x => x[0], x => x[1]);
        var regex = new Regex($"^{BuildRegex(map, "0")}$");

        return messages.Count(x => regex.IsMatch(x));
    }

    public static int Solve2(string input)
    {
        var (rules, messages) = input.Split("\n\n").Select(group => group.Split("\n")).ToArray();
        var map = rules.Select(x => x.Split(": ")).ToDictionary(x => x[0], x => x[1]);

        map["8"] = "42 | 42 42 | 42 42 42 | 42 42 42 42 | 42 42 42 42 42";
        map["11"] = "42 31 | 42 42 31 31 | 42 42 42 31 31 31 | 42 42 42 42 31 31 31 31";

        var regex = new Regex($"^{BuildRegex(map, "0")}$");
        return messages.Count(x => regex.IsMatch(x));
    }

    private static string BuildRegex(IReadOnlyDictionary<string, string> map, string rule)
    {
        var value = map[rule];

        if (value.StartsWith("\""))
        {
            return value[1..^1];
        }

        var subRules = value.Split(" | ");
        var subRegexes = subRules.Select(x => x.Split(" ").Select(y => BuildRegex(map, y)).ToArray());
        var regexes = subRegexes.Select(x => string.Join("", x)).ToArray();

        return $"({string.Join("|", regexes)})";
    }
}
