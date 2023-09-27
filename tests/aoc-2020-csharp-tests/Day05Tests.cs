using aoc_2020_csharp.Day05;

namespace aoc_2020_csharp_tests;

public class Day05Tests
{
    [TestCase("FBFBBFFRLR", 357)]
    [TestCase("BFFFBBFRRR", 567)]
    [TestCase("FFFBBBFRRR", 119)]
    [TestCase("BBFFBBFRLL", 820)]
    public void GetSeatId_ReturnsCorrectAnswer(string input, int expected)
    {
        var actual = Day05.GetSeatId(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 892;
        var actual = Day05.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 625;
        var actual = Day05.Part2();
        actual.Should().Be(expected);
    }
}
