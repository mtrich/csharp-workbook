using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint1
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(Program1());
            Console.WriteLine(Program2());
            Console.WriteLine(Program3());
            program4();
            Console.WriteLine(program5());
        }

        //1- Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. Display the count on the console.
        public static int Program1()
        {
            //counter of numbers divisable by 3
            int num = 0;
            for(int i=1 ; i<100; i++)
            {
                //increments counter for each number divisable by 3
                if(i % 3 == 0)
                {
                    num ++;   
                }
            }
            return num;
        }
        
        //2- Write a program and continuously ask the user to enter a number or "ok" to exit. Calculate the sum of all the previously entered numbers and display it on the console.
        public static int Program2()
        {
            List<int> num = new List<int>{};
            //user input
            Console.WriteLine("Please enter a number or enter 'ok' to exit");
            string input = Console.ReadLine();

            int sum = 0;

            //allows user to keep adding numbers to num list and finds the lists sum as long as input is not "ok" 
            while(input.ToLower() != "ok")
            {
                num.Add(Convert.ToInt32(input));
                sum = num.Sum();
                input = Console.ReadLine();
            }
            return sum;
        }

        //3- Write a program and ask the user to enter a number. Compute the factorial of the number and print it on the console. For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 and display it as 5! = 120.
        static public int Program3()
        {
            //user input
            Console.WriteLine("Please enter a number");
            int input = Convert.ToInt32(Console.ReadLine());

            int factorial = 1;

            //multiplies 1 by input then takes the product and multiplies it by input - 1 and repeats until input = 1
            while (input != 1)
            {
                factorial = factorial * input;
                input = input - 1;
            }
            return factorial;
        }

        //4- Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. If the user guesses the number, display “You won"; otherwise, display “You lost". (To make sure the program is behaving correctly, you can display the secret number on the console first.)
        static public void program4()
        {
            //rng
            Random rnd = new Random();
            int rndnum = rnd.Next(1,11);

            //counter
            int turnCounter = 0;

            Console.WriteLine("Guess a number between 1 and 10");
            //user input
            int guess = Convert.ToInt32(Console.ReadLine());
            //checks if guess is wrong and if user can guess again
            while(turnCounter < 3 && guess != rndnum)
            {
                if(guess != rndnum && turnCounter < 3)
                {
                    Console.WriteLine("You guessed incorectly. please try again");
                    //user input
                    guess = Convert.ToInt32(Console.ReadLine());
                    //increments counter
                    turnCounter++; 
                }
            }
            if(turnCounter == 3 && guess!= rndnum)//checks if user did not guess correctly and guesses are up
            {
                Console.WriteLine("You have not guessed correctly and your chances are up");
            }else if (guess == rndnum)//checks if user has guessed correctly
            {
                Console.WriteLine("You have guessed correctly!");
            }
        }

        //5- Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the numbers and display it on the console. For example, if the user enters “5, 3, 8, 1, 4", the program should display 8.
        static public int program5()
        {
            //user input
            Console.WriteLine("Please enter a series of numbers seperated by comas");
            string series = Console.ReadLine();
            //splits user input
            string[] stringArray = series.Split(',');
            //assigns int to each split number from user input
            int[] intArray = new int[stringArray.Length];

            //converts string array to int array
            for( int i = 0; i < stringArray.Length ; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }
            //finds max of int array
            int max = intArray.Max();
            return max;
        }
    }
}
