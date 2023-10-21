using aoc_2020_csharp.Day19;

namespace aoc_2020_csharp_tests;

public class Day19Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input =
            """
            0: 4 1 5
            1: 2 3 | 3 2
            2: 4 4 | 5 5
            3: 4 5 | 5 4
            4: "a"
            5: "b"

            ababbb
            bababa
            abbbab
            aaabbb
            aaaabbb
            """;

        Day19.Solve1(input).Should().Be(2);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day19.Part1().Should().Be(107);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day19.Part2().Should().Be(0);
    }
}
