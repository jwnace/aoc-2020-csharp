using aoc_2020_csharp.Day01;

namespace aoc_2020_csharp_tests;

public class Day01Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input = new[] { 1721, 979, 366, 299, 675, 1456 };
        var expected = 514579;
        var actual = Day01.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 1010299;
        var actual = Day01.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_Example_ReturnsCorrectAnswer()
    {
        var input = new[] { 1721, 979, 366, 299, 675, 1456 };
        var expected = 241861950;
        var actual = Day01.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 42140160;
        var actual = Day01.Part2();
        actual.Should().Be(expected);
    }
}
