namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User, enter a number: ");
            string userInputOne = Console.ReadLine();
            int.TryParse(userInputOne, out int numberOne);

            Console.WriteLine("User, enter another number: ");
            string userInputTwo = Console.ReadLine();
            int.TryParse(userInputTwo, out int numberTwo);

            if (numberOne < numberTwo)
                Console.WriteLine("Max: " + numberTwo);
            else
                Console.WriteLine("Max: " + numberOne);
        }
    }
}