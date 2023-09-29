namespace aoc_2020_csharp.Day17;

public static class Day17
{
    private static readonly string Input = File.ReadAllText("Day17/day17.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input)
    {
        var grid = Grid.Parse(input);

        for (var i = 0; i < 6; i++)
        {
            var newGrid = new Grid();

            var minX = grid.Coordinates.Min(x => x.X) - 1;
            var maxX = grid.Coordinates.Max(x => x.X) + 1;
            var minY = grid.Coordinates.Min(x => x.Y) - 1;
            var maxY = grid.Coordinates.Max(x => x.Y) + 1;
            var minZ = grid.Coordinates.Min(x => x.Z) - 1;
            var maxZ = grid.Coordinates.Max(x => x.Z) + 1;

            for (var z = minZ; z <= maxZ; z++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    for (var x = minX; x <= maxX; x++)
                    {
                        var coordinate = new Coordinate(x, y, z);
                        var activeNeighbors = grid.CountActiveNeighbors(coordinate);
                        var isAlreadyActive = grid[coordinate];

                        newGrid[coordinate] =
                            (isAlreadyActive && activeNeighbors is 2 or 3) ||
                            (!isAlreadyActive && activeNeighbors == 3);
                    }
                }
            }

            grid = newGrid;
        }

        return grid.Count(x => x.Value);
    }

    public static int Solve2(string input)
    {
        throw new NotImplementedException();
    }
}
