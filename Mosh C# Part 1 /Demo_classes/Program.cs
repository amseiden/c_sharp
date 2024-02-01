using DEMO_CLASSE;
using DEMO_CLASSES.Math;

namespace DEMO_CLASSES;

class Program
{
    static void Main(string[] args)
    {
        var john = new Person();
        john.FirstName = "John";
        john.LastName = "Smith";
        john.Introduce();

        Calculator calculator = new Calculator();
        var result = calculator.Add(1, 3);
        Console.WriteLine(result);
    }
}
