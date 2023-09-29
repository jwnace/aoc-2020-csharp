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
}
