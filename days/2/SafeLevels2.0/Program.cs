using System.Collections.Generic;

public class Program 
{
    public static void Main()
    {
        var safeLevels = 0;
        using (var reader = new StreamReader("input.txt"))
        {
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                var lineList = line.Split(" ");
                var report = new List<int>();

                foreach (var item in lineList)
                {
                    var currentNumber = int.Parse(item);
                    report.Add(currentNumber);
                }
                safeLevels += BruteForce(report);
            }
        }

        Console.WriteLine(safeLevels);
    }

    public static int BruteForce(List<int> report)
    {
        if (report.Count == 0)
        {
            return 0;
        }

        var thisStupidReportIsSafe = IsThisStupidReportSafe(report);
        for (int i = 0; i < report.Count; i++)
        {
            if (thisStupidReportIsSafe)
            {
                return 1;
            }
            thisStupidReportIsSafe = IsThisStupidReportSafe(report.Where((value, index) => index != i));
        }

        return thisStupidReportIsSafe ? 1 : 0;
    }

    public static bool IsThisStupidReportSafe(IEnumerable<int> report)
    {
        var prevNumber = -1;
        var isReportSafe = true;
        var isReportIncreasing = true;

        foreach (var currentNumber in report)
        {
            if (isReportSafe == false)
            {
                break;
            }

            if (prevNumber == -1)
            {
                prevNumber = currentNumber;
                continue;
            }
            isReportSafe = isReportSafe && IsLevelDifferenceSafe(prevNumber, currentNumber);
            isReportIncreasing = IsLevelIncreasing(prevNumber, currentNumber);
            prevNumber = currentNumber;
        }

        if (isReportSafe == false)
        {
            return false;
        }

        if (isReportIncreasing)
        {
            return DoAllLevelsIncrease(report);
        }
        else
        {
            return DoAllLevelsDecrease(report);
        }
    }

    public static bool IsLevelDifferenceSafe(int prevNumber, int currentNumber)
    {
        var difference = Math.Abs(prevNumber - currentNumber);
        if (difference == 0 || difference > 3)
        {
            return false;
        }

        return true;
    }

    public static bool IsLevelIncreasing(int prevNumber, int currentNumber)
    {
        return prevNumber < currentNumber;
    }

    public static bool DoAllLevelsIncrease(IEnumerable<int> report)
    {
        var prevNumber = -1;
        foreach (var currentNumber in report)
        {
            if (prevNumber == -1)
            {
                prevNumber = currentNumber;
                continue;
            }

            if (prevNumber >= currentNumber)
            {
                return false;
            }

            prevNumber = currentNumber;
        }

        return true;
    }

    public static bool DoAllLevelsDecrease(IEnumerable<int> report)
    {
        var prevNumber = -1;
        foreach (var currentNumber in report)
        {
            if (prevNumber == -1)
            {
                prevNumber = currentNumber;
                continue;
            }

            if (prevNumber <= currentNumber)
            {
                return false;
            }

            prevNumber = currentNumber;
        }

        return true;
    }
}