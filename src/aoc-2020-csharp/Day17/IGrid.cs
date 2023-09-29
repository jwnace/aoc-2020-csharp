namespace aoc_2020_csharp.Day17;

public interface IGrid<TGrid>
{
    static abstract TGrid Parse(string input);
    TGrid Step();
    int CountActive();
}
