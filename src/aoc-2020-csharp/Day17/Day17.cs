namespace aoc_2020_csharp.Day17;

public static class Day17
{
    private static readonly string Input = File.ReadAllText("Day17/day17.txt").Trim();

    public static int Part1() => Solve<Grid3d>(Input);

    public static int Part2() => Solve<Grid4d>(Input);

    public static int Solve<TGrid>(string input) where TGrid : IGrid<TGrid>
    {
        var grid = TGrid.Parse(input);

        for (var i = 0; i < 6; i++)
        {
            grid = grid.Step();
        }

        return grid.CountActive();
    }
}
