namespace aoc_2020_csharp.Day01;

public static class Day01
{
    private static readonly int[] Input = File.ReadAllLines("Day01/day01.txt").Select(int.Parse).ToArray();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(int[] input)
    {
        foreach (var a in input)
        {
            foreach (var b in input)
            {
                if (a + b == 2020)
                {
                    return a * b;
                }
            }
        }

        return 0;
    }

    public static int Solve2(int[] input)
    {
        foreach (var a in input)
        {
            foreach (var b in input)
            {
                foreach (var c in input)
                {
                    if (a + b + c == 2020)
                    {
                        return a * b * c;
                    }
                }
            }
        }

        return 0;
    }
}
