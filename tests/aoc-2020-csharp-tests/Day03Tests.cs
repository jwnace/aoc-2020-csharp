using aoc_2020_csharp.Day03;

namespace aoc_2020_csharp_tests;

public class Day03Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#",
        };

        var expected = 7;
        var actual = Day03.Solve1(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 225;
        var actual = Day03.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#",
        };

        var expected = 336;
        var actual = Day03.Solve2(input);
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 1115775000;
        var actual = Day03.Part2();
        actual.Should().Be(expected);
    }
}
