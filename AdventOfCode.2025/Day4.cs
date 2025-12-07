using AdventOfCode.TestHelpers;

using Shouldly;

namespace AdventOfCode._2025;

class ForkliftArea
{
    private bool[,] _grid;

    public ForkliftArea(string[] input)
    {
        _grid = new bool[input[0].Length, input.Length];

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                _grid[x, y] = input[y][x] == '@';
            }
        }
    }

    public bool ForkliftCanAccess(int x, int y)
    {
        if (_grid[x, y] == false) return false;

        int count = 0;
        for (int dy = Math.Max(0, y - 1); dy <= Math.Min(_grid.GetLength(1) - 1, y + 1); dy++)
        {
            for (int dx = Math.Max(0, x - 1); dx <= Math.Min(_grid.GetLength(0) - 1, x + 1); dx++)
            {
                if (dx == x && dy == y) continue;
                if (_grid[dx, dy]) count++;
            }
        }

        return count < 4;
    }

    public int CountAccessiblePositions()
    {
        int accessibleCount = 0;
        for (int y = 0; y < _grid.GetLength(1); y++)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                if (ForkliftCanAccess(x, y))
                {
                    accessibleCount++;
                }
            }
        }
        return accessibleCount;
    }

    // For Part 2
    public void RemoveAccessiblePositions()
    {
        bool[,] newGrid = new bool[_grid.GetLength(0), _grid.GetLength(1)];
        for (int y = 0; y < _grid.GetLength(1); y++)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                if (_grid[x, y] == true && !ForkliftCanAccess(x, y))
                {
                    newGrid[x, y] = true;
                }
            }
        }
        _grid = newGrid;
    }

    public int CountAndRemove()
    {
        int count;
        int totalCount = 0;
        do
        {
            count = CountAccessiblePositions();
            totalCount += count;
            RemoveAccessiblePositions();
        } while (count > 0);

        return totalCount;
    }

    public void Debug()
    {
        for (int y = 0; y < _grid.GetLength(1); y++)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                bool canAccess = ForkliftCanAccess(x, y);
                if (canAccess)
                {
                    Console.Write("x");
                }
                else if (_grid[x, y])
                {
                    Console.Write("@");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }
}

public class Day4
{

    [Fact]
    public async Task ExamplePart1()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day4/example.txt");
        ForkliftArea area = new(input);
        area.CountAccessiblePositions().ShouldBe(13);
    }

    [Fact]
    public async Task ExamplePart2()
    {
        var input = await TestFile.ReadAllText("./InputFiles/Day4/example.txt");
        ForkliftArea area = new(input);
        area.CountAndRemove().ShouldBe(43);
    }
}