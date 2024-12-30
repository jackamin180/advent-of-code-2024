

public class Program
{
    public static void Main()
    {
        var lines = File.ReadAllLines("input.txt");

        if (lines.Length == 0)
        {
            Console.WriteLine(0);
            return;
        }

        var fileLength = lines.Length;
        var fileWidth = lines[0].Length;
        var xmasCount = 0;
        for(var rowIndex = 1; rowIndex < lines.Length - 1; rowIndex++)
        {
            var line = lines[rowIndex];
            for (var columnIndex = 1; columnIndex < line.Length - 1; columnIndex++)
            {
                var currentChar = line[columnIndex];
                if (currentChar != 'A')
                {
                    continue;
                }
                if (CheckMSSM(rowIndex, columnIndex, lines))
                {
                    xmasCount++;
                }
                else if (CheckMMSS(rowIndex, columnIndex, lines))
                {
                    xmasCount++;
                }
                else if (CheckSMMS(rowIndex, columnIndex, lines))
                {
                    xmasCount++;
                }
                else if (CheckSSMM(rowIndex, columnIndex, lines))
                {
                    xmasCount++;
                }
            }
        }

        Console.WriteLine(xmasCount);
    }

    private static bool CheckSSMM(int rowIndex, int columnIndex, string[] lines)
    {
        if (lines[rowIndex - 1][columnIndex-1] != 'S')
        {
            return false;
        }
        if (lines[rowIndex - 1][columnIndex + 1] != 'S')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex + 1] != 'M')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex - 1] != 'M')
        {
            return false;
        }

        return true;
    }

    private static bool CheckSMMS(int rowIndex, int columnIndex, string[] lines)
    {
        if (lines[rowIndex - 1][columnIndex - 1] != 'S')
        {
            return false;
        }
        if (lines[rowIndex - 1][columnIndex + 1] != 'M')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex + 1] != 'M')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex - 1] != 'S')
        {
            return false;
        }

        return true;
    }

    private static bool CheckMMSS(int rowIndex, int columnIndex, string[] lines)
    {
        if (lines[rowIndex - 1][columnIndex - 1] != 'M')
        {
            return false;
        }
        if (lines[rowIndex - 1][columnIndex + 1] != 'M')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex + 1] != 'S')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex - 1] != 'S')
        {
            return false;
        }

        return true;
    }

    private static bool CheckMSSM(int rowIndex, int columnIndex, string[] lines)
    {
        if (lines[rowIndex - 1][columnIndex - 1] != 'M')
        {
            return false;
        }
        if (lines[rowIndex - 1][columnIndex + 1] != 'S')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex + 1] != 'S')
        {
            return false;
        }
        if (lines[rowIndex + 1][columnIndex - 1] != 'M')
        {
            return false;
        }

        return true;
    }
}