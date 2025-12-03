using AdventOfCode.TestHelpers;

using Shouldly;

namespace AdventOfCode._2025;

public class Day2
{
    double SolvePart1(string input)
    {
        double sum = 0;
        string[] ranges = input.Split(",");
        foreach (var range in ranges)
        {
            var bounds = range.Split("-").Select(double.Parse).ToArray();
            for (double num = bounds[0]; num <= bounds[1]; num++)
            {
                var numberStr = num.ToString();
                int length = numberStr.Length;

                if (length % 2 != 0)
                {
                    // Not divisible by 2
                    continue;
                }

                var midpoint = length / 2;
                var parts = new List<string>
                {
                    numberStr.Substring(0, midpoint),
                    numberStr.Substring(midpoint, midpoint)
                };

                if (parts.Distinct().Count() == 1)
                {
                    sum += num;
                }
            }
        }

        return sum;
    }

    double SolvePart2(string input)
    {
        double sum = 0;
        string[] ranges = input.Split(",");
        foreach (var range in ranges)
        {
            var bounds = range.Split("-").Select(double.Parse).ToArray();
            for (double num = bounds[0]; num <= bounds[1]; num++)
            {
                bool foundInvalid = false;
                var numberStr = num.ToString();
                int length = numberStr.Length;
                bool isEven = length % 2 == 0;

                for (int splits = isEven ? 2 : 3; splits <= length; splits++)
                {
                    // Check if we can split the number into equal parts
                    if (length % splits != 0)
                    {
                        continue;
                    }
                    int chunkSize = length / splits;

                    // Split the number into chunks
                    var parts = Enumerable.Range(0, length / chunkSize)
                        .Select(i => numberStr.Substring(i * chunkSize, chunkSize)).ToList();

                    // Check if all parts are the same
                    if (parts.Distinct().Count() == 1)
                    {
                        foundInvalid = true;
                    }
                }
                if (foundInvalid)
                {
                    sum += num;
                }
            }
        }

        return sum;
    }


    [Fact]
    public async Task ExamplePart1()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day2/example.txt");
        SolvePart1(input[0]).ShouldBe(1227775554);
    }

    [Fact]
    public async Task ExamplePart2()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day2/example.txt");
        SolvePart2(input[0]).ShouldBe(4174379265);
    }
}
