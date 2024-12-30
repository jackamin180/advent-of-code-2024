public class HeapMeOneMoreTime
{
    public int Occurrences { get; set; }
    public int Number { get; set; }

    private int __similarity { get; set; }

    public HeapMeOneMoreTime(int num, int occ = 1)
    {
        Number = num;
        Occurrences = occ;
        __similarity = -1;
    }

    public void Increment()
    {
        Occurrences++;
    }

    public int GetSimilarity()
    {
        if (__similarity == -1)
        {
            __similarity = Number * Occurrences;
        }

        return __similarity;
    }
}
public class Program 
{
    public static void Main()
    {
        var numberOfOccurrences = new Dictionary<int, HeapMeOneMoreTime>();
        var leftListReference = new List<HeapMeOneMoreTime>();
        var similarityScore = 0;

        using (var reader = new StreamReader("input.txt"))
        {
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                var leftNumber = int.Parse(line.Split("   ")[0]);
                var rightNumber = int.Parse(line.Split("   ")[1]);

                var rightNumberOccurrence = IncrementOccurrence(numberOfOccurrences, rightNumber);

                if(leftNumber == rightNumber)
                {
                    leftListReference.Add(rightNumberOccurrence);
                    continue;
                }
                
                var leftNumberOccurrenceRef = GetOrCreateNumberOccurrenceRef(numberOfOccurrences, leftNumber);
                leftListReference.Add(leftNumberOccurrenceRef);
            }
        }

        foreach (var numberOccurrence in leftListReference)
        {
            similarityScore += numberOccurrence.GetSimilarity();
        }

        Console.WriteLine(similarityScore);
    }

    public static HeapMeOneMoreTime IncrementOccurrence(Dictionary<int, HeapMeOneMoreTime> numberOfOccurrences, int number)
    {
        if (numberOfOccurrences.TryGetValue(number, out var heapMeOneMoreTime))
        {
            heapMeOneMoreTime.Increment();
            return heapMeOneMoreTime;
        }
        else
        {
            heapMeOneMoreTime = new HeapMeOneMoreTime(number);
            numberOfOccurrences.Add(number, heapMeOneMoreTime);
            return heapMeOneMoreTime;
        }
    }

    public static HeapMeOneMoreTime GetOrCreateNumberOccurrenceRef(Dictionary<int, HeapMeOneMoreTime> numberOfOccurrences, int number)
    {
        if (numberOfOccurrences.TryGetValue(number, out var heapMeOneMoreTime))
        {
            return heapMeOneMoreTime;
        }
        else
        {
            heapMeOneMoreTime = new HeapMeOneMoreTime(number, 0);
            numberOfOccurrences.Add(number, heapMeOneMoreTime);
            return heapMeOneMoreTime;
        }
    }

}