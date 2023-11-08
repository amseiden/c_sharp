namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 10; i>=1; i--)
            {
                 if(i%2 ==0)                // look only for the even numbers
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}