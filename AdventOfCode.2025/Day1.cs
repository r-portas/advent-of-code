using AdventOfCode.TestHelpers;

using FluentAssertions;

namespace AdventOfCode._2025;

public class Day1
{
    int Solve(string[] input, bool part2 = false)
    {
        int count = 0;
        int position = 50;
        foreach (var line in input)
        {
            var isLeft = line[0] == 'L';
            var distance = int.Parse(line[1..]);
            position += isLeft ? -distance : distance;

            while (position > 99)
            {
                if (part2)
                {
                    count++;
                }
                position -= 100;
            }

            while (position < 0)
            {
                if (part2)
                {
                    count++;
                }
                position += 100;
            }

            if (position == 0 && !part2)
            {
                count++;
            }
        }
        return count;
    }

    [Fact]
    public async Task Example()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day1/example.txt");
        Solve(input).Should().Be(3);
    }

    [Fact]
    public async Task ExamplePart2()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day1/example.txt");
        Solve(input, true).Should().Be(6);
    }

    [Fact]
    public async Task TestRotate()
    {
        Solve(["R1000"], true).Should().Be(10);
    }
}
