namespace aoc_2020_csharp.Day06;

public record Group(IEnumerable<Person> People)
{
    public static Group Parse(string input) => new(input.Split(Environment.NewLine).Select(Person.Parse));

    public int CountDistinctAnswers() => People.SelectMany(p => p.Answers).Distinct().Count();

    public int CountUnanimousAnswers() =>
        People.SelectMany(p => p.Answers).GroupBy(a => a).Count(g => g.Count() == People.Count());
}
