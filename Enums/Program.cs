using System;

namespace Enums
{
    class Program
    {
        static void Main()
        {
            //days into year that birthday occurs
            int myBirthday = 90;
            //day of week -1 for 1950
            int dayOfWeekTracker = -1;
            //promts user to enter a year and stores as int
            Console.WriteLine("Enter Year");
            int year = Convert.ToInt16(Console.ReadLine());

            //increments a counter by 1 on normal years and by 2 on leap years to keep track of week day shift through years
            for (int yearCheck = 1950; yearCheck <= year; yearCheck++)
            {
                //if leap year add two
                if(yearCheck%4 == 0)
                {
                    dayOfWeekTracker += 2;
                }
                //if normal year add 1
                else dayOfWeekTracker++;
            }
                //caculates day of week that birthday lands on
                int DayOfWeek = (myBirthday+dayOfWeekTracker)%7;
                //writes year and day of week that birthday lands on
                Console.WriteLine("year "+ (year)+" " + (DaysOfWeek)(DayOfWeek));
                Console.ReadLine();
        }

        //enum to store days of week as ints
        enum DaysOfWeek
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
        }
    }
}
