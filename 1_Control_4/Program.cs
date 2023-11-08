using System.Threading.Channels;

namespace Exersaare
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runAttempts = true;
            int chances = 4;

            Random random = new Random();
            int randomPickUp = random.Next(1, 10);
            //Console.WriteLine(randomPickUp);         <- displays the correct number 

            while (runAttempts)
            {
                Console.WriteLine("Guess the number between 1 and 10. U have " + chances + " attempts: ");
                string userInput = Console.ReadLine();
                int.TryParse(userInput, out int userNumber);

                if (userNumber == randomPickUp)
                {
                    Console.WriteLine("You won!");
                    break;
                }
                else if (userNumber != randomPickUp)
                {
                    chances--;
                    if (chances == 0)
                    {
                        Console.WriteLine("You lost");
                        runAttempts = false;
                    }
                }
            }
        }
    }
}



