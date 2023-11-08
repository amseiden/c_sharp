namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a series of names separated by \"space\": ");
            string userInput = Console.ReadLine();

            string[] namesInput = userInput.Split();
            List<string> names = new List<string>(namesInput);

            //for (int i = 0; i < namesInput.Length; i++) Console.Write(namesInput[i] + " ");
            //Console.WriteLine("-----------------------");
            //for (int i = 0; i < names.Count; i++) Console.Write(names[i] + " ");
            //Console.WriteLine();

            if (names[names.Count - 1] == "")
                names.RemoveAt(names.Count - 1);

            if (names.Count == 0)
                Console.WriteLine("Nobody likes you. Go cry.");

            else if (names.Count == 1)
            {
                foreach (var otherName in names)
                    Console.WriteLine(otherName + " liked your post out of politeness.");
            }

            else if (names.Count == 2)
                    Console.WriteLine(names[0] + " and " + names[1] + " liked your post. They actually dont like you.");
 

            else if (names.Count > 2)
                    Console.WriteLine(names[0] + " and " + names[1] + " and " + (names.Count - 2) + " more liked your post.");

        }
    }
}

