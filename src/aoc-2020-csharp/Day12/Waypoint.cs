namespace aoc_2020_csharp.Day12;

public class Waypoint
{
    public Waypoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }

    public void MoveNorth(int value) => Y += value;

    public void MoveSouth(int value) => Y -= value;

    public void MoveEast(int value) => X += value;

    public void MoveWest(int value) => X -= value;

    public void RotateLeft(int value)
    {
        var times = value / 90;

        for (var i = 0; i < times; i++)
        {
            (X, Y) = (-Y, X);
        }
    }

    public void RotateRight(int value)
    {
        var times = value / 90;

        for (var i = 0; i < times; i++)
        {
            (X, Y) = (Y, -X);
        }
    }
}
