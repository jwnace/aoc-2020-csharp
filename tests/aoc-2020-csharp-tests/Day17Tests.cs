using aoc_2020_csharp.Day17;

namespace aoc_2020_csharp_tests;

public class Day17Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 240;
        var actual = Day17.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1180;
        var actual = Day17.Part2();
        actual.Should().Be(expected);
    }
}
