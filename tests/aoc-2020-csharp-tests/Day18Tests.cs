﻿using aoc_2020_csharp.Day18;

namespace aoc_2020_csharp_tests;

public class Day18Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 21347713555555;
        var actual = Day18.Part1();
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
