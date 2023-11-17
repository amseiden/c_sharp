
/* This is a general reusable program.
 * In fact, the task is declared here.
 * Then user personalizes is as he need.
 */

namespace ProceduralProgramming
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the values requested above: ");
            var input  = Console.ReadLine();

            // business logic
            var array = new char[input .Length];
            for (var i = input .Length; i > 0; i--)
                array[input .Length - i] = input [i - 1];

            var reversed = new string(array);

            Console.WriteLine("Output: ");
        }
    }
}