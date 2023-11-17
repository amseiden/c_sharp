/*
 * Write a program and ask the user to enter a few numbers separated by a hyphen.
 * Work out if the numbers are consecutive.
 * For example, if the input is "5-6-7-8-9" or "20-19-18-17-16",
 * display a message: "Consecutive"; otherwise, display "Not Consecutive".
 */

using System.Globalization;
namespace _1_Text_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("User, enter some hyphen-separated numbers: ");
            string userInput = Console.ReadLine();
            
            char separator = '-';
            string[] numberStrings = userInput.Split(separator);
            
            bool ruleaza = true;
            List<int> numbers = new List<int>();
            
            foreach (string number in numberStrings)
            {
                int.TryParse(number, out int myNumber);
                numbers.Add(myNumber);
            }
            
            string numbersInline = string.Join(" ", numbers);
            Console.WriteLine("\nNumbers: "+numbersInline);

            int ratia;
            ratia = (numbers[1]-numbers[0]);
            Console.WriteLine("ratia = " + ratia);
            Console.WriteLine();

            
            while (ruleaza)
            {
                for (int i = 0; i < numbers.Count-1; i++)
                    if (!(numbers[i + 1] - numbers[i] == ratia))
                    {
                        Console.WriteLine("Not Consecutive");
                        Environment.Exit(0);
                    }
                Console.WriteLine("Consecutive");
                ruleaza=false;
            }
        }
    }
}

