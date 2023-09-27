namespace aoc_2020_csharp.Day06;

public static class Day06
{
    private static readonly string Input = File.ReadAllText("Day06/day06.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string input) => GetGroups(input).Sum(g => g.CountDistinctAnswers());

    public static int Solve2(string input) => GetGroups(input).Sum(g => g.CountUnanimousAnswers());

    private static IEnumerable<Group> GetGroups(string input) =>
        input.Split($"{Environment.NewLine}{Environment.NewLine}").Select(Group.Parse);

    private record Group(IEnumerable<Person> People)
    {
        public static Group Parse(string input) => new(input.Split(Environment.NewLine).Select(Person.Parse));

        public int CountDistinctAnswers() => People.SelectMany(p => p.Answers).Distinct().Count();

        public int CountUnanimousAnswers() =>
            People.SelectMany(p => p.Answers).GroupBy(a => a).Count(g => g.Count() == People.Count());
    }

    private record Person(IEnumerable<Answer> Answers)
    {
        public static Person Parse(string input) => new(input.Select(Answer.Parse));
    }

    private record Answer(char Value)
    {
        public static Answer Parse(char value) => new(value);
    }
}
