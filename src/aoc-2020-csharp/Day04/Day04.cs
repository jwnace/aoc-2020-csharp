namespace aoc_2020_csharp.Day04;

public static class Day04
{
    private static readonly string Input = File.ReadAllText("Day04/day04.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input) =>
        input.Split($"{Environment.NewLine + Environment.NewLine}").Select(Passport.Parse).Count(p => p.IsValid());

    public static int Solve2(string input)
    {
        throw new NotImplementedException();
    }

    private record Passport(
        string? BirthYear,
        string? IssueYear,
        string? ExpirationYear,
        string? Height,
        string? HairColor,
        string? EyeColor,
        string? PassportId,
        string? CountryId)
    {
        public static Passport Parse(string input)
        {
            var dict = new Dictionary<string, string>();
            var pairs = input.Split(null);

            foreach (var pair in pairs)
            {
                var parts = pair.Split(":");
                var (key, value) = (parts[0], parts[1]);

                dict[key] = value;
            }

            return new Passport(
                dict.GetValueOrDefault("byr"),
                dict.GetValueOrDefault("iyr"),
                dict.GetValueOrDefault("eyr"),
                dict.GetValueOrDefault("hgt"),
                dict.GetValueOrDefault("hcl"),
                dict.GetValueOrDefault("ecl"),
                dict.GetValueOrDefault("pid"),
                dict.GetValueOrDefault("cid"));
        }

        public bool IsValid()
        {
            return BirthYear != null &&
                   IssueYear != null &&
                   ExpirationYear != null &&
                   Height != null &&
                   HairColor != null &&
                   EyeColor != null &&
                   PassportId != null;
        }
    }
}
