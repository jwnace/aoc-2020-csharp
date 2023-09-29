namespace aoc_2020_csharp.Day18;

public static class Day18
{
    private static readonly string[] Input = File.ReadAllLines("Day18/day18.txt");

    public static long Part1() => Input.Sum(Solve1);

    public static long Part2() => Input.Sum(Solve2);

    public static long Solve1(string line)
    {
        while (line.Contains('('))
        {
            var start = line.IndexOf(')');
            var end = line[..start].LastIndexOf('(');
            var subProblem = line.Substring(end + 1, start - end - 1);

            line = line[..end] + Solve1(subProblem) + line[(start + 1)..];
        }

        var list = line.Split(' ').ToList();

        while (list.Any(x => x is "+" or "*"))
        {
            var (a, op, b) = (long.Parse(list[0]), list[1], long.Parse(list[2]));
            var c = op == "+" ? a + b : a * b;

            list.RemoveRange(0, 2);
            list[0] = c.ToString();
        }

        return long.Parse(list.Single());
    }

    public static long Solve2(string line)
    {
        while (line.Contains('('))
        {
            var start = line.IndexOf(')');
            var end = line[..start].LastIndexOf('(');
            var subProblem = line.Substring(end + 1, start - end - 1);

            line = line[..end] + Solve2(subProblem) + line[(start + 1)..];
        }

        var list = line.Split(' ').ToList();

        while (list.Contains("+"))
        {
            var i = list.IndexOf("+");
            var (a, b) = (long.Parse(list[i - 1]), long.Parse(list[i + 1]));
            var c = a + b;

            list[i] = c.ToString();
            list.RemoveAt(i + 1);
            list.RemoveAt(i - 1);
        }

        while (list.Contains("*"))
        {
            var i = list.IndexOf("*");
            var (a, b) = (long.Parse(list[i - 1]), long.Parse(list[i + 1]));
            var c = a * b;

            list[i] = c.ToString();
            list.RemoveAt(i + 1);
            list.RemoveAt(i - 1);
        }

        return long.Parse(list.Single());
    }
}
