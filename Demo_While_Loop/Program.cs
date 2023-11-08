namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Type your name: ");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                    break;
                else
                    Console.WriteLine("Echo: " + input);
            }
        }
    }
}