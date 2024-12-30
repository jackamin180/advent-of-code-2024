using System;
using System.Collections.Generic;

var minHeap1 = new PriorityQueue<int, int>(); 
var minHeap2 = new PriorityQueue<int, int>(); 

long diff = 0;

using (var reader = new StreamReader("input.txt"))
{
    var line = string.Empty;
    while ((line = reader.ReadLine()) != null)
    {
        var num1 = int.Parse(line.Split("   ")[0]);
        var num2 = int.Parse(line.Split("   ")[1]);
        minHeap1.Enqueue(num1, num1);
        minHeap2.Enqueue(num2, num2);      
    }
}

var count = minHeap1.Count;
for (var i = 0; i < count; i++)
{
    diff += Math.Abs(minHeap1.Dequeue() - minHeap2.Dequeue());
}

Console.WriteLine(diff);