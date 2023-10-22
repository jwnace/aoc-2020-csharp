namespace aoc_2020_csharp.Day20;

    public record Tile(int Id, string[] Data)
    {
        public static Tile Parse(string input)
        {
            var lines = input.Split("\n");
            var id = int.Parse(lines[0].Split(" ")[1].TrimEnd(':'));
            var data = lines[1..].Select(l => l.Trim()).ToArray();
            return new Tile(id, data);
        }

        public string[] Middle => Data[1..^1].Select(row => row[1..^1]).ToArray();

        public string Top => Data[0];

        public string Bottom => Data[^1];

        public string Left => new(Data.Select(row => row[0]).ToArray());

        public string Right => new(Data.Select(row => row[^1]).ToArray());

        public string[] Edges => new[] { Top, Bottom, Left, Right };

        public bool HasMatchingEdge(Tile other)
        {
            var otherEdges = other.Edges.Concat(other.Edges.Select(e => new string(e.Reverse().ToArray())));
            return Edges.Intersect(otherEdges).Any();
        }

        public Tile[] Orientations()
        {
            var orientations = new List<Tile>();
            var tile = this;

            for (var i = 0; i < 4; i++)
            {
                orientations.Add(tile);
                orientations.Add(tile.Flip());
                tile = tile.Rotate();
            }

            return orientations.ToArray();
        }

        private Tile Flip()
        {
            var newData = new string[Data.Length];

            for (var i = 0; i < Data.Length; i++)
            {
                newData[i] = new string(Data[i].Reverse().ToArray());
            }

            return new Tile(Id, newData);
        }

        private Tile Rotate()
        {
            var newData = new string[Data.Length];

            for (var i = 0; i < Data.Length; i++)
            {
                newData[i] = new string(Data.Select(row => row[i]).Reverse().ToArray());
            }

            return new Tile(Id, newData);
        }

        public bool ContainsEdge(string edge) =>
            Edges.Contains(edge) || Edges.Contains(new string(edge.Reverse().ToArray()));
    }
