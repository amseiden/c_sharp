/*
 Write a program and ask the user to supply a list of comma separated numbers ( 5, 1, 9, 2, 10).
 If the list is empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; 
 otherwise, display the 3 smallest numbers in the list.
 */
 
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        bool ruleaza = true;

        while (ruleaza)
        {
            Console.WriteLine("\nEnter 5 or more comma-separated numbers: ");
            string userInput = Console.ReadLine();
            char delimiter = ',';
            string[] numberStrings = userInput.Split(delimiter);
            
            if (userInput == "" || numberStrings.Length < 5 || userInput == " ")
            {
                Console.WriteLine("Invalid List. Retry.");
            }
            
            else if (numberStrings.Length > 5 )
            {
                foreach (string number in numberStrings)
                {
                    int.TryParse(number, out int myNumber);
                    numbers.Add(myNumber);
                }

                if (numbers.Count < 5)
                {
                    Console.WriteLine("Invalid List");
                }
                else
                {
                    numbers.Sort();
                    Console.WriteLine("The 3 smallest numbers in the list are: ");
                    for (int i=0; i<3; i++)
                    {
                        Console.WriteLine(numbers[i]);
                    }
                    // Console.WriteLine(numbers.GetRange(0,3));
                    ruleaza = false;
                }
            }
        }
    }
}