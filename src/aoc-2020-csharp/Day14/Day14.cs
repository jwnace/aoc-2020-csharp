namespace aoc_2020_csharp.Day14;

public static class Day14
{
    private static readonly string[] Input = File.ReadAllLines("Day14/day14.txt");

    public static long Part1() => Solve1(Input);

    public static long Part2() => Solve2(Input);

    public static long Solve1(string[] input)
    {
        var memory = new Dictionary<long, long>();
        var mask = "";

        foreach (var line in input)
        {
            var parts = line.Split(" = ");
            var (left, right) = (parts[0], parts[1]);

            if (left == "mask")
            {
                mask = right;
            }
            else
            {
                var (address, value) = (int.Parse(left[4..^1]), int.Parse(right));
                var binaryValue = Convert.ToString(value, 2).PadLeft(mask.Length, '0').ToCharArray();

                for (var i = 0; i < mask.Length; i++)
                {
                    if (mask[i] == 'X')
                    {
                        continue;
                    }

                    binaryValue[i] = mask[i];
                }

                memory[address] = Convert.ToInt64(new string(binaryValue), 2);
            }
        }

        return memory.Sum(x => x.Value);
    }

    public static long Solve2(string[] input)
    {
        var memory = new Dictionary<long, long>();
        var mask = "";

        foreach (var line in input)
        {
            var parts = line.Split(" = ");
            var (left, right) = (parts[0], parts[1]);

            if (left == "mask")
            {
                mask = right;
            }
            else
            {
                var (address, value) = (int.Parse(left[4..^1]), int.Parse(right));
                var binaryAddress = Convert.ToString(address, 2).PadLeft(mask.Length, '0').ToCharArray();

                for (var i = 0; i < mask.Length; i++)
                {
                    if (mask[i] == '0')
                    {
                        continue;
                    }

                    binaryAddress[i] = mask[i];
                }

                var addressList = BuildAddressList(binaryAddress).Select(x => Convert.ToInt64(x, 2));

                foreach (var a in addressList)
                {
                    memory[a] = value;
                }
            }
        }

        return memory.Sum(x => x.Value);
    }

    private static List<string> BuildAddressList(char[] address)
    {
        if (!address.Contains('X'))
        {
            return new List<string> { new(address) };
        }

        var result = new List<string>();

        for (var i = 0; i < address.Length; i++)
        {
            if (address[i] == 'X')
            {
                var a1 = address.ToArray();
                var a2 = address.ToArray();

                a1[i] = '0';
                a2[i] = '1';

                result.AddRange(BuildAddressList(a1));
                result.AddRange(BuildAddressList(a2));

                break;
            }
        }

        return result;
    }
}
