namespace CSharpFundamentals
{
    public enum ShippingMethod
    {
        regularAirMail = 1,
        RegisteredAirMail = 2,
        Express =3
    }

    class Program
    {
        static void Main(string[] args)
        {
            // cast the method to an int
            var method = ShippingMethod.Express;
            Console.WriteLine((int)method);         

            // convert a received number to yr app --> use casting
            var methodID = 3;
            Console.WriteLine((ShippingMethod)methodID);

            // convert method to a string
            Console.WriteLine(method.ToString());

            // Parsing string = converting to a different type 
            var methodName = "Express";

            // convert a Parsed String to Enum 
            var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine(shippingMethod);
        }
    }
}