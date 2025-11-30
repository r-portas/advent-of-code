using System.Text.RegularExpressions;

using AdventOfCode.TestHelpers;

using FluentAssertions;

namespace AdventOfCode._2024;

public class Day3
{
    private const string Pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

    public static int Solve(string[] input)
    {
        int sum = 0;
        foreach (var line in input)
        {
            foreach (Match match in Regex.Matches(line, Pattern))
            {
                var a = int.Parse(match.Groups[1].Value);
                var b = int.Parse(match.Groups[2].Value);
                sum += a * b;
            }
        }

        return sum;
    }

    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day3/example.txt");
        Solve(input).Should().Be(161);
    }

    [Fact]
    public async Task Solution()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day3/test.txt");
        Solve(input).Should().Be(178794710);
    }
}
