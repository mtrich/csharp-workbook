using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkpoint3
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialises controller class and calls Run method
            Controller controller = new Controller();
            controller.Run(); 
        }
    }
    public class Controller
    {   
        //instantiates Dao
        static DAO theDao = new DAO();
        //sets itemList to Dao list
        static List<Item> itemList = theDao.list();

        //run method calls interaction method for now (plan to add methods to this class for logic done during different cases)
        public void Run()
        {
            //clears console before showing UI
            Console.Clear();
            Interaction();
        }
        
        //interaction method contains logic to decide what to do based on user interaction (will move most logic to other methods)
        public void Interaction()
        {
            
            //string to hold user input for use in loop and switch statements
            string input =" ";

            //welcome message
            Console.WriteLine("Welcome to the TODO list!"+"\r\n");
            //while user has not entered quit
            while(input != "quit")
            {
                //lists available functions
                Console.WriteLine("Available functions:\n\n"+
                "add:          add item to list\n"+
                "delete:       remove item from list\n"+
                "mark done:    mark item as done\n"+
                "list pending: list pending items\n"+
                "list done:    list completed items\n"+
                "list all:     list all the items\n"+
                "quit:         exit program\n");

                //asks user what they want to do
                Console.WriteLine("What would you like to do?");
                //stores input
                input = Console.ReadLine().ToLower();
                //switch statement that decides what to do based on user input
                switch(input)
                {
                    //case for adding an item to database
                    case "add":
                        AddItem();
                        break;
                    //case for deleting an item from database
                    case "delete":
                        DeleteItem();
                        break;
                    //case for marking an item done in database
                    case "mark done":
                        MarkItem();
                        break;
                    //case to list pending items
                    case "list pending":
                        ListItems(false,true);
                        break;
                    //case to list done items
                    case "list done":
                        ListItems(true,true);
                        break;
                    //case to list all items
                    case "list all":
                        ListItems(true,false);
                        break;
                    //if user enters anything other than an available case, lets user know
                    default:
                        Console.WriteLine("incorrect input entered");
                        break;
                }
                //clears console before while loop resets
                Console.Clear();
            }
            
        }

        static void AddItem()
        {
            Console.WriteLine("Enter a description for your task:");
            string itemDescription = Console.ReadLine();
            theDao.add(itemDescription);
            itemList = theDao.list();
        }
        static void DeleteItem()
        {
            foreach(Item eachItem in itemList)
            {
                Console.WriteLine(eachItem);
            }
            Console.WriteLine("\nEnter item to delete by Id:");
            int itemToDelete = Convert.ToInt16(Console.ReadLine());
            theDao.remove(itemToDelete);
            itemList = theDao.list();
        }
        static void MarkItem()
        {
            foreach(Item eachItem in itemList)
            {
                Console.WriteLine(eachItem);
            }
            Console.WriteLine("Enter item Id to mark done:");
            int itemToMark = Convert.ToInt16(Console.ReadLine());
            theDao.markDone(itemToMark);
            itemList = theDao.list();
        }
        static void ListItems(bool statusChecked, bool checkingSpecific)
        {
            foreach(Item listedItem in itemList)
            {
                if(checkingSpecific == true)
                {
                    if(listedItem.Status == statusChecked)
                    {
                        Console.WriteLine(listedItem);
                    }
                }
                else
                {
                    Console.WriteLine(listedItem);
                }
            }
            //enter key press detector
            System.Console.WriteLine("press enter to go back");
            string enterChecker = Console.ReadLine();
        }
    }

    //Item class for each item in todo list
    public class Item
    {
        //each item has an Id, a description, and a Status
        public int Id{get;set;}
        public string Description{get;set;}
        public bool Status{get;set;}
        //constructor overload used in adding an item with default status of not finished
        public Item(string description)
        {
            this.Description = description;
            this.Status = false;
        }
        
        //gives item a string
        override
        public String ToString(){
            return Id+": "+Description+" is "+(Status? "finished" : "pending");
        }
    }

    public class DAO
    {
        public Context context;
        public DAO(){
            //instantiates context
            context = new Context();
            //esures data base is created
            context.Database.EnsureCreated();
        }

        //list that has items from database added to it
        public List<Item> list(){
            List<Item> theResult = new List<Item>();
            foreach(Item anItem in context.myItems)
            {
                theResult.Add(anItem);
            }
            return theResult;
        }
        //method to add items to myItems Data base set
        public void add(String description)
        {
            context.myItems.Add(new Item(description));
            //saves changes
            context.SaveChanges();
        }
        //method to remove from DBset
        public void remove(int id)
        {
            foreach(Item checkedItem in context.myItems){
                if(checkedItem.Id == id)
                {
                    context.myItems.Remove(checkedItem);
                }
            }
            context.SaveChanges();  
        }
        //method to find from DBset
        public void markDone(int id)
        {
            foreach(Item checkedItem in context.myItems){
                if(checkedItem.Id == id)
                {
                    checkedItem.Status = true;
                }
            }
            context.SaveChanges();
        }

        public Item GetItem(String lookingFor)
        {
            foreach(Item anItem in context.myItems){
                if(anItem.Id.ToString() == lookingFor)
                {
                    return anItem;
                }
            }
            return null;
        }
    }
    public class Context : DbContext {
        public DbSet<Item> myItems {get;set;}
        
        override 
        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Filename=./Items.db");
        }
    }
}
