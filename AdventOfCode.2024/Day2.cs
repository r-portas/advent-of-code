using AdventOfCode.TestHelpers;

using FluentAssertions;

namespace AdventOfCode._2024;

public class Day2
{
    public static int Solve(int[][] input)
    {
        int safeReports = 0;

        foreach (var report in input)
        {
            var isSafe = true;
            var increasing = report[1] > report[0];
            for (int i = 1; i < report.Length; i++)
            {
                if (!IsSafe(increasing, report[i - 1], report[i]))
                {
                    isSafe = false;
                    break;
                }
            }

            if (isSafe)
            {
                safeReports++;
            }
        }

        return safeReports;
    }

    private static bool IsSafe(bool increasing, int last, int current)
    {
        var diff = last - current;

        if (increasing)
        {
            diff *= -1;
        }

        return diff >= 1 && diff <= 3;
    }
    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day2/example.txt");
        Solve(input).Should().Be(2);
    }

    [Fact]
    public async Task Solution()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day2/test.txt");
        Solve(input).Should().Be(213);
    }
}
