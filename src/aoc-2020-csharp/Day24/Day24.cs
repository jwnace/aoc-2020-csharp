namespace aoc_2020_csharp.Day24;

public static class Day24
{
    private static readonly string[] Input = File.ReadAllLines("Day24/day24.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input) => GetTiles(input).Count(x => x.Value);

    public static int Solve2(string[] input)
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

                    if (value && (count == 0 || count > 2))
                    {
                        newTiles[(x, y)] = false;
                    }
                    else if (!value && count == 2)
                    {
                        newTiles[(x, y)] = true;
                    }
                    else
                    {
                        newTiles[(x, y)] = value;
                    }
                }
            }

            (tiles, newTiles) = (newTiles, tiles);
        }

        return tiles.Count(x => x.Value);
    }

    private static (int, int)[] GetNeighbors(int x, int y)
    {
        var neighbors = new[]
        {
            (x - 1, y),
            (x + 1, y),
            (x, y + 1),
            (x + 1, y + 1),
            (x - 1, y - 1),
            (x, y - 1),
        };
        return neighbors;
    }

    private static HashSet<(int X, int Y)> GetBlackTiles(string[] input)
    {
        var blackTiles = new HashSet<(int X, int Y)>();

        foreach (var line in input)
        {
            var (x, y) = (0, 0);

            for (var i = 0; i < line.Length; i++)
            {
                var c1 = line[i];
                var c2 = line.ElementAtOrDefault(i + 1);

                if (c1 == 'w')
                {
                    // go west
                    x--;
                }
                else if (c1 == 'e')
                {
                    // go east
                    x++;
                }
                else if (c1 == 'n' && c2 == 'w')
                {
                    // go northwest
                    y++;
                    i++;
                }
                else if (c1 == 'n' && c2 == 'e')
                {
                    // go northeast
                    x++;
                    y++;
                    i++;
                }
                else if (c1 == 's' && c2 == 'w')
                {
                    // go southwest
                    x--;
                    y--;
                    i++;
                }
                else if (c1 == 's' && c2 == 'e')
                {
                    // go southeast
                    y--;
                    i++;
                }
                else
                {
                    throw new Exception($"Invalid direction: {c1}{c2}");
                }
            }

            if (blackTiles.Contains((x, y)))
            {
                blackTiles.Remove((x, y));
            }
            else
            {
                blackTiles.Add((x, y));
            }
        }

        return blackTiles;
    }

    private static Dictionary<(int X, int Y), bool> GetTiles(string[] input)
    {
        var tiles = new Dictionary<(int X, int Y), bool>();

        foreach (var line in input)
        {
            var (x, y) = (0, 0);

            for (var i = 0; i < line.Length; i++)
            {
                var c1 = line[i];
                var c2 = line.ElementAtOrDefault(i + 1);

                if (c1 == 'w')
                {
                    // go west
                    x--;
                }
                else if (c1 == 'e')
                {
                    // go east
                    x++;
                }
                else if (c1 == 'n' && c2 == 'w')
                {
                    // go northwest
                    y++;
                    i++;
                }
                else if (c1 == 'n' && c2 == 'e')
                {
                    // go northeast
                    x++;
                    y++;
                    i++;
                }
                else if (c1 == 's' && c2 == 'w')
                {
                    // go southwest
                    x--;
                    y--;
                    i++;
                }
                else if (c1 == 's' && c2 == 'e')
                {
                    // go southeast
                    y--;
                    i++;
                }
                else
                {
                    throw new Exception($"Invalid direction: {c1}{c2}");
                }
            }

            var value = tiles.GetValueOrDefault((x, y));
            tiles[(x, y)] = !value;
        }

        return tiles;
    }
}
