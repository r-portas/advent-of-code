using AdventOfCode.TestHelpers;

using FluentAssertions;

namespace AdventOfCode._2024.Tests;

public class Day1Tests
{
    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day1/example.txt");
        Day1.Solve(input).Should().Be(11);
    }

    [Fact]
    public async Task Solution()
    {
        var input = await TestFile.ReadAllIntGrid("./InputFiles/Day1/test.txt");
        Day1.Solve(input).Should().Be(2742123);
    }
}
