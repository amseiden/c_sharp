using static System.Collections.Generic.IEnumerable<char>;

namespace _1_ArraysLists_2
{
    class Programdan
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User, enter your name: ");
            var userInput = Console.ReadLine();
            List<char> letters = new List<char>(); 

            // Add()
            foreach (char litera in userInput)
            {
                letters.Add(litera);
            }
            // Reverse()
            letters.Reverse();
            
            // Concatenate(letters)
            string reversedName = string.Concat(letters);
            Console.WriteLine("Your reversed name is: " + reversedName);

        }
    }
}