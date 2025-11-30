using AdventOfCode.TestHelpers;

using FluentAssertions;

namespace AdventOfCode._2024.Tests;

public class Day2Tests
{
    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day2/example.txt");
        Day2.Solve(input).Should().Be(2);
    }

    [Fact]
    public async Task Solution()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day2/test.txt");
        Day2.Solve(input).Should().Be(213);
    }
}
