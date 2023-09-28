namespace aoc_2020_csharp.Day07;

public class Bag
{
    private string Color { get; }

    public Bag(string color)
    {
        Color = color;
    }

    public Dictionary<Bag, int> Children { get; } = new();

    public bool CanContain(string color) =>
        Children.Any(c => c.Key.Color == color) || Children.Any(c => c.Key.CanContain(color));

    public int CountAllChildren() => Children.Sum(c => c.Value * (1 + c.Key.CountAllChildren()));
}
