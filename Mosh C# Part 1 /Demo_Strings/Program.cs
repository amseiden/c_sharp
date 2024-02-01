using System;
using System.Net.Http.Headers;

namespace Demo_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullName = "Mosh Hamedani ";
            Console.WriteLine("Trim: '{0}'", fullName.Trim());
            Console.WriteLine("Trim & Upper: '{0}'", fullName.Trim().ToUpper());

            // version 1
            var index = fullName.IndexOf(' ');
            var firstName = fullName.Substring(0, index);
            var lastName = fullName.Substring(index + 1);
            Console.WriteLine("First: " + firstName + "\nLast: " + lastName);

            // version 2
            var names = fullName.Split(' ');
            Console.WriteLine("\nxFirst: " + names[0] + "\nxLast: " + names[1]);
            
            // Replace
            Console.WriteLine(fullName.Replace("\nMosh", "Ciornei"));
            
            //Convert
            var str = "24";
            var age = Convert.ToByte(str);
            Console.WriteLine("Age: "+age);

            float price = 29.95f;
            
            Console.WriteLine("Price: "+price.ToString("C0"));
        }
    }
}
