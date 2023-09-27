namespace aoc_2020_csharp.Day07;

public static class Day07
{
    private static readonly string Input = File.ReadAllText("Day07/day07.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => 2;

    public static int Solve1(string input)
    {
        var bags = new Dictionary<string, Bag>();
        var rules = input.Split(Environment.NewLine);

        foreach (var rule in rules)
        {
            var parts = rule.Split(" bags contain ");
            var color = parts[0];
            var children = parts[1].Split(", ");

            var bag = bags.TryGetValue(color, out var b) ? b : new Bag(color);
            bags[color] = bag;

            foreach (var child in children)
            {
                if (child == "no other bags.")
                {
                    continue;
                }

                var childParts = child.Split(" ");
                var childColor = $"{childParts[1]} {childParts[2]}";

                var childBag = bags.TryGetValue(childColor, out var cb) ? cb : new Bag(childColor);
                bags[childColor] = childBag;

                bag.Children.Add(childBag);
            }
        }

        return bags.Count(x => x.Value.CanContain("shiny gold"));
    }

    public static int Solve2(string input)
    {
        return 2;
    }

    private class Bag
    {
        // private Bag? _parent = null;

        public Bag(string color)
        {
            Color = color;
        }

        public string Color { get; }

        // public Bag? Parent
        // {
            // get => _parent;
            // set => _parent = _parent is null ? value : throw new Exception("Parent already set");
        // }

        public List<Bag> Children { get; } = new();

        public bool CanContain(string color) =>
            Children.Any(c => c.Color == color) || Children.Any(c => c.CanContain(color));

        // public void Deconstruct(out string Color, out Bag? Parent, out List<Bag>? Children)
        // {
        //     Color = this.Color;
        //     Parent = this.Parent;
        //     Children = this.Children;
        // }
    }
}
