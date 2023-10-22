using aoc_2020_csharp.Extensions;

namespace aoc_2020_csharp.Day22;

public static class Day22
{
    private static readonly string Input = File.ReadAllText("Day22/day22.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input)
    {
        var (player1, player2) = input
            .Trim()
            .Split("\n\n")
            .Select(p => new Queue<int>(p.Split("\n").Skip(1).Select(int.Parse).ToArray()))
            .ToArray();

        while (player1.Any() && player2.Any())
        {
            var card1 = player1.Dequeue();
            var card2 = player2.Dequeue();

            if (card1 > card2)
            {
                player1.Enqueue(card1);
                player1.Enqueue(card2);
            }
            else
            {
                player2.Enqueue(card2);
                player2.Enqueue(card1);
            }
        }

        return player1.Count == 0
            ? CalculateScore(player2)
            : CalculateScore(player1);
    }

    public static int Solve2(string input)
    {
        throw new NotImplementedException();
    }

    private static int CalculateScore(Queue<int> player) =>
        player.Reverse().Select((card, i) => card * (i + 1)).Sum();
}
