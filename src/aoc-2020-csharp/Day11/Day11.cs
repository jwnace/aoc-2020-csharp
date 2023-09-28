namespace aoc_2020_csharp.Day11;

public static class Day11
{
    private static readonly string[] Input = File.ReadAllLines("Day11/day11.txt");
    private static int _maxCol;
    private static int _maxRow;

    public static int Part1() => Solve(Input, 4, CountOccupiedNeighbors);

    public static int Part2() => Solve(Input, 5, CountOccupiedVisibleSeats);

    public static int Solve(
        string[] input,
        int neighborTolerance,
        Func<int, int, Dictionary<(int Row, int Col), char>, int> findNeighbors)
    {
        var grid = BuildGrid(input);

        while (true)
        {
            var newGrid = new Dictionary<(int Row, int Col), char>(grid);

            foreach (var seat in grid)
            {
                var (row, col) = seat.Key;
                var neighbors = findNeighbors(row, col, grid);

                newGrid[seat.Key] = seat.Value switch
                {
                    'L' when neighbors == 0 => '#',
                    '#' when neighbors >= neighborTolerance => 'L',
                    _ => newGrid[seat.Key]
                };
            }

            if (grid.SequenceEqual(newGrid))
            {
                break;
            }

            grid = newGrid;
        }

        return grid.Count(s => s.Value == '#');
    }

    private static Dictionary<(int, int), char> BuildGrid(IReadOnlyList<string> input)
    {
        _maxRow = input.Count - 1;
        _maxCol = input[0].Length - 1;

        var grid = new Dictionary<(int, int), char>();

        for (var row = 0; row < input.Count; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == 'L')
                {
                    grid[(row, col)] = 'L';
                }
            }
        }

        return grid;
    }

    public static int CountOccupiedNeighbors(int row, int col, Dictionary<(int, int), char> grid) =>
        GetNeighbors(row, col).Count(neighbor => grid.TryGetValue(neighbor, out var value) && value == '#');

    private static IEnumerable<(int, int)> GetNeighbors(int row, int col) =>
        new[]
        {
            (row - 1, col - 1),
            (row - 1, col),
            (row - 1, col + 1),
            (row, col - 1),
            (row, col + 1),
            (row + 1, col - 1),
            (row + 1, col),
            (row + 1, col + 1),
        };

    public static int CountOccupiedVisibleSeats(int row, int col, Dictionary<(int Row, int Col), char> grid) =>
        GetVisibleNeighbors(row, col, grid).Count(value => value == '#');

    private static IEnumerable<char> GetVisibleNeighbors(int row, int col, IReadOnlyDictionary<(int, int), char> grid)
    {
        // get first visible seat to the right
        for (var c = col + 1; c <= _maxCol; c++)
        {
            if (grid.TryGetValue((row, c), out var v))
            {
                yield return v;
                break;
            }
        }

        // get first visible seat to the left
        for (var c = col - 1; c >= 0; c--)
        {
            if (grid.TryGetValue((row, c), out var v))
            {
                yield return v;
                break;
            }
        }

        // get first visible seat above
        for (var r = row - 1; r >= 0; r--)
        {
            if (grid.TryGetValue((r, col), out var v))
            {
                yield return v;
                break;
            }
        }

        // get first visible seat below
        for (var r = row + 1; r <= _maxRow; r++)
        {
            if (grid.TryGetValue((r, col), out var v))
            {
                yield return v;
                break;
            }
        }

        // get first visible seat to the upper right
        for (var r = row - 1; r >= 0; r--)
        {
            var c = col + (row - r);

            if (c > _maxCol)
            {
                break;
            }

            if (grid.TryGetValue((r, c), out var v))
            {
                yield return v;
                break;
            }
        }

        // get first visible seat to the upper left
        for (var r = row - 1; r >= 0; r--)
        {
            var c = col - (row - r);

            if (c < 0)
            {
                break;
            }

            if (grid.TryGetValue((r, c), out var v))
            {
                yield return v;
                break;
            }
        }

        // get first visible seat to the lower right
        for (var r = row + 1; r <= _maxRow; r++)
        {
            var c = col + (r - row);

            if (c > _maxCol)
            {
                break;
            }

            if (grid.TryGetValue((r, c), out var v))
            {
                yield return v;
                break;
            }
        }

        // get first visible seat to the lower left
        for (var r = row + 1; r <= _maxRow; r++)
        {
            var c = col - (r - row);

            if (c < 0)
            {
                break;
            }

            if (grid.TryGetValue((r, c), out var v))
            {
                yield return v;
                break;
            }
        }
    }
}
