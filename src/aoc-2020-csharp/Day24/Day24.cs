namespace aoc_2020_csharp.Day24;

public static class Day24
{
    private static readonly string[] Input = File.ReadAllLines("Day24/day24.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(IEnumerable<string> input) => GetTiles(input).Count(x => x.Value);

    public static int Solve2(IEnumerable<string> input)
    {
        var tiles = GetTiles(input);
        var newTiles = new Dictionary<(int X, int Y), bool>();

        for (var i = 0; i < 100; i++)
        {
            var minX = tiles.Keys.Min(x => x.X) - 1;
            var maxX = tiles.Keys.Max(x => x.X) + 1;
            var minY = tiles.Keys.Min(x => x.Y) - 1;
            var maxY = tiles.Keys.Max(x => x.Y) + 1;

            for (var x = minX; x <= maxX; x++)
            {
                for (var y = minY; y <= maxY; y++)
                {
                    var value = tiles.GetValueOrDefault((x, y));
                    var neighbors = GetNeighbors(x, y);
                    var count = neighbors.Count(n => tiles.GetValueOrDefault(n));

                    newTiles[(x, y)] = value switch
                    {
                        true when count is 0 or > 2 => false,
                        false when count is 2 => true,
                        _ => value
                    };
                }
            }

            (tiles, newTiles) = (newTiles, tiles);
        }

        return tiles.Count(x => x.Value);
    }

    private static IEnumerable<(int X, int Y)> GetNeighbors(int x, int y) => new[]
    {
        (x - 1, y),
        (x + 1, y),
        (x, y + 1),
        (x + 1, y + 1),
        (x - 1, y - 1),
        (x, y - 1),
    };

    private static Dictionary<(int X, int Y), bool> GetTiles(IEnumerable<string> input)
    {
        var tiles = new Dictionary<(int X, int Y), bool>();

        foreach (var line in input)
        {
            var (x, y) = (0, 0);

            for (var i = 0; i < line.Length; i++)
            {
                var c1 = line[i];
                var c2 = line.ElementAtOrDefault(i + 1);

                switch (c1)
                {
                    case 'w':
                    {
                        x--;
                        break;
                    }
                    case 'e':
                    {
                        x++;
                        break;
                    }
                    case 'n' when c2 == 'w':
                    {
                        y++;
                        i++;
                        break;
                    }
                    case 'n' when c2 == 'e':
                    {
                        x++;
                        y++;
                        i++;
                        break;
                    }
                    case 's' when c2 == 'w':
                    {
                        x--;
                        y--;
                        i++;
                        break;
                    }
                    case 's' when c2 == 'e':
                    {
                        y--;
                        i++;
                        break;
                    }
                }
            }

            var value = tiles.GetValueOrDefault((x, y));
            tiles[(x, y)] = !value;
        }

        return tiles;
    }
}
