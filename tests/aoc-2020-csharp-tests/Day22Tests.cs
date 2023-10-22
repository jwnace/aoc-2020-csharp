using aoc_2020_csharp.Day22;

namespace aoc_2020_csharp_tests;

public class Day22Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input =
            """
            Player 1:
            9
            2
            6
            3
            1

            Player 2:
            5
            8
            4
            7
            10
            """;

        Day22.Solve1(input).Should().Be(306);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day22.Part1().Should().Be(32783);
    }

    [Test]
    public void Part2_Example_ReturnsCorrectAnswer()
    {
        var input =
            """
            Player 1:
            9
            2
            6
            3
            1

            Player 2:
            5
            8
            4
            7
            10
            """;

        Day22.Solve2(input).Should().Be(291);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day22.Part2().Should().Be(33455);
    }
}
