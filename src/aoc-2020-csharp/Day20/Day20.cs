using System.Text;

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

            var matchingEdges = tile.Edges.Where(
                e => otherTiles.Any(t => t.Edges.Contains(e) || t.Edges.Contains(new string(e.Reverse().ToArray()))))
                .ToList();

            if (matchingEdges.Count == 2)
            {
                result *= tile.Id;
            }
        }

        return result;
    }

    public static long Solve2(string input)
    {
        var tiles = input.Split("\n\n").Select(Tile.Parse).ToList();
        var result = 1L;

        var corners = new List<Tile>();
        var edges = new List<Tile>();
        var middles = new List<Tile>();

        foreach (var tile in tiles)
        {
            var otherTiles = tiles.Where(t => t.Id != tile.Id).ToList();

            var matchingEdges = tile.Edges.Where(
                e => otherTiles.Any(t => t.Edges.Contains(e) || t.Edges.Contains(new string(e.Reverse().ToArray()))))
                .ToList();

            if (matchingEdges.Count == 2)
            {
                corners.Add(tile);
            }
            else if (matchingEdges.Count == 3)
            {
                edges.Add(tile);
            }
            else
            {
                middles.Add(tile);
            }
        }

        var size = (int)Math.Sqrt(tiles.Count);

        var grid = new Tile[size, size];

        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++)
            {
                if (row == 0 && col == 0)
                {
                    grid[row, col] = corners.First();
                    corners.Remove(corners.First());
                    continue;
                }

                if (row == 0 && col < size - 1)
                {
                    var left = grid[row, col - 1];
                    var right = edges.First(e => e.HasMatchingEdge(left));
                    grid[row, col] = right;
                    edges.Remove(right);
                    continue;
                }

                if (row == 0 && col == size - 1)
                {
                    var left = grid[row, col - 1];
                    var right = corners.First(c => c.HasMatchingEdge(left));
                    grid[row, col] = right;
                    corners.Remove(right);
                    continue;
                }

                if (row > 0 && row < size - 1 && col == 0)
                {
                    var top = grid[row - 1, col];
                    var bottom = edges.First(e => e.HasMatchingEdge(top));

                    grid[row, col] = bottom;
                    edges.Remove(bottom);
                    continue;
                }

                if (row > 0 && row < size - 1 && col < size - 1)
                {
                    var top = grid[row - 1, col];
                    var left = grid[row, col - 1];
                    var bottom = middles.First(m => m.HasMatchingEdge(top) && m.HasMatchingEdge(left));
                    grid[row, col] = bottom;
                    middles.Remove(bottom);
                    continue;
                }

                if (row > 0 && row < size - 1 && col == size - 1)
                {
                    var top = grid[row - 1, col];
                    var left = grid[row, col - 1];
                    var bottom = edges.First(e => e.HasMatchingEdge(top) && e.HasMatchingEdge(left));
                    grid[row, col] = bottom;
                    edges.Remove(bottom);
                    continue;
                }

                if (row == size - 1 && col == 0)
                {
                    var top = grid[row - 1, col];
                    var bottom = corners.First(c => c.HasMatchingEdge(top));
                    grid[row, col] = bottom;
                    corners.Remove(bottom);
                    continue;
                }

                if (row == size - 1 && col < size - 1)
                {
                    var top = grid[row - 1, col];
                    var left = grid[row, col - 1];
                    var bottom = edges.First(e => e.HasMatchingEdge(top) && e.HasMatchingEdge(left));
                    grid[row, col] = bottom;
                    edges.Remove(bottom);
                    continue;
                }

                if (row == size - 1 && col == size - 1)
                {
                    var top = grid[row - 1, col];
                    var left = grid[row, col - 1];
                    var bottom = corners.Single();
                    grid[row, col] = bottom;
                    corners.Remove(bottom);
                    continue;
                }
            }
        }

        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++)
            {
                var top = row > 0 ? grid[row - 1, col] : null;
                var left = col > 0 ? grid[row, col - 1] : null;
                var bottom = row < size - 1 ? grid[row + 1, col] : null;
                var right = col < size - 1 ? grid[row, col + 1] : null;

                var tile = grid[row, col];

                var query = tile.Orientations().Single(o =>
                    (top == null || top.ContainsEdge(o.Top)) &&
                    (left == null || left.ContainsEdge(o.Left)) &&
                    (bottom == null || bottom.ContainsEdge(o.Bottom)) &&
                    (right == null || right.ContainsEdge(o.Right)));

                grid[row, col] = query;
            }
        }

        var render = DrawGrid(grid);
        var lines = render.Trim().Split("\n");

        var orientations = GetOrientations(lines);
        var monsters = 0;

        foreach(var orientation in orientations)
        {
            for (var row = 0; row < orientation.Length - 2 - 1; row++)
            {
                for (var col = 0; col < orientation[row].Length - 19 - 1; col++)
                {
                    var monster = new (int Row, int Col)[]
                    {
                        (row + 1, col + 0),
                        (row + 2, col + 1),
                        (row + 2, col + 4),
                        (row + 1, col + 5),
                        (row + 1, col + 6),
                        (row + 2, col + 7),
                        (row + 2, col + 10),
                        (row + 1, col + 11),
                        (row + 1, col + 12),
                        (row + 2, col + 13),
                        (row + 2, col + 16),
                        (row + 1, col + 17),
                        (row + 0, col + 18),
                        (row + 1, col + 18),
                        (row + 1, col + 19),
                    };

                    var match = monster.Where(x => orientation[x.Row][x.Col] == '#');
                    var dontMatch = monster.Where(x => orientation[x.Row][x.Col] != '#');

                    if (monster.All(x => orientation[x.Row][x.Col] == '#'))
                    {
                        Console.WriteLine("found a monster at " + row + ", " + col);
                        monsters++;
                    }
                }
            }
        }

        return render.Count(x => x == '#') - monsters * 15;
    }

    private static string DrawGrid(Tile[,] grid)
    {
        var builder = new StringBuilder();
        var size = grid.GetLength(0);
        var tileSize = grid[0, 0].Middle.Length;

        var image = new char[size * tileSize, size * tileSize];

        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++)
            {
                var tile = grid[row, col];

                for (var tileRow = 0; tileRow < tileSize; tileRow++)
                {
                    for (var tileCol = 0; tileCol < tileSize; tileCol++)
                    {
                        image[row * tileSize + tileRow, col * tileSize + tileCol] = tile.Middle[tileRow][tileCol];
                    }
                }
            }
        }

        for (var row = 0; row < image.GetLength(0); row++)
        {
            for (var col = 0; col < image.GetLength(1); col++)
            {
                builder.Append(image[row, col]);
            }

            builder.Append('\n');
        }

        return builder.ToString();
    }

    public static IEnumerable<string[]> GetOrientations(string[] tile)
    {
        for (var i = 0; i < 4; i++)
        {
            yield return tile;
            yield return Flip(tile);
            tile = Rotate(tile);
        }
    }

    private static string[] Rotate(string[] tile)
    {
        var result = new string[tile.Length];
        for (var i = 0; i < tile.Length; i++)
        {
            result[i] = new string(tile.Select(row => row[i]).Reverse().ToArray());
        }

        return result;
    }

    private static string[] Flip(string[] tile)
    {
        var result = new string[tile.Length];
        for (var i = 0; i < tile.Length; i++)
        {
            result[i] = new string(tile[i].Reverse().ToArray());
        }

        return result;
    }
}
