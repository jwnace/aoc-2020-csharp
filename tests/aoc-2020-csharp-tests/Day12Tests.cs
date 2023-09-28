using aoc_2020_csharp.Day12;

namespace aoc_2020_csharp_tests;

public class Day12Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        };

        var expected = 25;
        var actual = Day12.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 2458;
        var actual = Day12.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        };

        var expected = 286;
        var actual = Day12.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 145117;
        var actual = Day12.Part2();
        actual.Should().Be(expected);
    }
}
