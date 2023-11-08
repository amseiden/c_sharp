using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int>() { 1, 2, 1, 4 };

        // Add()
        numbers.Add(5);

        // AddRange()
        numbers.AddRange(new int[3] { 6, 7, 8 });
            foreach(var numbumber in numbers)
            Console.WriteLine(numbumber);

        // IndexOf()
        Console.WriteLine("Index of 2: " +numbers.IndexOf(2));
        Console.WriteLine("Last index of 1: " + numbers.LastIndexOf(1));

        // Count()
        Console.WriteLine("Count: "+ numbers.Count);

        // Remove()        inside of a foreach
        for (var i=0; i<numbers.Count; i++)
        {
            if (numbers[i] == 1)
                numbers.Remove(numbers[i]);
        }
        foreach (var numbumber in numbers)
            Console.WriteLine(numbumber);

        // Clear()
        numbers.Clear();
        Console.WriteLine("Now: "+numbers.Count());
    }
}