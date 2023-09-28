namespace aoc_2020_csharp.Day08;

public static class Day08
{
    private static readonly string[] Input = File.ReadAllLines("Day08/day08.txt");

    public static int Part1() => Solve1(Input);

    public static int Part2() => Solve2(Input);

    public static int Solve1(string[] input) =>
        RunProgram(input, out var accumulator) ? throw new Exception("Program halted") : accumulator;

    public static int Solve2(string[] input)
    {
        var indexToModify = 0;

        while (true)
        {
            var program = ModifyProgram(input, ref indexToModify);
            var halt = RunProgram(program, out var accumulator);

            if (halt)
            {
                return accumulator;
            }

            indexToModify++;
        }
    }

    private static string[] ModifyProgram(string[] input, ref int indexToModify)
    {
        var program = input.ToArray();

        switch (program[indexToModify][..3])
        {
            case "nop":
                program[indexToModify] = program[indexToModify].Replace("nop", "jmp");
                break;
            case "jmp":
                program[indexToModify] = program[indexToModify].Replace("jmp", "nop");
                break;
            default:
                indexToModify++;
                break;
        }

        return program;
    }

    private static bool RunProgram(string[] input, out int accumulator)
    {
        accumulator = 0;
        var visited = new HashSet<int>();

        for (var i = 0; i < input.Length; i++)
        {
            if (visited.Contains(i))
            {
                return false;
            }

            visited.Add(i);

            var instruction = input[i];
            var parts = instruction.Split(" ");
            var (op, arg) = (parts[0], int.Parse(parts[1]));

            switch (op)
            {
                case "nop":
                    break;
                case "acc":
                    accumulator += arg;
                    break;
                case "jmp":
                    i += arg - 1;
                    break;
                default:
                    throw new Exception($"Unknown instruction: {instruction}");
            }
        }

        return true;
    }
}
