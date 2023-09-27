using aoc_2020_csharp.Day06;

namespace aoc_2020_csharp_tests;

public class Day06Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input =
            """
            abc

            a
            b
            c

            ab
            ac

            a
            a
            a
            a

            b
            """;

        var expected = 11;
        var actual = Day06.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 6504;
        var actual = Day06.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_Example_ReturnsCorrectAnswer()
    {
        var input =
            """
            abc

            a
            b
            c

            ab
            ac

            a
            a
            a
            a

            b
            """;

        var expected = 6;
        var actual = Day06.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 3351;
        var actual = Day06.Part2();
        actual.Should().Be(expected);
    }
}
