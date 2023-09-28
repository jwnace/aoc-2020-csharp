using aoc_2020_csharp.Day14;

namespace aoc_2020_csharp_tests;

public class Day14Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
            "mem[8] = 11",
            "mem[7] = 101",
            "mem[8] = 0",
        };

        var expected = 165;
        var actual = Day14.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 15919415426101;
        var actual = Day14.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "mask = 000000000000000000000000000000X1001X",
            "mem[42] = 100",
            "mask = 00000000000000000000000000000000X0XX",
            "mem[26] = 1",
        };

        var expected = 208;
        var actual = Day14.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 3443997590975;
        var actual = Day14.Part2();
        actual.Should().Be(expected);
    }
}
