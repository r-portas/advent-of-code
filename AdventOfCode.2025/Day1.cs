using AdventOfCode.TestHelpers;

using Shouldly;

[assembly: CaptureConsole]

namespace AdventOfCode._2025;

class SafeDial
{
    public int Position { get; private set; } = 50;
    // For Part 1
    public int LandedOnZeroCount { get; private set; } = 0;
    // For Part 2
    public int PassedZeroCount { get; private set; } = 0;

    public void Rotate(string rotation)
    {
        char dir = rotation[0];
        int distance = int.Parse(rotation[1..]);

        if (dir == 'L')
        {
            Position -= distance;
            while (Position < 0)
            {
                Position += 100;
                PassedZeroCount++;
            }
        }
        else
        {
            Position += distance;
            while (Position > 99)
            {
                Position -= 100;
                PassedZeroCount++;
            }
        }

        if (Position == 0)
        {
            LandedOnZeroCount++;
            PassedZeroCount++;
        }
    }
}

public class Day1
{
    int Solve(string[] input, bool part2 = false)
    {
        SafeDial dial = new();
        foreach (var line in input)
        {
            dial.Rotate(line);
        }
        return part2 ? dial.PassedZeroCount : dial.LandedOnZeroCount;
    }

    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day1/example.txt");
        Solve(input).ShouldBe(3);
    }

    [Fact]
    public async Task ExamplePart2()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day1/actual.txt");
        Solve(input, true).ShouldBe(6);
    }

    [Theory]
    [InlineData(new[] { "R1000" }, 10)]
    [InlineData(new[] { "L50", "R50" }, 1)]
    [InlineData(new[] { "L50", "L50" }, 1)]
    [InlineData(new[] { "L150", "L50" }, 2)]
    [InlineData(new[] { "L150", "R50" }, 2)]
    [InlineData(new[] { "L50", "R101" }, 2)]
    public async Task TestScenarios(string[] rotations, int expected)
    {
        Solve(rotations, true).ShouldBe(expected);
    }
}
