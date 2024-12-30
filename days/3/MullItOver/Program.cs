
using AdventOfCodeLib;

public class Program
{
    public static void Main()
    {
        var result = 0;
        var fileContent = File.ReadAllText("input.txt");
        var memory = new MultiplyMe();
        //I chose not to do a regex solution
        for (int i = 0; i < fileContent.Length; i++)
        {
            var current_char = fileContent[i];
            memory = memory.AddToSequence(current_char);
        }

        result = BubbleUp(memory);
        Console.WriteLine(result);
    }

    public static int BubbleUp(MultiplyMe memory)
    {
        var result = memory.Multiply();
        if (memory.PrevLink == null)
        {
            return result;
        }

        return result + BubbleUp(memory.PrevLink);
    }
}