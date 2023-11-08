namespace Exersare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User, enter the speed limit: ");
            string userInputOne = Console.ReadLine();
            int.TryParse(userInputOne, out int speedLimit);

            Console.WriteLine("\nUser, enter your speed: ");
            string userInputTwo = Console.ReadLine();
            int.TryParse(userInputTwo, out int yourSpeed);

            int difference = yourSpeed - speedLimit;

            if (difference < 0)
                Console.WriteLine("\nOk");
            else if (difference > 0)
            {
                var demeritPoint = difference / 5;
                if (demeritPoint<=12)
                    Console.WriteLine("\nDemerit points: " + demeritPoint);
                else
                    Console.WriteLine("\nLicense suspended!");
            }
        }
    }
}


/* 
 *  speedLimit = 50
 *  
 *  yourSpeed = 54
 *  yourSpeed = 56
 *  yourSpeed = 68
 *  
 */


/*
 * speedLimit
 * yourSpeed
 * 
 * difference
 * demeritPoints = difference/5 
 * 
 * if demeritPoints >= 12 
 * { Suspend!}
 * 
 * 
 * 
 * 
 */



//if (yourSpeed <= speedLimit)
//    Console.WriteLine("\n Ok \n");

//else if (yourSpeed > (speedLimit + 4) && yourSpeed <= (speedLimit + 9))
//{
//    demeritPoint = 1;
//    Console.WriteLine("\n Y're speeding! \nDemering point: " + demeritPoint);
//}

//else if (yourSpeed > (speedLimit + 9) && yourSpeed <= (speedLimit + 14))
//{
//    demeritPoint = 2;
//    Console.WriteLine("\n Y're speeding! \nDemering point: " + demeritPoint);
//}

//else if (yourSpeed > (speedLimit + 14) && yourSpeed <= (speedLimit + 19))
//{
//    demeritPoint = 3;
//    Console.WriteLine("\n Y're speeding! \nDemering point: " + demeritPoint);
//}

//else if (yourSpeed > (speedLimit + 19) && yourSpeed <= (speedLimit + 24))
//{
//    demeritPoint = 4;
//    Console.WriteLine("\n Y're speeding! \nDemering point: " + demeritPoint);
//}
//else Console.WriteLine("Suspended!");