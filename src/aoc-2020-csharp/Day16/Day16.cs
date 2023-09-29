namespace aoc_2020_csharp.Day16;

public static class Day16
{
    private static readonly string Input = File.ReadAllText("Day16/day16.txt").Trim();

    public static int Part1() => Solve1(Input);

    public static long Part2() => Solve2(Input);

    public static int Solve1(string input)
    {
        var sections = GetSections(input);
        var rules = GetRules(sections);
        var nearbyTickets = GetNearbyTickets(sections);
        var invalidValues = GetInvalidValues(nearbyTickets, rules);

        return invalidValues.Sum();
    }

    private static long Solve2(string input)
    {
        var sections = GetSections(input);
        var rules = GetRules(sections);
        var nearbyTickets = GetNearbyTickets(sections);
        var myTicket = GetMyTicket(sections);
        var validTickets = GetValidTickets(nearbyTickets, rules);
        var validTicketsSplit = validTickets.Select(ticket => ticket.Split(",").Select(int.Parse).ToArray()).ToArray();
        var possibleFields = GetPossibleFields(myTicket, rules, validTicketsSplit);
        var fieldNames = new string[myTicket.Length];

        while (possibleFields.Any(fields => fields.Count > 1))
        {
            var singleFields = possibleFields.Where(fields => fields.Count == 1)
                .SelectMany(fields => fields)
                .ToHashSet();

            foreach (var fields in possibleFields.Where(fields => fields.Count > 1))
            {
                fields.ExceptWith(singleFields);
            }
        }

        for (var i = 0; i < possibleFields.Length; i++)
        {
            fieldNames[i] = possibleFields[i].Single();
        }

        return fieldNames.Select((name, index) => (name, index))
            .Where(tuple => tuple.name.StartsWith("departure"))
            .Select(tuple => myTicket[tuple.index])
            .Aggregate(1L, (acc, value) => acc * value);
    }

    private static int[] GetInvalidValues(IEnumerable<string> nearbyTickets, (string, HashSet<int>)[] rules) =>
        nearbyTickets.SelectMany(ticket => ticket.Split(",").Select(int.Parse))
            .Where(value => rules.All(rule => !rule.Item2.Contains(value)))
            .ToArray();

    private static HashSet<string>[] GetPossibleFields(int[] myTicket, (string, HashSet<int>)[] rules,
        int[][] validTicketsSplit) =>
        Enumerable.Range(0, myTicket.Length)
            .Select(index => rules.Where(rule => validTicketsSplit.All(ticket => rule.Item2.Contains(ticket[index])))
                .Select(rule => rule.Item1).ToHashSet()).ToArray();

    private static string[] GetValidTickets(IEnumerable<string> nearbyTickets, (string, HashSet<int>)[] rules) =>
        nearbyTickets.Where(ticket => ticket.Split(",").Select(int.Parse)
            .All(value => rules.Any(rule => rule.Item2.Contains(value)))).ToArray();

    private static int[] GetMyTicket(string[] sections) =>
        sections[1].Split(Environment.NewLine).Skip(1).First().Split(",").Select(int.Parse).ToArray();

    private static IEnumerable<string> GetNearbyTickets(string[] sections) =>
        sections[2].Split(Environment.NewLine).Skip(1);

    private static (string, HashSet<int>)[] GetRules(string[] sections) =>
        sections[0].Split(Environment.NewLine)
            .Select(SplitOnColonSpace)
            .Select(GetFieldNameAndRanges)
            .Select(SplitRanges)
            .Select(ConvertRangesToTuples)
            .Select(FlattenRanges)
            .Select(ConvertRangesToHashSet)
            .ToArray();

    private static string[] GetSections(string input) => input.Split($"{Environment.NewLine}{Environment.NewLine}");

    private static (string, HashSet<int>) ConvertRangesToHashSet((string, int[]) parts) =>
        (parts.Item1, parts.Item2.ToHashSet());

    private static (string, int[]) FlattenRanges((string, (int, int)[]) parts) =>
        (parts.Item1, parts.Item2.Select(range => Enumerable.Range(range.Item1, range.Item2 - range.Item1 + 1))
            .SelectMany(x => x)
            .ToArray());

    private static (string, (int, int)[]) ConvertRangesToTuples((string, IEnumerable<int[]>) parts) =>
        (parts.Item1, parts.Item2.Select(range => (range[0], range[1])).ToArray());

    private static (string, IEnumerable<int[]>) SplitRanges((string, string[]) parts) =>
        (parts.Item1, parts.Item2.Select(range => range.Split("-").Select(int.Parse).ToArray()));

    private static (string, string[]) GetFieldNameAndRanges(string[] parts) => (parts[0], parts[1].Split(" or "));

    private static string[] SplitOnColonSpace(string line) => line.Split(": ");
}
