namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("User, enter a number: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int inputNumber))
            {
                int[] numbers = new int[inputNumber];

                int factorial = 1;

                for (int i = 1; i <= inputNumber; i++)
                {
                    numbers[i-1] = i;
                }

                foreach (int number in numbers)
                {
                    factorial *= number;
                }
                Console.Write("\nFactorial of " + inputNumber + " is: " + factorial);
            }

            else
                Console.WriteLine("Invalid input");
        }
    }
}


