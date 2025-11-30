using AdventOfCode.TestHelpers;

using FluentAssertions;

namespace AdventOfCode._2024;

public class Day1
{
    public static int Solve(int[][] input)
    {
        List<int> first = new();
        List<int> second = new();
        foreach (var row in input)
        {
            first.Add(row[0]);
            second.Add(row[1]);
        }

        first.Sort();
        second.Sort();

        int totalDistance = 0;
        for (int i = 0; i < first.Count; i++)
        {
            totalDistance += Math.Abs(first[i] - second[i]);
        }
        return totalDistance;
    }

    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day1/example.txt");
        Solve(input).Should().Be(11);
    }

    [Fact]
    public async Task Solution()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day1/test.txt");
        Solve(input).Should().Be(2742123);
    }
}
