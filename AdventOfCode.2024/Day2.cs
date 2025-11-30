namespace AdventOfCode._2024;

public class Day2
{
    public static int Solve(int[][] input)
    {
        int safeReports = 0;

        foreach (var report in input)
        {
            var isSafe = true;
            var increasing = report[1] > report[0];
            for (int i = 1; i < report.Length; i++)
            {
                if (!IsSafe(increasing, report[i - 1], report[i]))
                {
                    isSafe = false;
                    break;
                }
            }

            if (isSafe)
            {
                safeReports++;
            }
        }

        return safeReports;
    }

    private static bool IsSafe(bool increasing, int last, int current)
    {
        var diff = last - current;

        if (increasing)
        {
            diff *= -1;
        }

        return diff >= 1 && diff <= 3;
    }
}
