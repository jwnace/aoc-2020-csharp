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
        var (player1, player2) = input
            .Trim()
            .Split("\n\n")
            .Select(p => new Queue<int>(p.Split("\n").Skip(1).Select(int.Parse).ToArray()))
            .ToArray();

        return Solve2Recursive(player1, player2).Score;
    }

    private static (int Winner, int Score) Solve2Recursive(Queue<int> player1, Queue<int> player2)
    {
        var seen = new List<(int[] Player1, int[] Player2)>();

        while (player1.Any() && player2.Any())
        {
            if (seen.Any(x => x.Player1.SequenceEqual(player1) && x.Player2.SequenceEqual(player2)))
            {
                return (1, CalculateScore(player1));
            }

            seen.Add((player1.ToArray(), player2.ToArray()));

            var card1 = player1.Dequeue();
            var card2 = player2.Dequeue();

            if (player1.Count >= card1 && player2.Count >= card2)
            {
                var newPlayer1 = new Queue<int>(player1.Take(card1));
                var newPlayer2 = new Queue<int>(player2.Take(card2));
                var result = Solve2Recursive(newPlayer1, newPlayer2);

                if (result.Winner == 1)
                {
                    player1.Enqueue(card1);
                    player1.Enqueue(card2);
                }
                else
                {
                    player2.Enqueue(card2);
                    player2.Enqueue(card1);
                }

                continue;
            }

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
            ? (2, CalculateScore(player2))
            : (1, CalculateScore(player1));
    }

    private static int CalculateScore(IEnumerable<int> player) =>
        player.Reverse().Select((card, i) => card * (i + 1)).Sum();
}
