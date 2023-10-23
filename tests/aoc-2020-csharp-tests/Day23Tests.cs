using aoc_2020_csharp.Day23;

namespace aoc_2020_csharp_tests;

public class Day23Tests
{
    [TestCase("389125467", 10, "92658374")]
    [TestCase("389125467", 100, "67384529")]
    public void Part1_Example_ReturnsCorrectAnswer(string input, int moves, string expected)
    {
        Day23.Solve1(input, moves).Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day23.Part1().Should().Be("32897654");
    }

    [TestCase("389125467", 10_000_000, 149245887792)]
    public void Part2_Example_ReturnsCorrectAnswer(string input, int moves, long expected)
    {
        Day23.Solve2(input, 10_000_000).Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day23.Part2().Should().Be(0);
    }
}
