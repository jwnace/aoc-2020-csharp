namespace aoc_2020_csharp.Day17;

public class Grid
{
    private readonly Dictionary<Coordinate, bool> _grid = new();

    public bool this[Coordinate coordinate]
    {
        get => _grid.TryGetValue(coordinate, out var v) && v;
        set => _grid[coordinate] = value;
    }

    public IEnumerable<Coordinate> Coordinates => _grid.Keys.ToArray();

    public int Count(Func<KeyValuePair<Coordinate, bool>, bool> func) => _grid.Count(func);

    public static Grid Parse(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var grid = new Grid();

        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                grid[new Coordinate(x, y, 0)] = lines[y][x] == '#';
            }
        }

        return grid;
    }

    public int CountActiveNeighbors(Coordinate coordinate)
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

                    if (this[new Coordinate(x, y, z)])
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}
