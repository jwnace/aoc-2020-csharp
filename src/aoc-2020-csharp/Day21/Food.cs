namespace aoc_2020_csharp.Day21;

public record Food(string[] Ingredients, string[] Allergens)
{
    public static Food Parse(string line)
    {
        var parts = line.Split(" (contains ");
        var ingredients = parts[0].Split(' ');
        var allergens = parts[1][..^1].Split(", ");
        return new Food(ingredients, allergens);
    }
}
