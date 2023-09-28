namespace aoc_2020_csharp.Day02;

public record Password(Policy Policy, string Value)
{
    public static Password Parse(string line)
    {
        var parts = line.Split(": ");
        var (policy, value) = (parts[0], parts[1]);

        return new Password(Policy.Parse(policy), value);
    }

    public bool IsValidForPart1()
    {
        var count = Value.Count(c => c == Policy.Letter);
        return count >= Policy.Min && count <= Policy.Max;
    }

    public bool IsValidForPart2() =>
        Value[Policy.Min - 1] == Policy.Letter ^ Value[Policy.Max - 1] == Policy.Letter;
}
