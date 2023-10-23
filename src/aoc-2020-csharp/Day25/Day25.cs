using aoc_2020_csharp.Extensions;

namespace aoc_2020_csharp.Day25;

public static class Day25
{
    private static readonly int[] Input = File.ReadAllLines("Day25/day25.txt").Select(int.Parse).ToArray();

    public static long Part1() => Solve1(Input);

    public static string Part2() => "Merry Christmas!";

    public static long Solve1(int[] input)
    {
        var (cardPublicKey, doorPublicKey) = input;
        var cardLoopSize = FindLoopSize(cardPublicKey);

        return Transform(doorPublicKey, cardLoopSize);
    }

    private static long FindLoopSize(int cardPublicKey)
    {
        var value = 1L;
        var loopSize = 0L;

        while (value != cardPublicKey)
        {
            value = value * 7 % 20201227;
            loopSize++;
        }

        return loopSize;
    }

    private static long Transform(int doorPublicKey, long cardLoopSize)
    {
        var value = 1L;

        for (var i = 0; i < cardLoopSize; i++)
        {
            value = value * doorPublicKey % 20201227;
        }

        return value;
    }
}
