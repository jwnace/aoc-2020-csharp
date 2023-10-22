namespace aoc_2020_csharp.Day20;

public static class Day20
{
    private static readonly string Input = File.ReadAllText("Day20/day20.txt").Trim();

    public static long Part1() => Solve1(Input);

    public static long Part2() => Solve2(Input);

    public static long Solve1(string input)
    {
        var tiles = input.Split("\n\n").Select(Tile.Parse).ToList();
        var result = 1L;

        foreach (var tile in tiles)
        {
            var otherTiles = tiles.Where(t => t.Id != tile.Id).ToList();

            var matchingEdges = tile.Edges.Where(e => otherTiles.Any(t => t.Edges.Contains(e) || t.Edges.Contains(new string(e.Reverse().ToArray())))).ToList();

            if (matchingEdges.Count == 2)
            {
                result *= tile.Id;
            }
        }

        return result;
    }

    public static long Solve2(string input)
    {
        throw new NotImplementedException();
    }

    private record Tile(int Id, string[] Data)
    {
        public static Tile Parse(string input)
        {
            var lines = input.Split("\n");
            var id = int.Parse(lines[0].Split(" ")[1].TrimEnd(':'));
            var data = lines[1..].Select(l => l.Trim()).ToArray();
            return new Tile(id, data);
        }

        private string Top => Data[0];

        private string Bottom => Data[^1];

        private string Left => new(Data.Select(row => row[0]).ToArray());

        private string Right => new(Data.Select(row => row[^1]).ToArray());

        public string[] Edges => new[] { Top, Bottom, Left, Right };
    }
}
