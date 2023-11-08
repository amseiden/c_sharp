namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        { 
            // CREATING 
                // timeSpan using 'new' operator 
                var timeSpan = new TimeSpan(1, 2, 3);
                var timeSpan1 = new TimeSpan(1,0,0);
                
                // declare timeSpan from static methods (starts with "from...")
                var timeSpan2 = TimeSpan.FromHours(1);  // timeSpan1 = timeSpan2
                
                // obtaining a timeSpan:
                var start = DateTime.Now;
                var end = DateTime.Now.AddMinutes(5);
                var duration = end - start;           // returns a timeSpan 
                Console.WriteLine("Duration: "+duration);

            
            // PROPERTIES
                Console.WriteLine("\nMinutes: "+timeSpan.Minutes);
                Console.WriteLine("Total minutes: "+timeSpan.TotalMinutes);

            // ADD
                Console.WriteLine("\nAdd Example: "+timeSpan.Add(TimeSpan.FromMinutes(8)));
           
            // SUBTRACT
                Console.WriteLine("Subtract Example: "+timeSpan.Subtract(TimeSpan.FromMinutes(8)));

            // CONVERSION 
                // ToString method 
                Console.WriteLine("ToString "+ timeSpan.ToString()); 
                //CW by default calls this(^) method. We use it only when we need a string somewhere else than console. 
            
            // PARSE
            Console.WriteLine("Parse: " + TimeSpan.Parse("01:02:03"));
        }
    }
}