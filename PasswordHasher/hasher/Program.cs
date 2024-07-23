using ConsoleApp1;

class Program
{
    static void Main()
    {
        IPasswordHasher passwordHasher = new PasswordHasher();

        // input password
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        // hash the password
        string hashedPassword = passwordHasher.Hash(password);

        // display the hashed password
        Console.WriteLine("Hashed Password: " + hashedPassword);

        // verification
        Console.Write("Enter the password again for verification: ");
        string inputPassword = Console.ReadLine();

        bool isPasswordCorrect = passwordHasher.Verify(hashedPassword, inputPassword);
        Console.WriteLine("Password verification result: " + isPasswordCorrect);
    }
}