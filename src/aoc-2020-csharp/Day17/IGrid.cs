namespace aoc_2020_csharp.Day17;

public interface IGrid<TGrid, TCoordinate>
{
    static abstract TGrid Parse(string input);
    int Count(Func<KeyValuePair<TCoordinate, bool>, bool> func);
    TGrid Step();
}
