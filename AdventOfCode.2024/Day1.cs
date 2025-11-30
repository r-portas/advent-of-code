namespace AdventOfCode._2024;

public class Day1
{
    public static int Solve(int[][] input)
    {
        List<int> first = new();
        List<int> second = new();
        foreach (var row in input)
        {
            first.Add(row[0]);
            second.Add(row[1]);
        }

        first.Sort();
        second.Sort();

        int totalDistance = 0;
        for (int i = 0; i < first.Count; i++)
        {
            totalDistance += Math.Abs(first[i] - second[i]);
        }
        return totalDistance;
    }
}
