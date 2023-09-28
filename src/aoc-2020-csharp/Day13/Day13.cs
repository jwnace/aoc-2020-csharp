namespace aoc_2020_csharp.Day13;

public static class Day13
{
    private static readonly string[] Input = File.ReadAllLines("Day13/day13.txt");

    public static int Part1() => Solve1(Input);

    public static long Part2() => Solve2(Input);

    public static int Solve1(string[] input)
    {
        var earliest = int.Parse(input[0]);
        var buses = input[1].Split(',').Where(x => x != "x").Select(int.Parse).ToList();

        var waitTimes = buses.Select(b => (Bus: b, WaitTime: b - earliest % b)).ToList();
        var (bus, waitTime) = waitTimes.MinBy(x => x.WaitTime);

        return bus * waitTime;
    }

    public static long Solve2(string[] input)
    {
        var buses = input[1].Split(',')
            .Select((b, i) => (Bus: b, Index: i))
            .Where(b => b.Bus != "x")
            .Select(b => (Bus: long.Parse(b.Bus), b.Index))
            .ToList();

        var step = buses[0].Bus;
        var time = 0L;

        foreach (var (b, i) in buses.Skip(1))
        {
            while ((time + i) % b != 0)
            {
                time += step;
            }

            step *= b;
        }

        return time;
    }
}
