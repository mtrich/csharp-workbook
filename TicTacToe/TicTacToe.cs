using System;

namespace TicTacToe
{
    class Program
    {
        //variable that determins who's turn it is
        public static string playerTurn = "X";

        //Array that keeps track of places on board
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };
        public static void Main()
        {
            //draws board and runs game while there is no winner or tie
            do
            {
                DrawBoard();
                GetInput();
            } while  (!CheckForWin()&&!CheckForTie());   
            // keeps program from closing automaticly
            Console.ReadLine();
        }

        //gets players move in terms of row and column number
        public static void GetInput()
        {
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Column:");
            int column = Convert.ToInt16(Console.ReadLine()) - 1;
            Console.WriteLine("Enter Row:");
            int row = Convert.ToInt16(Console.ReadLine()) - 1;
            PlaceMark(row,column);
        }   
        public static void PlaceMark(int row, int column)
        {
        // checks if players movement choice is emptey
        if (board[row][column] != "X" && board[row][column] != "O")
            {
                if (playerTurn == "X")
                {
                    //if game is not over, places x and switches to o
                    board[row][column] = "X";
                    if(!CheckForWin() && !CheckForTie())
                    {
                        playerTurn = "O";
                    }
                    //if game is won, draws final board and announces winner
                    else if(CheckForWin())
                    {
                        DrawBoard();
                        Console.WriteLine(playerTurn + " Wins!");
                    }
                    //if game is tie, draws final board and announces Tie
                    else if(CheckForTie())
                    {
                        DrawBoard();
                        Console.WriteLine("It's a Tie!");
                    }
                }
                else
                {
                    //if game is not over, places 0 and switches to x
                    board[row][column] = "O";
                    if(!CheckForWin() && !CheckForTie())
                    {
                        playerTurn = "X";
                    }
                    //if game is won, draws final board and announces winner
                    else if(CheckForWin())
                    {
                        DrawBoard();
                        Console.WriteLine(playerTurn + " Wins!");
                    }
                    //if game is tie, draws final board and announces Tie
                    else if(CheckForTie())
                    {
                        DrawBoard();
                        Console.WriteLine("It's a Tie!");
                    }
                }   
            }
            //if spot is taken anounces that the spot is taken
            else
            {
                Console.WriteLine("Spot is already taken");
            }
        }

        //decides if game is won
        public static bool CheckForWin()
        {
            if(HorizontalWin()||VerticalWin()||DiagonalWin())
            {
                return true;
            }
            return false;
        }

        //checks for horizontal win
        public static bool HorizontalWin()
        {
            if ((board[0][0] == playerTurn && board[0][1] == playerTurn && board[0][2] == playerTurn)||
                (board[1][0] == playerTurn && board[1][1] == playerTurn && board[1][2] == playerTurn)||
                (board[2][0] == playerTurn && board[2][1] == playerTurn && board[2][2] == playerTurn))
            {
                return true;
            }
            return false;
        }

        //checks for vertical win
        public static bool VerticalWin()
        {
            if ((board[0][0] == playerTurn && board[1][0] == playerTurn && board[2][0] == playerTurn)||
                (board[0][1] == playerTurn && board[1][1] == playerTurn && board[2][1] == playerTurn)||
                (board[0][2] == playerTurn && board[1][2] == playerTurn && board[2][2] == playerTurn))
            {
                return true;
            }
        
            return false;
        }

        //checks for diagonal win
        public static bool DiagonalWin()
        {
            if ((board[0][0] == playerTurn && board[1][1] == playerTurn && board[2][2] == playerTurn)||
                (board[2][0] == playerTurn && board[1][1] == playerTurn && board[0][2] == playerTurn))
            {
                return true;
            }
            return false;
        }

        //checks for tie
        public static bool CheckForTie()
        {
            if((board[0][0] != " " && board[0][1] != " " && board[0][2] != " " && board[1][0] != " " && board[1][1] != " " && board[1][2] != " " && board[2][0] != " " && board[2][1] != " " && board[2][2] != " ")&&(!HorizontalWin()||!VerticalWin()||!DiagonalWin()))
            {
                return true;
            }
            return false;
        }

        //draws board
        public static void DrawBoard()
        {
            Console.WriteLine("  1 2 3");
            Console.WriteLine("1 " + "{0}|{1}|{2}",board[0][0],board[0][1],board[0][2]);
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("3 " + String.Join("|", board[2]));
        }
    }
}