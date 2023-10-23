using System.Text;

namespace aoc_2020_csharp.Day23;

public static class Day23
{
    private static readonly string Input = File.ReadAllText("Day23/day23.txt");

    public static string Part1() => Solve1(Input, 100, 9);

    public static long Part2() => Solve2(Input, 10_000_000, 1_000_000);

    public static string Solve1(string input, int moves, int maxCup)
    {
        var cups = Shuffle(input, moves, maxCup);

        return GetAnswerForPart1(cups, maxCup);
    }

    public static long Solve2(string input, int moves, int maxCup)
    {
        var cups = Shuffle(input, moves, maxCup);

        return GetAnswerForPart2(cups);
    }

    private static Dictionary<int, Cup> Shuffle(string input, int moves, int maxCup)
    {
        var cups = GetCups(input, maxCup);
        var currentCup = cups.First().Value;

        for (var i = 0; i < moves; i++)
        {
            var pickedUpCups = new[] { currentCup.Next, currentCup.Next.Next, currentCup.Next.Next.Next };
            var destinationCup = GetDestinationCup(currentCup, cups, pickedUpCups, maxCup);

            currentCup.Next = pickedUpCups.Last().Next;
            pickedUpCups.Last().Next = destinationCup.Next;
            destinationCup.Next = pickedUpCups.First();

            currentCup = currentCup.Next;
        }

        return cups;
    }

    private static Dictionary<int, Cup> GetCups(string input, int maxCup)
    {
        var cups = input.Trim().Select(c => int.Parse(c.ToString())).ToArray();

        if (maxCup > 0)
        {
            var rest = Enumerable.Range(cups.Max() + 1, maxCup - cups.Max()).ToArray();
            cups = cups.Concat(rest).ToArray();
        }

        var nodes = new Dictionary<int, Cup>();

        Cup? previous = null;

        foreach (var cup in cups)
        {
            var node = new Cup
            {
                Value = cup
            };

            nodes[cup] = node;

            if (previous is not null)
            {
                previous.Next = node;
            }

            previous = node;
        }

        nodes.Last().Value.Next = nodes.First().Value;

        return nodes;
    }

    private static Cup GetDestinationCup(Cup currentCup, Dictionary<int, Cup> cups, Cup[] pickedUpCups, int maxCup)
    {
        var destinationValue = currentCup.Value - 1;

        while (pickedUpCups.Any(x => x.Value == destinationValue) || destinationValue < 1)
        {
            destinationValue--;

            if (destinationValue < 1)
            {
                destinationValue = maxCup;
            }
        }

        return cups[destinationValue];
    }

    private static string GetAnswerForPart1(Dictionary<int, Cup> cups, int maxCup)
    {
        var cup = cups[1];

        var builder = new StringBuilder();

        for (var i = 0; i < maxCup - 1; i++)
        {
            cup = cup.Next;
            builder.Append(cup.Value);
        }

        return builder.ToString();
    }

    private static long GetAnswerForPart2(Dictionary<int, Cup> cups) =>
        (long)cups[1].Next.Value * cups[1].Next.Next.Value;
}
