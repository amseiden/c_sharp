namespace _1_ArraysLists_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            while (numbers.Count < 5)
            {
                Console.WriteLine("User enter a number: ");
                var userInput = Console.ReadLine();
                int.TryParse(userInput, out int myNumber);
                if (numbers.Contains(myNumber))
                {
                    Console.WriteLine("Choose another number.");
                }
                else
                {
                    numbers.Add(myNumber);
                }
            }

            numbers.Sort();
            Console.WriteLine(string.Concat(numbers));
        }
    }
}