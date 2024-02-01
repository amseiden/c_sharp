namespace SharpFundamentals
{
    public class Person
    {
        public int Age;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var number = 1;
            Increment(number);
            Console.WriteLine(number);              // absolute value

            var person = new Person() {Age = 20};
            MakeOld(person);
            Console.WriteLine(person.Age);          // referenced value
        }

        public static void Increment(int number)
            // this "number" is not the same with the previous one
            // this one is correlated with Increment method and has its own memory allocation
        {
            number += 10;
        }

        public static void MakeOld(Person person)
        {
            person.Age += 10;
        }
    }
}