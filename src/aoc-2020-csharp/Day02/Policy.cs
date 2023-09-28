namespace aoc_2020_csharp.Day02;

public record Policy(int Min, int Max, char Letter)
{
    public static Policy Parse(string policy)
    {
        var parts = policy.Split(" ");
        var (range, letter) = (parts[0], parts[1].Single());

        var rangeParts = range.Split("-").Select(int.Parse).ToArray();
        var (min, max) = (rangeParts[0], rangeParts[1]);

        return new Policy(min, max, letter);
    }
}
