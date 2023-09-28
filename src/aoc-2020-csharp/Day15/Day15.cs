namespace aoc_2020_csharp.Day15;

public static class Day15
{
    private static readonly List<int> Input = File.ReadAllText("Day15/day15.txt").Split(',').Select(int.Parse).ToList();

    public static int Part1() => Solve(Input, 2020);

    public static int Part2() => Solve(Input, 30000000);

    public static int Solve(List<int> numbers, int count)
    {
        var memo = new Dictionary<int, int>();
        var lastNumber = numbers.Last();

        for (var i = 0; i < count; i++)
        {
            if (i < numbers.Count)
            {
                memo[numbers[i]] = i;
                continue;
            }

            var nextNumber = memo.TryGetValue(lastNumber, out var previousIndex)
                ? i - 1 - previousIndex
                : 0;

            memo[lastNumber] = i - 1;
            lastNumber = nextNumber;
        }

        return lastNumber;
    }
}
