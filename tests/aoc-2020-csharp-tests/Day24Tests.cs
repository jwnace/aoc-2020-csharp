using aoc_2020_csharp.Day24;

namespace aoc_2020_csharp_tests;

public class Day24Tests
{
    [TestCase(new[]
    {
        "sesenwnenenewseeswwswswwnenewsewsw",
        "neeenesenwnwwswnenewnwwsewnenwseswesw",
        "seswneswswsenwwnwse",
        "nwnwneseeswswnenewneswwnewseswneseene",
        "swweswneswnenwsewnwneneseenw",
        "eesenwseswswnenwswnwnwsewwnwsene",
        "sewnenenenesenwsewnenwwwse",
        "wenwwweseeeweswwwnwwe",
        "wsweesenenewnwwnwsenewsenwwsesesenwne",
        "neeswseenwwswnwswswnw",
        "nenwswwsewswnenenewsenwsenwnesesenew",
        "enewnwewneswsewnwswenweswnenwsenwsw",
        "sweneswneswneneenwnewenewwneswswnese",
        "swwesenesewenwneswnwwneseswwne",
        "enesenwswwswneneswsenwnewswseenwsese",
        "wnwnesenesenenwwnenwsewesewsesesew",
        "nenewswnwewswnenesenwnesewesw",
        "eneswnwswnwsenenwnwnwwseeswneewsenese",
        "neswnwewnwnwseenwseesewsenwsweewe",
        "wseweeenwnesenwwwswnew",
    }, 10)]
    public void Part1_Example_ReturnsCorrectAnswer(string[] input, int expected)
    {
        Day24.Solve1(input).Should().Be(expected);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day24.Part1().Should().Be(0);
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day24.Part2().Should().Be(0);
    }
}
