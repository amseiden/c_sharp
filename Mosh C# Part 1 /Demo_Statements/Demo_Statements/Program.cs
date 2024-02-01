using System;

namespace Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            var season = Season.Autumn;

            // an easy way
            /*
            switch (season)
            {
                case Season.Autumn:
                    Console.WriteLine("Its autumn");
                    break;
                case Season.Winter:
                    Console.WriteLine("Its winter");
                    break;
                case Season.Spring:
                    Console.WriteLine("Its spring");
                    break;
                default:
                    Console.WriteLine("Its summer");
                    break;
            */

            // a smart way

            switch (season)
            {
                case Season.Winter:                     // case Winter or
                case Season.Autumn:                     // case Summer -> same statement
                    Console.WriteLine("Promotion");
                    break;

                default:
                    Console.WriteLine("No promotion");
                    break;

            }
        }
    }
}