using System.Text;

namespace Yes
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare builder
            var builder = new StringBuilder();
            
            // call -> build, using the builder 
            builder
                .Append('-',8)
                .AppendLine()
                .Append("\n Header")
                .AppendLine()
                .Append('-',8);

            // replace characters 
            builder.Replace('-', '+');

            // remove characters
            builder.Remove(0, 10);
                
            // insert  dashes line 
            builder.Insert(0, new string('-', 8));
            
            
            Console.WriteLine(builder);
            
        }
    }
}

