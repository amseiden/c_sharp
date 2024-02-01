namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var numbers = new[]{ 3, 7, 9, 2, 4, 6};

            // Length()
            Console.WriteLine("Length: " + numbers.Length);

            // Index0f ()
            var index = Array.IndexOf(numbers, 9);
            Console.WriteLine("Index of 9: " + index);

            //Clear()
            Array.Clear(numbers, 0, 2);
            Console.WriteLine("\nClear result: ");
            foreach(var nuremberg in numbers)
                Console.WriteLine(nuremberg);

            //Copy()
            int[] another = new int[3] {1,2,3};
            Console.WriteLine("\nNurburgring: ");
            foreach (var nurburgring in another)
                    Console.WriteLine(nurburgring);
            Array.Copy(numbers, another,3);
            Console.WriteLine("\nCopy result: ");
            foreach(var nurburgring in another)
                Console.WriteLine(nurburgring);

            //Sort()
            int[] spring = new int[3] { 3, 2, 55 };
            Console.WriteLine("\nSpring: ");
            foreach (var winter in spring)
                Console.WriteLine(winter);

            Console.WriteLine("\nSorted numbers: ");
            Array.Sort(numbers);
            foreach (var winter in numbers)
                Console.WriteLine(winter);

            //Reverse()
            Array.Reverse(numbers);
            Console.WriteLine("\nReversed numbers: ");
            foreach (var winter in numbers)
                Console.WriteLine(winter);

        }
    }
}