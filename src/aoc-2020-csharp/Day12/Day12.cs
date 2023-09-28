namespace aoc_2020_csharp.Day12;

public static class Day12
{
    private static readonly string[] Input = File.ReadAllLines("Day12/day12.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input)
    {
        var ship = new Ship(0, 0, Heading.East);

        foreach (var instruction in input)
        {
            var value = int.Parse(instruction[1..]);

            switch (instruction[0])
            {
                case 'N':
                    ship.MoveNorth(value);
                    break;
                case 'S':
                    ship.MoveSouth(value);
                    break;
                case 'E':
                    ship.MoveEast(value);
                    break;
                case 'W':
                    ship.MoveWest(value);
                    break;
                case 'L':
                    ship.TurnLeft(value);
                    break;
                case 'R':
                    ship.TurnRight(value);
                    break;
                case 'F':
                    ship.MoveForward(value);
                    break;
                default:
                    throw new Exception($"Invalid instruction: {instruction}");
            }
        }

        return Math.Abs(ship.X) + Math.Abs(ship.Y);
    }

    public static int Solve2(string[] input)
    {
        var ship = new Ship(0, 0, Heading.East);
        var waypoint = new Waypoint(10, 1);

        foreach (var instruction in input)
        {
            var value = int.Parse(instruction[1..]);

            switch (instruction[0])
            {
                case 'N':
                    waypoint.MoveNorth(value);
                    break;
                case 'S':
                    waypoint.MoveSouth(value);
                    break;
                case 'E':
                    waypoint.MoveEast(value);
                    break;
                case 'W':
                    waypoint.MoveWest(value);
                    break;
                case 'L':
                    waypoint.RotateLeft(value);
                    break;
                case 'R':
                    waypoint.RotateRight(value);
                    break;
                case 'F':
                    ship.MoveToWaypoint(waypoint, value);
                    break;
                default:
                    throw new Exception($"Invalid instruction: {instruction}");
            }
        }

        return Math.Abs(ship.X) + Math.Abs(ship.Y);
    }

    private class Ship
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

    private enum Heading
    {
        North,
        East,
        South,
        West
    }

    private class Waypoint
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
}
