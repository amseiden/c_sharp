namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            const int passwordLength = 10;

            var buffer = new char[passwordLength];
            for (var i = 0; i < passwordLength; i++)
                buffer[i] = (char)('a' + random.Next(0, 26));
            var password = new string(buffer);

                Console.Write (password);

            // Console.WriteLine((int)'a');   //output: 97 <- a=97 for the computer
        }
    } 
}