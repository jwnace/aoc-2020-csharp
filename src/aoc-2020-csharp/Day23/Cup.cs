namespace aoc_2020_csharp.Day23;

public class Cup
{
    public int Value { get; init; }
    public Cup Next { get; set; } = null!;
}
