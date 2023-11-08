namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User, enter a number between 1 to 10: ");
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out int number);

            if (number is <= 0 or >= 11)
                Console.WriteLine("Invalid input");
            else
                Console.WriteLine("Valid input");
        }
    }
}