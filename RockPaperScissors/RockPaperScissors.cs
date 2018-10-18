using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            //user input
            Console.WriteLine("Enter your move:");
            string hand1 = Console.ReadLine().ToLower();

            //random computer input
            string hand2;
            Random rnd = new Random();
            int computerMove = rnd.Next(1,4);
            
            if (computerMove == 1){
                hand2 = "rock";
            }
            else if (computerMove == 2){
                hand2 = "paper";
            }
            else{
                hand2 = "scissors";
            }
            Console.WriteLine("Computer chose " + hand2);

            //logic to decide outcome
            int wincon = CompareHands(hand1,hand2);

            if(wincon == 0){
                Console.WriteLine("it's a Tie!");
            }
            else if(wincon == 1){
                Console.WriteLine("You Win!");
            }
            else{
                Console.WriteLine("You Lose!");
            }
            
            //prevents program from closing
            Console.ReadLine();
        }

        private static int CompareHands(string hand1, string hand2)
        {
            //Tie condition
            if(hand1 == hand2){
                return 0;
            }
            //Win Condition
            else if ((hand1 == "rock" && hand2 == "scissors")||(hand1 == "paper" && hand2 == "rock")||(hand1 == "scissors" && hand2 == "paper")){
                return 1;
            }
            //Loss Condition
            else{
                return 2;
            }
        }      
    }
}
