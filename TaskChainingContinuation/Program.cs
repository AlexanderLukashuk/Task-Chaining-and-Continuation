// See https://aka.ms/new-console-template for more information

using Internal;
using System;
using System.Threading.Tasks;

Task<int[]> task1 = Task.Factory.StartNew(() => CreateRandomArray(10));
Task<int[]> task2 = task1.ContinueWith(array => MultiplyArray(array.Result));
Task<int[]> task3 = task2.ContinueWith(array => SortArrayAscending(array.Result));
Task<double> task4 = task3.ContinueWith(array => CalculateArrayAverage(array.Result));

Task.WaitAll(task1, task2, task3, task4);

Console.WriteLine("Task 1: Created array of 10 random integers.");
Console.WriteLine(string.Join(", ", task1.Result));

Console.WriteLine("Task 2: Multiplied the array by a random number.");
Console.WriteLine(string.Join(", ", task2.Result));

Console.WriteLine("Task 3: Sorted the array in ascending order.");
Console.WriteLine(string.Join(", ", task3.Result));

Console.WriteLine("Task 4: Calculated the average value of the array.");
Console.WriteLine(task4.Result);


static int[] CreateRandomArray(int length)
{
    Random random = new Random();
    return Enumerable.Range(1, length).Select(i => random.Next(1, 100)).ToArray();
}

static int[] MultiplyArray(int[] array)
{
    Random random = new Random();
    int multiplier = random.Next(1, 11);
    return array.Select(i => i * multiplier).ToArray();
}

static int[] SortArrayAscending(int[] array)
{
    return array.OrderBy(i => i).ToArray();
}

static double CalculateArrayAverage(int[] array)
{
    return array.Average();
}

