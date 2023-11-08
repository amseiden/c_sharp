
/*Write a program and ask the user to continuously enter a number or type "Quit" to exit.
 The list of numbers may include duplicates. 
 Display the unique numbers that the user has entered.*/

namespace _1_ArraysLists_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool ruleaza = true;

            while (ruleaza)
            {
                Console.WriteLine("Enter a number or \"quit\": ");
                string userInput = Console.ReadLine();
                if (userInput == "quit")
                    ruleaza = false;
                else
                {
                    int.TryParse(userInput, out int myNumber);
                    numbers.Add(myNumber);
                }
            }

            List<int> distinctNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (!distinctNumbers.Contains(number))
                {
                    distinctNumbers.Add(number);
                }
            }

            Console.WriteLine("\nYou previously entered: "+string.Join(", ", distinctNumbers));
        }
    }
}


