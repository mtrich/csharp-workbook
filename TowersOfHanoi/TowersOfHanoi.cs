using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main()
        {
            //instatiates Game class
            Game game = new Game();
            //calls run method
            game.run();
        }
    }
    class Game
    {
        //creates Dictionary of towers with tower name as Key and Tower class as value
        Dictionary<string, Tower> towers = new Dictionary<string, Tower>();

        //method that runs game logic
        public void run()
        {
            //while loop that runs only while game is not won
            while(!CheckForWin())
            {
                //calls method that prints the game board
                PrintBoard();

                //asks user which tower to move block from then stores input as string
                Console.WriteLine("Move block from Tower _? (A,B,C)");
                string popOff = Console.ReadLine().ToUpper();

                //asks user where to move block from selected tower to then stores input as string
                Console.WriteLine("Move fromm tower "+popOff+" to tower_?");
                string pushOn = Console.ReadLine().ToUpper();

                //checks if move is legal
                bool legal = IsLegal(popOff, pushOn);
                if(legal)
                {
                    MovePiece(popOff, pushOn);
                }
                else
                {
                    Console.WriteLine("invalid move");
                }
                //seperates previous move from current move
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            //prints final board
            PrintBoard();
            //displays winning message
            Console.WriteLine("Congratulations! You win!");
        }
        public Game()
        { 
            //instantiates 4 blocks
            Block block1 = new Block(1,"   (=)");
            Block block2 = new Block(2,"  (===)");
            Block block3 = new Block(3," (=====)");
            Block block4 = new Block(4,"(=======)"); 

            //instantiates Tower A
            Tower towerA = new Tower("A");
            //pushes blocks to Tower A's Stack
            towerA.BlockStack.Push(block4);
            towerA.BlockStack.Push(block3);
            towerA.BlockStack.Push(block2);
            towerA.BlockStack.Push(block1);
            //Adds Tower A to dictionary
            towers.Add("A",towerA);

            //Instantiates tower b and c and adds them to dictionary
            Tower towerB = new Tower("B");
            towers.Add("B",towerB);
            Tower towerC = new Tower("C");
            towers.Add("C",towerC);
        }
        //method that displayes the board
        public void PrintBoard()
        {
            //foreach loop that writes name of each tower and each block in that tower
            foreach (var key in towers.Keys)
            {
                Console.WriteLine("tower: " + key);
                Tower tower = towers[key];
                foreach (Block block in tower.BlockStack)
                {
                    Console.WriteLine(block);
                }
            }   
        }
        //method that moves the blocks
        public void MovePiece(string popOff, string pushOn)
        {
            //block to carry block that user wishes to move as it is being moved
            Block popBlock;

            //gets value from tower that user has selected to move from
            if (towers.TryGetValue(popOff, out Tower Tower))
            {
                //pops from stack in user selected tower and assigns it to Block popBlock
                popBlock = Tower.BlockStack.Pop();
                //gets value from tower that user has selected to move to
                if (towers.TryGetValue(pushOn, out Tower tower))
                {
                    //pushes popBlock to selected tower
                    tower.BlockStack.Push(popBlock);
                }
            }    
        }
        //method that checks if move is legal
        public bool IsLegal(string popOff, string pushOn)
        {
            //2 blocks to carry blocks being checked
            Block checkBlock1;
            Block checkBlock2;
            //gets value from tower that user has selected to move from
            if(towers.TryGetValue(popOff, out Tower Tower))
            {
                //peeks from stack in user selected tower and assigns it to Block checkBlock1
                checkBlock1 = Tower.BlockStack.Peek();
                //gets value from tower that user has selected to move to
                if (towers.TryGetValue(pushOn, out Tower tower))
                {
                    //if destination has no blocks then move is legal
                    if (tower.BlockStack.Count == 0)
                    {
                        return true;
                    }
                    else
                    {
                        //peeks from stack in user selected tower and assigns it to Block checkBlock2
                        checkBlock2 = tower.BlockStack.Peek();
                        //if top block from destination tower has lower weight than block being moved then move is legal
                        if (checkBlock1.Weight < checkBlock2.Weight || tower.BlockStack.Count() == 0)
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
            return false;
        }
        //method to check for win
        public bool CheckForWin()
        {
            //trys to get value from Tower C
            if(towers.TryGetValue("C", out Tower Tower))
            {
                //if Tower C has 4 blocks then game is won
                if (Tower.BlockStack.Count == 4)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            return false;
        }
    }
    class Block
    {
        //Constructor for blocks that have a simple ascii graphic display and a weight both of which are privately set
        public Block(int weight, string display)
        {
            this.Weight = weight;
            this.Display = display;
        }
        public int Weight
        {
            get;
            private set;
        }
        public string Display
        {
            get;
            private set;
        }
        //converts blocks display to a string
        override public string ToString()
        {
            string DisplayString = Display;
            return DisplayString;
        }
    }
    class Tower
    {   
        //constructor for towers that have a privately set name and stack
        public Tower(String name)
        {
            this.BlockStack = new Stack<Block>();
            this.Name = name;
        }
        public Stack<Block> BlockStack{
            get;
            private set;
        }
        public String Name{
            get;
            private set;
        }
    }
}
