using System;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            //asks for user input
            Console.WriteLine("Enter your move:");
            string hand1 = Console.ReadLine().ToLower();

            //if player enters invalid hand, throws exception and asks for valid input
            while(hand1 != "rock"&&hand1 != "paper"&&hand1 != "scissors"){
                try{
                    
                    if (hand1 != "rock"&&hand1 != "paper"&&hand1 != "scissors")
                    {
                        throw new Exception ("Invalid move");
                    }
                }
                catch(Exception) {
                     
                    Console.WriteLine("Invalid move entered please try again");
                    hand1 = Console.ReadLine().ToLower();
                }
            }
            Console.WriteLine(outcome(compareHands(hand1,hand2())));
            //prevents program from closing
            Console.ReadLine();
        }
        public static string hand2()
        {
            //random computer input
            Random rnd = new Random();
            int computerMove = rnd.Next(1,4);
        
            if (computerMove == 1){
                Console.WriteLine("Computer chose rock");
                return "rock";
            }
            else if (computerMove == 2){
                Console.WriteLine("Computer chose paper");
                return "paper";
            }
            else{
                Console.WriteLine("Computer chose scissors");
                return "scissors";
            }
        }
        public static int compareHands(string hand1, string hand2)
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
        public static string outcome(int compareHands)
        {
            //logic to decide outcome
            if(compareHands == 0){
                return "it's a Tie!";
            }
            else if(compareHands == 1){
               return "You Win!";
            }
            else{
               return "You Lose!";
            }
        }   
    }
}
