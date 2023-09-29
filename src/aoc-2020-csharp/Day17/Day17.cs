namespace aoc_2020_csharp.Day17;

public static class Day17
{
    private static readonly string Input = File.ReadAllText("Day17/day17.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input)
    {
        var grid = Grid3d.Parse(input);

        for (var i = 0; i < 6; i++)
        {
            grid = grid.Step();
        }

        return grid.Count(x => x.Value);
    }

    public static int Solve2(string input)
    {
        var grid = Grid4d.Parse(input);

        for (var i = 0; i < 6; i++)
        {
            grid = grid.Step();
        }

        return grid.Count(x => x.Value);
    }
}
