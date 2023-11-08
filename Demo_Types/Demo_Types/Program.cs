namespace Yes
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 10;
            var b = a;    // a copy of 'a's value is copied and stored in "b"
            b++;          // "b" has its own location hence there is a new '10' 
            Console.WriteLine(string.Format("a: {0}, b: {1}", a, b));
            // as a result we get ->  a: 10, b: 11
            // as "a" and "b" values are completely independent

            var array1 = new int[3] { 1, 2, 3 };
            var array2 = array1;
            array2[0] = 0;
            Console.WriteLine(string.Format("array1[0]: {0}, array2[0]: {1}", array1[0], array2[0]));
            // as a result we get -> array1[0]: 0, array2[0]: 0
            // as ARRAYS are Reference Type
        }
    }
}
