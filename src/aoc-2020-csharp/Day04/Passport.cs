using System.Text.RegularExpressions;

namespace aoc_2020_csharp.Day04;

public record Passport(
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

    public bool HasAllRequiredFields() =>
        BirthYear != null &&
        IssueYear != null &&
        ExpirationYear != null &&
        Height != null &&
        HairColor != null &&
        EyeColor != null &&
        PassportId != null;

    public bool IsValid() =>
        HasAllRequiredFields() &&
        HasValidBirthYear() &&
        HasValidIssueYear() &&
        HasValidExpirationYear() &&
        HasValidHeight() &&
        HasValidHairColor() &&
        HasValidEyeColor() &&
        HasValidPassportId();

    private bool HasValidBirthYear() =>
        int.TryParse(BirthYear, out var birthYear) && birthYear is >= 1920 and <= 2002;

    private bool HasValidIssueYear() =>
        int.TryParse(IssueYear, out var issueYear) && issueYear is >= 2010 and <= 2020;

    private bool HasValidExpirationYear() =>
        int.TryParse(ExpirationYear, out var expirationYear) && expirationYear is >= 2020 and <= 2030;

    private bool HasValidHeight() =>
        Height![^2..] switch
        {
            "cm" => int.TryParse(Height[..^2], out var heightCm) && heightCm is >= 150 and <= 193,
            "in" => int.TryParse(Height[..^2], out var heightIn) && heightIn is >= 59 and <= 76,
            _ => false
        };

    private bool HasValidHairColor() =>
        Regex.IsMatch(HairColor!, "^#[0-9a-f]{6}$");

    private bool HasValidEyeColor() =>
        Regex.IsMatch(EyeColor!, "^(amb|blu|brn|gry|grn|hzl|oth)$");

    private bool HasValidPassportId() =>
        Regex.IsMatch(PassportId!, "^[0-9]{9}$");
}
