namespace Exersare
{
 class Program
 {
  static void Main(string[] args)
  {
   var dateTime = new DateTime (2023, 11, 27); //immutable 
   var now = DateTime.Now;
   var today = DateTime.Today;
   Console.WriteLine( "Hour: " + now.Hour);
   Console. WriteLine ("Minute: "+ now.Minute);

   var tomorrrow = now.AddDays(1);    // Hour: 16
   var yesterday = now.AddDays(-1);   // Minute: 35 

   Console.WriteLine("\n");
   Console.WriteLine(now.ToLongDateString());  // Friday, 27 October 2023
   Console.WriteLine(now.ToShortDateString()); // 27.10.2023
   Console.WriteLine(now.ToLongTimeString());  // 16:35:28
   Console.WriteLine(now.ToShortTimeString()); // 16:35
   Console.WriteLine(now.ToString());          // Date+Time

   Console.WriteLine(now.ToString("\nyy-MM-dd HH:mm"));  // format
   
   
   
         //    TIME SPAN   //

         // Creating
         var timeSpan = new TimeSpan(1, 2, 3);
         var timeSpan1 = new TimeSpan(1, 0, 0);

         var start =  DateTime.Now;
         var end =  DateTime.Now.AddMinutes(5);
         var duration = end - start;
         Console.WriteLine("Duration: "+duration);

         // Properties
         timeSpan




  }
 }
}

