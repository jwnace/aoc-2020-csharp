﻿using aoc_2020_csharp.Day07;

namespace aoc_2020_csharp_tests;

public class Day07Tests
{
    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        var expected = 126;
        var actual = Day07.Part1();
        actual.Should().Be(expected);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        var expected = 220149;
        var actual = Day07.Part2();
        actual.Should().Be(expected);
    }
}
