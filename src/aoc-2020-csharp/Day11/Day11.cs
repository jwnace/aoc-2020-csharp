namespace aoc_2020_csharp.Day11;

public static class Day11
{
    private static readonly string[] Input = File.ReadAllLines("Day11/day11.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input)
    {
        var grid = BuildGrid(input);

        while (true)
        {
            var newGrid = new Dictionary<(int Row, int Col), char>(grid);

            foreach (var seat in grid)
            {
                var (row, col) = seat.Key;
                var occupiedNeighbors = CountOccupiedNeighbors(row, col, grid);

                newGrid[seat.Key] = seat.Value switch
                {
                    'L' when occupiedNeighbors == 0 => '#',
                    '#' when occupiedNeighbors >= 4 => 'L',
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

    public static int Solve2(string[] input)
    {
        throw new NotImplementedException();
    }

    private static Dictionary<(int Row, int Col), char> BuildGrid(string[] input)
    {
        var grid = new Dictionary<(int Row, int Col), char>();

        for (var row = 0; row < input.Length; row++)
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

    private static int CountOccupiedNeighbors(int row, int col, Dictionary<(int Row, int Col), char> grid) =>
        GetNeighbors(row, col).Count(n => grid.TryGetValue(n, out var v) && v == '#');

    private static (int, int)[] GetNeighbors(int row, int col) =>
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
}
