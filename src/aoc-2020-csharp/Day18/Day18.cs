namespace aoc_2020_csharp.Day18;

public static class Day18
{
    private static readonly string[] Input = File.ReadAllLines("Day18/day18.txt");

    public static long Part1() => Input.Sum(line => Solve1(line).Result);

    public static long Part2() => Input.Sum(Solve2);

    public static (long Result, int Index) Solve1(string line, int index = 0)
    {
        var result = 0L;
        var a = 0L;
        var b = 0L;
        var operation = Operation.None;
        var i = 0;

        for (i = index; i < line.Length; i++)
        {
            switch (line[i])
            {
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    if (a == 0)
                    {
                        a = long.Parse(line[i].ToString());
                    }
                    else if (b == 0)
                    {
                        b = long.Parse(line[i].ToString());

                        if (operation == Operation.Addition)
                        {
                            result = a + b;
                        }
                        else if (operation == Operation.Multiplication)
                        {
                            result = a * b;
                        }

                        a = result;
                        b = 0;
                        operation = Operation.None;
                    }

                    break;
                case ' ':
                    break;
                case '+':
                    if (operation == Operation.None)
                    {
                        operation = Operation.Addition;
                    }

                    break;
                case '*':
                    if (operation == Operation.None)
                    {
                        operation = Operation.Multiplication;
                    }

                    break;
                case '(':
                    if (a == 0)
                    {
                        var temp = Solve1(line, i + 1);
                        a = temp.Result;
                        i = temp.Index;
                    }
                    else if (b == 0)
                    {
                        var temp = Solve1(line, i + 1);
                        b = temp.Result;
                        i = temp.Index;

                        if (operation == Operation.Addition)
                        {
                            result = a + b;
                        }
                        else if (operation == Operation.Multiplication)
                        {
                            result = a * b;
                        }

                        a = result;
                        b = 0;
                        operation = Operation.None;
                    }

                    break;
                case ')':
                    if (result == 0)
                    {
                        if (a > 0)
                        {
                            return (a, i);
                        }
                        else if (b > 0)
                        {
                            return (b, i);
                        }
                    }

                    return (result, i);
                default:
                    throw new Exception($"Unexpected character in input: {line[i]}");
            }
        }

        if (result == 0)
        {
            if (a > 0)
            {
                return (a, i);
            }
            else if (b > 0)
            {
                return (b, i);
            }
        }

        return (result, i);
    }

    public static long Solve2(string line)
    {
        while (line.Contains('('))
        {
            var iEnd = line.IndexOf(')');
            var iStart = line.Substring(0, iEnd).LastIndexOf('(');
            var subproblem = line.Substring(iStart + 1, iEnd - iStart - 1);
            var temp = Solve2(subproblem);
            line = line.Substring(0, iStart) + temp.ToString() + line.Substring(iEnd + 1);
        }

        var list = line.Split(' ').ToList();

        while (list.Contains("+"))
        {
            var i = list.IndexOf("+");
            var a = long.Parse(list[i - 1]);
            var b = long.Parse(list[i + 1]);
            var c = a + b;

            list[i] = c.ToString();
            list.RemoveAt(i + 1);
            list.RemoveAt(i - 1);
        }

        while (list.Contains("*"))
        {
            var i = list.IndexOf("*");
            var a = long.Parse(list[i - 1]);
            var b = long.Parse(list[i + 1]);
            var c = a * b;

            list[i] = c.ToString();
            list.RemoveAt(i + 1);
            list.RemoveAt(i - 1);
        }

        if (list.Count > 1)
        {
            throw new Exception("Something went very seriously wrong...");
        }

        return long.Parse(list[0]);
    }
}
