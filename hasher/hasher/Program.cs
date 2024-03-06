using ConsoleApp1;

class Program
{
    static void Main()
    {
        IPasswordHasher passwordHasher = new PasswordHasher();

        // Get user input for password
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        // Hash the password
        string hashedPassword = passwordHasher.Hash(password);

        // Display the hashed password
        Console.WriteLine("Hashed Password: " + hashedPassword);

        // Test password verification
        Console.Write("Enter the password again for verification: ");
        string inputPassword = Console.ReadLine();

        bool isPasswordCorrect = passwordHasher.Verify(hashedPassword, inputPassword);
        Console.WriteLine("Password verification result: " + isPasswordCorrect);
    }
}