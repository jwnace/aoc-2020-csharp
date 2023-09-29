using aoc_2020_csharp.Day16;

namespace aoc_2020_csharp_tests;

public class Day16Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input =
            """
            class: 1-3 or 5-7
            row: 6-11 or 33-44
            seat: 13-40 or 45-50

            your ticket:
            7,1,14

            nearby tickets:
            7,3,47
            40,4,50
            55,2,20
            38,6,12
            """;

        var expected = 71;
        var actual = Day16.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 22057;
        var actual = Day16.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1093427331937;
        var actual = Day16.Part2();
        actual.Should().Be(expected);
    }
}
