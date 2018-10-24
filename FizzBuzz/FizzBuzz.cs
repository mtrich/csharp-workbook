using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            //loop to cycle through numbers 1 to 1000
            for(int i = 1 ; i < 1000; i++)
            {
                //checks for multiple of 3 and 5 and writes FizzBuzz
                if((i % 3 == 0) && (i % 5 == 0)){
                    Console.WriteLine("FizzBuzz");
                }
                //checks for multiple of just 3 and writes Fizz
                else if (i % 3 == 0){
                    Console.WriteLine("Fizz");
                }
                //checks for multiple of just 5 and writes Buzz
                else if (i % 5 == 0){
                    Console.WriteLine("Buzz");
                }
                //writes all other numbers
                else{
                    Console.WriteLine(i);
                }
            }
        }
    }
}
