using AdventOfCode.TestHelpers;

using FluentAssertions;

namespace AdventOfCode._2024.Tests;

public class Day3Tests
{
    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day3/example.txt");
        Day3.Solve(input).Should().Be(161);
    }

    [Fact]
    public async Task Solution()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day3/test.txt");
        Day3.Solve(input).Should().Be(178794710);
    }
}
