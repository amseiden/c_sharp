namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User, enter the width of the image: ");
            string userInputOne = Console.ReadLine();
            int.TryParse(userInputOne, out int width);

            Console.WriteLine("User, enter the height of the image: ");
            string userInputTwo = Console.ReadLine();
            int.TryParse(userInputTwo, out int height);

            if (width > height)
                Console.WriteLine("\nThe image is landscape.\n");
            else
                Console.WriteLine("\nThe image is portrait.\n");
        }
    }
}