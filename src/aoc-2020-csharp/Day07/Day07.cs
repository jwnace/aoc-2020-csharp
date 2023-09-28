namespace aoc_2020_csharp.Day07;

public static class Day07
{
    private static readonly string Input = File.ReadAllText("Day07/day07.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input) => GetBags(input).Count(x => x.Value.CanContain("shiny gold"));

    public static int Solve2(string input) => GetBags(input)["shiny gold"].CountAllChildren();

    private static Dictionary<string, Bag> GetBags(string input)
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
                var childCount = int.Parse(childParts[0]);
                var childColor = $"{childParts[1]} {childParts[2]}";

                var childBag = bags.TryGetValue(childColor, out var cb) ? cb : new Bag(childColor);
                bags[childColor] = childBag;

                bag.Children[childBag] = childCount;
            }
        }

        return bags;
    }
}
