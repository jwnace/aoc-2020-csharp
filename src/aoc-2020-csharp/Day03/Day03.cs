namespace aoc_2020_csharp.Day03;

public static class Day03
{
    private static readonly string[] Input = File.ReadAllLines("Day03/day03.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input) => CountTrees(input, 3, 1);

    public static int Solve2(string[] input)
    {
        var a = CountTrees(input, 1, 1);
        var b = CountTrees(input, 3, 1);
        var c = CountTrees(input, 5, 1);
        var d = CountTrees(input, 7, 1);
        var e = CountTrees(input, 1, 2);

        return a * b * c * d * e;
    }

    private static int CountTrees(string[] input, int right, int down)
    {
        var count = 0;
        var j = 0;

        for (var i = 0; i < input.Length; i += down)
        {
            if (j >= input[i].Length)
            {
                j -= input[i].Length;
            }

            count += input[i][j] == '#' ? 1 : 0;

            j += right;
        }

        return count;
    }
}
