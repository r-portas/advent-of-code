using Shouldly;

namespace AdventOfCode._2025;

public class DayTemplate
{
    int Solve()
    {
        return 1;
    }

    [Fact]
    public async Task Example()
    {
        Solve().ShouldBe(1);
    }
}