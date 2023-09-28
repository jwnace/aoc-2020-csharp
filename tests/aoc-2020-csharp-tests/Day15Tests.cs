using aoc_2020_csharp.Day15;

namespace aoc_2020_csharp_tests;

public class Day15Tests
{
    [TestCase(new[] { 0, 3, 6 }, 436)]
    [TestCase(new[] { 1, 3, 2 }, 1)]
    [TestCase(new[] { 2, 1, 3 }, 10)]
    [TestCase(new[] { 1, 2, 3 }, 27)]
    [TestCase(new[] { 2, 3, 1 }, 78)]
    [TestCase(new[] { 3, 2, 1 }, 438)]
    [TestCase(new[] { 3, 1, 2 }, 1836)]
    public void Part1_Examples_ReturnCorrectAnswer(int[] input, int expected)
    {
        var actual = Day15.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 371;
        var actual = Day15.Part1();
        actual.Should().Be(expected);
    }

    [TestCase(new[] { 0, 3, 6 }, 175594)]
    [TestCase(new[] { 1, 3, 2 }, 2578)]
    [TestCase(new[] { 2, 1, 3 }, 3544142)]
    [TestCase(new[] { 1, 2, 3 }, 261214)]
    [TestCase(new[] { 2, 3, 1 }, 6895259)]
    [TestCase(new[] { 3, 2, 1 }, 18)]
    [TestCase(new[] { 3, 1, 2 }, 362)]
    public void Part2_Examples_ReturnCorrectAnswer(int[] input, int expected)
    {
        var actual = Day15.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 352;
        var actual = Day15.Part2();
        actual.Should().Be(expected);
    }
}
