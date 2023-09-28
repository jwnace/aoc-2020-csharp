using aoc_2020_csharp.Day13;

namespace aoc_2020_csharp_tests;

public class Day13Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input = new[] { "939", "7,13,x,x,59,x,31,19" };
        var expected = 295;
        var actual = Day13.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 2092;
        var actual = Day13.Part1();
        actual.Should().Be(expected);
    }

    [TestCase(new[] { "939", "7,13,x,x,59,x,31,19" }, 1068781)]
    [TestCase(new[] { "939", "17,x,13,19" }, 3417)]
    [TestCase(new[] { "939", "67,7,59,61" }, 754018)]
    [TestCase(new[] { "939", "67,x,7,59,61" }, 779210)]
    [TestCase(new[] { "939", "67,7,x,59,61" }, 1261476)]
    [TestCase(new[] { "939", "1789,37,47,1889" }, 1202161486)]
    public void Part2_Example_ReturnsCorrectAnswer(string[] input, long expected)
    {
        var actual = Day13.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 702970661767766;
        var actual = Day13.Part2();
        actual.Should().Be(expected);
    }
}
