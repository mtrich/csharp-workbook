using System;

namespace practice_week1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a C# program that takes two numbers as input, adds them together, and displays the result of that operation
            Console.WriteLine("please enter 2 numbers to add");            
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 + num2);            
            
            //Write a C# program that converts yards to inches.
            Console.WriteLine("How many inches do you want to convert?");
            double inch = Convert.ToDouble(Console.ReadLine());
            double yard = inch/36;
            Console.WriteLine(yard + " Yards");
            
            //Create and define the variable people as true.
            bool people = true;

            //Create and define the variable f as false.
            bool f = false;

            //Create and define the variable num to be a decimal.
            Console.WriteLine("enter decimal number");
            decimal num = Convert.ToDecimal(Console.ReadLine());

            //Display the product of num multiplied by itself.
            Console.WriteLine("decimal multiplied by itself " + num*num);

            //Create the following variables with your personal information:
            // firstName
            // lastName
            // age
            // job
            // favoriteBand
            // favoriteSportsTeam

            string firstName = "Michael";
            string lastName = "Rich";
            int age = 23;
            string job = "Pharmacy Tech";
            string favoriteBand = "Pink Floyd";
            string favoriteSportsTeam = "Steelers";

            //Experiment with Console.WriteLine(); to print out different pieces of your personal information.
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Last name: " + lastName);
            Console.WriteLine("age: "+ age);
            Console.WriteLine("job: " + job);
            Console.WriteLine("Favorite Band: " + favoriteBand);
            Console.WriteLine("Favorite Sports team: " + favoriteSportsTeam);

            //Convert the variable num to an int.
            int numInt = Convert.ToInt16(num);

            //Print to the console the sum, product, difference, and quotient of 100 and 10. 
            Console.WriteLine(100+10);
            Console.WriteLine(100*10);
            Console.WriteLine(100-10);
            Console.WriteLine(100/10);
        }
    }
}
