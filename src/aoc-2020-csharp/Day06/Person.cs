namespace aoc_2020_csharp.Day06;

public record Person(IEnumerable<char> Answers)
{
    public static Person Parse(string input) => new(input.Select(c => c));
}
