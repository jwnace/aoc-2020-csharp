namespace aoc_2020_csharp.Day17;

public static class Day17
{
    private static readonly string[] Input = File.ReadAllLines("Day17/day17.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input)
    {
        var grid = BuildGrid(input);

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
                        var activeNeighbors = CountActiveNeighbors(coordinate, grid);
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

    public static int Solve2(string[] input)
    {
        throw new NotImplementedException();
    }

    private static int CountActiveNeighbors(Coordinate coordinate, Grid grid)
    {
        var count = 0;

        for (var z = coordinate.Z - 1; z <= coordinate.Z + 1; z++)
        {
            for (var y = coordinate.Y - 1; y <= coordinate.Y + 1; y++)
            {
                for (var x = coordinate.X - 1; x <= coordinate.X + 1; x++)
                {
                    if (x == coordinate.X && y == coordinate.Y && z == coordinate.Z)
                    {
                        continue;
                    }

                    if (grid[new Coordinate(x, y, z)])
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    private static Grid BuildGrid(string[] input)
    {
        var grid = new Grid();

        for (var y = 0; y < input.Length; y++)
        {
            for (var x = 0; x < input[y].Length; x++)
            {
                grid[new Coordinate(x, y, 0)] = input[y][x] == '#';
            }
        }

        return grid;
    }
}
