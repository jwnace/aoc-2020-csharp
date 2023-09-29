namespace aoc_2020_csharp.Day17;

public class Grid4d : IGrid<Grid4d, Coordinate4d>
{
    private readonly Dictionary<Coordinate4d, bool> _grid = new();

    private bool this[Coordinate4d coordinate]
    {
        get => _grid.TryGetValue(coordinate, out var v) && v;
        set => _grid[coordinate] = value;
    }

    private IEnumerable<Coordinate4d> Coordinates => _grid.Keys.ToArray();

    public int Count(Func<KeyValuePair<Coordinate4d, bool>, bool> func) => _grid.Count(func);

    public static Grid4d Parse(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var grid = new Grid4d();

        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                grid[new Coordinate4d(x, y, 0, 0)] = lines[y][x] == '#';
            }
        }

        return grid;
    }

    private int CountActiveNeighbors(Coordinate4d coordinate)
    {
        var count = 0;

        for (var w = coordinate.W - 1; w <= coordinate.W + 1; w++)
        {
            for (var z = coordinate.Z - 1; z <= coordinate.Z + 1; z++)
            {
                for (var y = coordinate.Y - 1; y <= coordinate.Y + 1; y++)
                {
                    for (var x = coordinate.X - 1; x <= coordinate.X + 1; x++)
                    {
                        if (x == coordinate.X && y == coordinate.Y && z == coordinate.Z && w == coordinate.W)
                        {
                            continue;
                        }

                        if (this[new Coordinate4d(x, y, z, w)])
                        {
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }

    public Grid4d Step()
    {
        var newGrid = new Grid4d();

        var minX = Coordinates.Min(x => x.X) - 1;
        var maxX = Coordinates.Max(x => x.X) + 1;
        var minY = Coordinates.Min(x => x.Y) - 1;
        var maxY = Coordinates.Max(x => x.Y) + 1;
        var minZ = Coordinates.Min(x => x.Z) - 1;
        var maxZ = Coordinates.Max(x => x.Z) + 1;
        var minW = Coordinates.Min(x => x.W) - 1;
        var maxW = Coordinates.Max(x => x.W) + 1;

        for (var z = minZ; z <= maxZ; z++)
        {
            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    for (var w = minW; w <= maxW; w++)
                    {
                        var coordinate = new Coordinate4d(x, y, z, w);
                        var activeNeighbors = CountActiveNeighbors(coordinate);
                        var isAlreadyActive = this[coordinate];

                        newGrid[coordinate] =
                            (isAlreadyActive && activeNeighbors is 2 or 3) ||
                            (!isAlreadyActive && activeNeighbors == 3);
                    }
                }
            }
        }

        return newGrid;
    }
}
