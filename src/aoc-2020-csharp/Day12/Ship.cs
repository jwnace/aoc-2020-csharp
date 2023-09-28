namespace aoc_2020_csharp.Day12;

public class Ship
{
    private Heading Heading { get; set; }

    public int X { get; private set; }
    public int Y { get; private set; }

    public Ship(int x, int y, Heading heading)
    {
        Heading = heading;
        X = x;
        Y = y;
    }

    public void MoveNorth(int value) => Y += value;

    public void MoveSouth(int value) => Y -= value;

    public void MoveEast(int value) => X += value;

    public void MoveWest(int value) => X -= value;

    public void TurnLeft(int value)
    {
        var times = value / 90;

        for (var i = 0; i < times; i++)
        {
            Heading = Heading switch
            {
                Heading.East => Heading.North,
                Heading.North => Heading.West,
                Heading.West => Heading.South,
                Heading.South => Heading.East,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public void TurnRight(int value)
    {
        var times = value / 90;

        for (var i = 0; i < times; i++)
        {
            Heading = Heading switch
            {
                Heading.East => Heading.South,
                Heading.South => Heading.West,
                Heading.West => Heading.North,
                Heading.North => Heading.East,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public void MoveForward(int value)
    {
        switch (Heading)
        {
            case Heading.East:
                MoveEast(value);
                break;
            case Heading.South:
                MoveSouth(value);
                break;
            case Heading.West:
                MoveWest(value);
                break;
            case Heading.North:
                MoveNorth(value);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void MoveToWaypoint(Waypoint waypoint, int value)
    {
        for (var i = 0; i < value; i++)
        {
            (X, Y) = (X + waypoint.X, Y + waypoint.Y);
        }
    }
}
