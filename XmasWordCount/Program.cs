
using AdventOfCodeLib;
using AdventOfCodeLib.Xmas;

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
        var xmasWordChecker = new XmasWordChecker(fileLength, fileWidth);
        foreach (var line in lines)
        {
            foreach (var character in line)
            {
                xmasWordChecker.AddToSequence(character);
            }
        }

        Console.WriteLine(xmasWordChecker.GetXmasCount());
    }
}