namespace Exersaare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a series of numbers separated by comma: ");
            string userInput = Console.ReadLine();

            string[] myNumbers = userInput.Split(',');
            List<double> userNumbers = new List<double>();

            foreach(string numString in myNumbers)
            {
                if (double.TryParse(numString, out double number))
                    userNumbers.Add(number);
                else
                    Console.WriteLine("Invalid input");
            }

            double maxNumber = userNumbers.Count > 0 ? userNumbers.Max() : 0;
            Console.WriteLine($"Maximum number entered: {maxNumber}");
            
            string[] myumbers = userInput.Split();
            
        }
    }
}
