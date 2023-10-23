using aoc_2020_csharp.Day25;

namespace aoc_2020_csharp_tests;

public class Day25Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input = new[] { 5764801, 17807724 };

        Day25.Solve1(input).Should().Be(14897079);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day25.Part1().Should().Be(19774660);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day25.Part2().Should().Be(0);
    }
}
