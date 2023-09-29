using aoc_2020_csharp.Day18;

namespace aoc_2020_csharp_tests;

public class Day18Tests
{
    [TestCase("1 + 2 * 3 + 4 * 5 + 6", 71)]
    [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
    [TestCase("2 * 3 + (4 * 5)", 26)]
    [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
    [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
    [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
    public void Part1_Examples_ReturnCorrectAnswer(string input, long expected)
    {
        var actual = Day18.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 21347713555555;
        var actual = Day18.Part1();
        actual.Should().Be(expected);
    }

    [TestCase("1 + 2 * 3 + 4 * 5 + 6", 231)]
    [TestCase("1 + (2 * 3) + (4 * (5 + 6))", 51)]
    [TestCase("2 * 3 + (4 * 5)", 46)]
    [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
    [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
    [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
    public void Part2_Examples_ReturnCorrectAnswer(string input, long expected)
    {
        var actual = Day18.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 275011754427339;
        var actual = Day18.Part2();
        actual.Should().Be(expected);
    }
}
