namespace aoc_2020_csharp.Day21;

public static class Day21
{
    private static readonly string[] Input = File.ReadAllLines("Day21/day21.txt");

    public static int Part1() => Solve1(Input);

    public static string Part2() => Solve2(Input);

    public static int Solve1(string[] input)
    {
        var foods = GetFoods(input);
        var allergenToIngredients = MapAllergensToIngredients(foods);
        var allIngredients = GetAllIngredients(foods);
        var ingredientsWithAllergens = GetIngredientsWithAllergens(allergenToIngredients);
        var ingredientsWithoutAllergens = GetIngredientsWithoutAllergens(allIngredients, ingredientsWithAllergens);

        return foods.Sum(food => food.Ingredients.Count(ingredient => ingredientsWithoutAllergens.Contains(ingredient)));
    }

    public static string Solve2(string[] input)
    {
        var foods = GetFoods(input);
        var allergenToIngredients = MapAllergensToIngredients(foods);
        var allergenToIngredient = new Dictionary<string, string>();

        while (allergenToIngredients.Any())
        {
            var allergen = allergenToIngredients.First(a => a.Value.Count == 1).Key;
            var ingredient = allergenToIngredients[allergen].First();

            allergenToIngredient[allergen] = ingredient;
            allergenToIngredients.Remove(allergen);

            foreach (var ingredients in allergenToIngredients.Values)
            {
                ingredients.Remove(ingredient);
            }
        }

        return string.Join(",", allergenToIngredient.OrderBy(a => a.Key).Select(a => a.Value));
    }

    private static List<Food> GetFoods(IEnumerable<string> input) => input.Select(Food.Parse).ToList();

    private static Dictionary<string, HashSet<string>> MapAllergensToIngredients(List<Food> foods)
    {
        var allergenToIngredients = new Dictionary<string, HashSet<string>>();

        foreach (var food in foods)
        {
            foreach (var allergen in food.Allergens)
            {
                if (!allergenToIngredients.ContainsKey(allergen))
                {
                    allergenToIngredients[allergen] = new HashSet<string>(food.Ingredients);
                }
                else
                {
                    allergenToIngredients[allergen].IntersectWith(food.Ingredients);
                }
            }
        }

        return allergenToIngredients;
    }

    private static HashSet<string> GetAllIngredients(IEnumerable<Food> foods) =>
        foods.SelectMany(f => f.Ingredients).ToHashSet();

    private static HashSet<string> GetIngredientsWithAllergens(
        Dictionary<string, HashSet<string>> allergenToIngredients) =>
        allergenToIngredients.Values.SelectMany(i => i).ToHashSet();

    private static HashSet<string> GetIngredientsWithoutAllergens(
        HashSet<string> allIngredients,
        IEnumerable<string> ingredientsWithAllergens) =>
        allIngredients.Except(ingredientsWithAllergens).ToHashSet();
}
