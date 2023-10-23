namespace aoc_2020_csharp.Day24;

public static class Day24
{
    private static readonly string[] Input = File.ReadAllLines("Day24/day24.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input)
    {
        var blackTiles = new HashSet<(int, int)>();

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

        return blackTiles.Count;
    }

    public static int Solve2(string[] input)
    {
        throw new NotImplementedException();
    }
}
