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

    private record Password(Policy Policy, string Value)
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

    private record Policy(int Min, int Max, char Letter)
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
}
