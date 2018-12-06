using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            //instatiates Game class
            Game run = new Game();
        }
    }

    public class Checker
    {
        //each checker has a symbol position array and color atribute
        public string Symbol  { get; set; }
        public int[] Position  { get; set; }
        public string Color { get; set; }
        
        //sets symbol for each color of checker
        public Checker(string color, int[] position)
        {
            
            this.Position = position;
            
            this.Color = color;

            if (Color == "white")
            {
                Symbol = "O";
            }
            else
            {
                Symbol ="@";
            }
        }
    }

    public class Board
    {
        //board has grid and list of checkers attributes
        public string[,] Grid  { get; set; }
        public List<Checker> Checkers { get; set; }
        
        //this method draws the current state of the board when called
        public void CreateBoard()
        {
            //top two lines are the column numbers and top border
            Console.WriteLine("     0    1    2    3    4    5    6    7  ");
            Console.WriteLine("   ________________________________________ ");
            //loops through rows
            for (int i = 0; i < 8; i++)
            {
                //even row places start on column two
                if(i%2 == 0)
                {
                    Console.WriteLine(i+" |█████  "+ Grid[1,i] +"  █████  "+ Grid[3,i] +"  █████  "+ Grid[5,i] +"  █████  "+ Grid[7,i] +"  |");
                    Console.WriteLine("  |█████     █████     █████     █████     |");
                }
                //last row has bottom border
                else if (i == 7)
                {
                    Console.WriteLine(i+" |  "+ Grid[0,i] +"  █████  "+ Grid[2,i] +"  █████  "+ Grid[4,i] +"  █████  "+ Grid[6,i] +"  █████|");
                    Console.WriteLine("  |_____█████_____█████_____█████_____█████|");
                }
                //odd row places start on column 1
                else
                {
                    Console.WriteLine(i+" |  "+ Grid[0,i] +"  █████  "+ Grid[2,i] +"  █████  "+ Grid[4,i] +"  █████  "+ Grid[6,i] +"  █████|");
                    Console.WriteLine("  |     █████     █████     █████     █████|");
                }
            }
        }
        
        public void GenerateCheckers()
        {
            //array of checker positions
            int[,] whitePositions = {{0,5}, {2,5}, {4,5}, {6,5}, {1,6}, {3,6}, {5,6}, {7,6}, {0,7}, {2,7}, {4,7}, {6,7}};
            int[,] blackPositions = {{1,0}, {3,0}, {5,0}, {7,0}, {0,1}, {2,1}, {4,1}, {6,1}, {1,2}, {3,2}, {5,2}, {7,2}};
            

            //creates new list of checkers
            Checkers = new List<Checker>();

            //for the number of checkers that will be on either side
            for(int i=0; i<12; i++)
            {
                //instantiates and adds new checkers to Checkers list with position from White and Black positions arrays
                Checker whiteChecker = new Checker("white",new int[] {whitePositions[i,0],whitePositions[i,1]});
                Checkers.Add(whiteChecker);
                Checker blackChecker = new Checker("black",new int[] {blackPositions[i,0],blackPositions[i,1]});
                Checkers.Add(blackChecker);
            }
        }
        
        //places initial checkers
        public void PlaceCheckers()
        {
            Grid = new string[8,8];
            //goes through x axis of grid
            for (int x = 0; x < 8; x++)
            {
                //goes through y axis of grid
                for (int y = 0; y < 8; y++)
                {
                    //sets each grid space to a string containing a space
                    Grid[x,y] = " ";
                }
            }
            //loops through checkers in Checkers list
            for (var i = 0; i < Checkers.Count; i++)
            {
                //position equals current checkers position
                int[] position = Checkers[i].Position;
                //grid at current checkers position equals current checkers symbol
                Grid[position[0],position[1]] = Checkers[i].Symbol;
            }
        }
        
        //method calls placeCheckers method and createBoard method to draw the initial board
        public void DrawBoard()
        {
            PlaceCheckers();
            CreateBoard();
        }
        
        public Checker SelectChecker(int column, int row)
        {
            //returns checker at column and row passed in when method is called
            return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { column, row }));
        }
        
        public void RemoveChecker(int column, int row)
        {
            //sets removedChecker equal to checker at column and row passed in
            Checker removedChecker = Checkers.Find(x => x.Position.SequenceEqual(new List<int> { column, row }));
            //removes checker from Checkers list
            Checkers.Remove(removedChecker);
            //sets checkers grid space to emptey
            this.Grid[column,row] = " ";
            //lets players know that a piece was captured
            Console.WriteLine("Piece Captured!");
        }
        
        public bool CheckForWin()
        {
            //returns true if all pieces are white or no white pieces exist
            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        //instantiates new board
        public Board board = new Board();
        
        public Game()
        {
            //of size 8 by 8
            board.Grid = new string[8,8];
            
            //generates initial checkers
            board.GenerateCheckers();
            //draws initial board
            board.DrawBoard();

            //while no one has won
            while(!board.CheckForWin())
            {
                //get input for pickup column and store as int columnStart
                Console.WriteLine("Enter pickup column:");
                int columnStart = Convert.ToInt16(Console.ReadLine());

                //get input for pickup row and store as int rowStart
                Console.WriteLine("Enter pickup row:");
                int rowStart = Convert.ToInt16(Console.ReadLine());

                //if input is not within bounds of board or selected grid square is empty let user know that no piece was selected
                if (SelectablePiece(columnStart, rowStart))
                {
                    //selected checker equals checker at user inputed position
                    Checker selectedChecker = board.SelectChecker(columnStart,rowStart);

                    //get input for drop off column and store as int columnTo
                    Console.WriteLine("Enter drop off Column:");
                    int columnTo = Convert.ToInt16(Console.ReadLine());

                    //get input for drop off row and store as int rowTo
                    Console.WriteLine("Enter drop off Row:");
                    int rowTo = Convert.ToInt16(Console.ReadLine());
                    bool movingLeft = MovingLeft(columnStart, columnTo);
                    
                    if(selectedChecker.Color == "white" && IsLegalWhite(columnStart, rowStart, columnTo, rowTo))
                    {
                        // if player moves left and spot to left and up one is enemy
                        if(movingLeft && board.Grid[columnStart-1,rowStart-1] == "@")
                        {
                            //remove enemy that player has jumped
                            board.RemoveChecker(columnStart-1,rowStart-1);
                        }
                        // if player moves right and spot to right and up one is enemy
                        else if(!movingLeft && board.Grid[columnStart+1,rowStart-1] == "@")
                        {
                            //remove enemy that player has jumped
                            board.RemoveChecker(columnStart+1,rowStart-1);
                        }
                        //start grid position is now empty
                        board.Grid[columnStart,rowStart] = " ";
                        //To grid positon = selected checkers symbol
                        board.Grid[columnTo,rowTo] = selectedChecker.Symbol;
                        //changes selected checkers position to new position
                        selectedChecker.Position[0] = columnTo;
                        selectedChecker.Position[1] = rowTo;
                    }
                    //if selected checker is black
                    else if(selectedChecker.Color == "black" && IsLegalBlack(columnStart, rowStart, columnTo, rowTo))
                    {
                        // if player moves left and spot to left and down one is enemy
                        if(movingLeft && board.Grid[columnStart-1,rowStart+1] == "O")
                        {
                            //remove enemy that player has jumped
                            board.RemoveChecker(columnStart-1,rowStart+1);
                        }
                        // if player moves right and spot one right and one down is enemy
                        else if(!movingLeft && board.Grid[columnStart+1,rowStart+1] == "O")
                        {
                            //remove enemy that player has jumped
                            board.RemoveChecker(columnStart+1,rowStart+1);
                        }
                        //start grid position is now empty
                        board.Grid[columnStart,rowStart] = " ";
                        //To grid positon = selected checkers symbol
                        board.Grid[columnTo,rowTo] = selectedChecker.Symbol;
                        //changes selected checkers position to new position
                        selectedChecker.Position[0] = columnTo;
                        selectedChecker.Position[1] = rowTo;
                    }
                    //if move is not valid let user know
                    else
                    {
                        Console.WriteLine("invalid move");
                    }
                }
                //draws new board before loop repeats or ends
                board.CreateBoard();
            }
            //if all checkers in Checkers list are white then white wins
            if(board.Checkers.All(x => x.Color == "white"))
            {
                Console.WriteLine("White wins!");
            }
            //if all checkers in Checkers list are black then black wins
            else if(board.Checkers.All(x => x.Color == "black"))
            {
                Console.WriteLine("Black wins!");
            }
        }

        //method checks if user chooses a selectable piece 
        public bool SelectablePiece(int columnStart, int rowStart)
        {
            //piece is outside of bounds of board or selected grid square does not have a piece
            if ((columnStart > 7 || columnStart < 0 || rowStart > 7 || rowStart < 0) || board.Grid[columnStart,rowStart] == " ")
                {
                    //let user know no piece was selected and return false
                    Console.WriteLine("No piece selected");
                    return false;
                }
            else
            {
                return true;
            }
        }
        //if selected piece is white check if move is legal
        public bool IsLegalWhite(int columnStart, int rowStart,int columnTo, int rowTo)
        {
            //checks if piece is moving left
            bool movingLeft = MovingLeft(columnStart, columnTo);
            if(//columnTo and rowTo is empty       and piece is not moving to same row and column
                (board.Grid[columnTo,rowTo] == " " && rowTo != rowStart && columnTo != columnStart)
                //and piece is moving right and is moving 1 right and 1 up                 or piece 1 up and 1 right from start is enemy  and piece is moving 2 right and two up
                && ((!movingLeft && ((columnTo == columnStart+1 && rowTo == rowStart - 1) || (board.Grid[columnStart+1,rowStart-1] == "@" && columnTo == columnStart+2 && rowTo == rowStart - 2)))
                //or piece is moving left and is moving 1 left and 1 up                   or piece 1 up and 1 left from start is enemy    and piece is moving 2 left and two up
                || (movingLeft && ((columnTo == columnStart -1 && rowTo == rowStart - 1) || (board.Grid[columnStart-1,rowStart-1] == "@" && columnTo == columnStart-2 && rowTo == rowStart - 2)))))
            {
                return true;
            } else return false;
        }
        //if selected piece is black check if move is legal
        public bool IsLegalBlack(int columnStart, int rowStart,int columnTo, int rowTo)
        {
            bool movingLeft = MovingLeft(columnStart, columnTo);
            if(//columnTo and rowTo is empty       and piece is not moving to same row and column
                (board.Grid[columnTo,rowTo] == " " && rowTo != rowStart && columnTo != columnStart)
                //and piece is moving right and is moving 1 right and 1 down              or piece 1 down and 1 right from start is enemy   and piece is moving 2 right and two down
                && ((!movingLeft && ((columnTo == columnStart+1 && rowTo == rowStart + 1) || (board.Grid[columnStart+1,rowStart+1] == "O" && columnTo == columnStart+2 && rowTo == rowStart + 2)))
                //or piece is moving left and is moving 1 left and 1 down                or piece 1 down and 1 left from start is enemy    and piece is moving 2 left and two down
                || (movingLeft && ((columnTo == columnStart -1 && rowTo == rowStart + 1) || (board.Grid[columnStart-1,rowStart+1] == "O" && columnTo == columnStart-2 && rowTo == rowStart + 2)))))
            {
                return true;
            } else return false;
        }
        //checks if piece is moving left so that if a piece is on the side of the board there isn't an out of bounds exception if logic checks beyond the board
        public bool MovingLeft(int columnStart,int columnTo)
        {
            //if moving to greater column return true
            if(columnStart > columnTo)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
}
