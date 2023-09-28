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
}
