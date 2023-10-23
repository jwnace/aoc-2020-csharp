namespace aoc_2020_csharp.Day23;

public static class Day23
{
    private static readonly string Input = File.ReadAllText("Day23/day23.txt");

    public static string Part1() => Solve1(Input, 100);

    public static int Part2() => 2;

    public static string Solve1(string input, int moves)
    {
        var cups = input.Trim().Select(c => int.Parse(c.ToString())).ToArray();
        var currentCup = cups[0];

        for (var i = 0; i < moves; i++)
        {
            var currentCupIndex = Array.IndexOf(cups, currentCup);

            if (currentCupIndex > cups.Length - 4)
            {
                cups = cups.Skip(3).Concat(cups.Take(3)).ToArray();
                currentCupIndex = Array.IndexOf(cups, currentCup);
            }

            var pickedUpCups = cups.Skip(currentCupIndex + 1).Take(3).ToArray();
            var remainingCups = cups.Take(currentCupIndex + 1).Concat(cups.Skip(currentCupIndex + 4)).ToArray();
            var destinationCup = currentCup - 1;
            while (pickedUpCups.Contains(destinationCup) || destinationCup < 1)
            {
                destinationCup--;
                if (destinationCup < 1)
                {
                    destinationCup = cups.Max();
                }
            }

            var destinationCupIndex = Array.IndexOf(remainingCups, destinationCup);
            cups = remainingCups.Take(destinationCupIndex + 1).Concat(pickedUpCups)
                .Concat(remainingCups.Skip(destinationCupIndex + 1)).ToArray();
            currentCup = cups[(Array.IndexOf(cups, currentCup) + 1) % cups.Length];
        }

        var indexOf1 = Array.IndexOf(cups, 1);

        return string.Join("", cups.Skip(indexOf1 + 1).Concat(cups.Take(indexOf1)));
    }


    public static long Solve2(string input, int moves)
    {
        throw new NotImplementedException();
    }
}
