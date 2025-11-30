using System.Text;
using System.IO;
namespace AdventOfCode.TestHelpers;

/// <summary>
/// Provides utility methods for reading test data files.
/// </summary>
public static class TestFile
{
    /// <summary>
    /// Reads all lines from a text file asynchronously.
    /// </summary>
    /// <param name="path">The path to the text file to read.</param>
    /// <returns>An array of strings representing each line in the file.</returns>
    public async static Task<string[]> ReadAllText(string path)
    {
        return await File.ReadAllLinesAsync(path, Encoding.UTF8);
    }

    /// <summary>
    /// Reads a 2D grid of integers from a text file asynchronously.
    /// </summary>
    /// <remarks>
    /// Each line in the file should contain one or more space-separated integers.
    /// Empty or whitespace-only lines are skipped.
    /// </remarks>
    /// <param name="path">The path to the text file to read.</param>
    /// <returns>A jagged 2D array of integers parsed from the file.</returns>
    public async static Task<int[][]> ReadAllIntGrid(string path)
    {
        var lines = await ReadAllText(path);
        return lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .ToArray();
    }
}