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
                var prevNumber = -1;
                var isReportSafe = true;
                var report = new List<int>();
                var isReportIncreasing = true;
                
                foreach (var item in lineList)
                {
                    if(isReportSafe == false)
                    {
                        break;
                    }
                    
                    var currentNumber = int.Parse(item);
                    report.Add(currentNumber);
                    
                    if (prevNumber == -1)
                    {
                        prevNumber = currentNumber;
                        continue;
                    }
                    isReportSafe = isReportSafe && IsLevelDifferenceSafe(prevNumber, currentNumber);
                    isReportIncreasing = IsLevelIncreasing(prevNumber, currentNumber); 
                    prevNumber = currentNumber;
                }

                if(isReportSafe == false)
                {
                    continue;
                }

                if(isReportIncreasing)
                {
                   isReportSafe = DoAllLevelsIncrease(report);
                }
                else
                {
                    isReportSafe = DoAllLevelsDecrease(report);
                }

                if(isReportSafe)
                {                    
                    safeLevels++;
                }
            }
        }

        Console.WriteLine(safeLevels);
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

    public static bool DoAllLevelsIncrease(List<int> report)
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

    public static bool DoAllLevelsDecrease(List<int> report)
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