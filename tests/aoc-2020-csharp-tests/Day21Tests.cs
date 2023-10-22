using aoc_2020_csharp.Day21;

namespace aoc_2020_csharp_tests;

public class Day21Tests
{
    [Test]
    public void Part1_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
            "trh fvjkl sbzzf mxmxvkd (contains dairy)",
            "sqjhc fvjkl (contains soy)",
            "sqjhc mxmxvkd sbzzf (contains fish)",
        };

        Day21.Solve1(input).Should().Be(5);
    }

    [Test]
    public void Part1_ReturnsCorrectAnswer()
    {
        Day21.Part1().Should().Be(2282);
    }

    [Test]
    public void Part2_Example_ReturnsCorrectAnswer()
    {
        var input = new[]
        {
            "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)",
            "trh fvjkl sbzzf mxmxvkd (contains dairy)",
            "sqjhc fvjkl (contains soy)",
            "sqjhc mxmxvkd sbzzf (contains fish)",
        };

        Day21.Solve2(input).Should().Be("mxmxvkd,sqjhc,fvjkl");
    }

    [Test]
    public void Part2_ReturnsCorrectAnswer()
    {
        Day21.Part2().Should().Be("vrzkz,zjsh,hphcb,mbdksj,vzzxl,ctmzsr,rkzqs,zmhnj");
    }
}
