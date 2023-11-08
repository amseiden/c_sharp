namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            bool shouldExit = false;

            while (!shouldExit)
            {
                Console.Write("\nEnter a number or 'ok' to exit: ");
                string userInput = Console.ReadLine();

                if (userInput == "ok")
                {
                    Console.WriteLine("Exit");
                    shouldExit = true; 
                }
                else if (int.TryParse(userInput, out int inputNumber))
                {
                    sum += inputNumber;
                    Console.WriteLine($"Sum: {sum}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number or 'ok' to exit.");
                }
            }
        }
    }
}

