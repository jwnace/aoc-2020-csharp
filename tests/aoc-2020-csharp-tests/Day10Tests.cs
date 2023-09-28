using aoc_2020_csharp.Day10;

namespace aoc_2020_csharp_tests;

public class Day10Tests
{
    [TestCase(new[] { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 }, 35)]
    [TestCase(new[] { 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3 }, 220)]
    public void Part1_Example_ReturnsCorrectAnswer(int[] input, int expected)
    {
        var actual = Day10.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 2059;
        var actual = Day10.Part1();
        actual.Should().Be(expected);
    }

    [TestCase(new[] { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 }, 8)]
    [TestCase(new[] { 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3 }, 19208)]
    public void Part2_Example_ReturnsCorrectAnswer(int[] input, int expected)
    {
        var actual = Day10.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 86812553324672;
        var actual = Day10.Part2();
        actual.Should().Be(expected);
    }
}
