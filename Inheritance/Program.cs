using System;
using System.Collections.Generic;
using System.Linq;

namespace Inheritance
{
    class Program
    {
        // this is the main entry point and driver for this program
        static void Main(string[] args)
        {
            // initialize an empty list to hold the inventory
            List<Vehicle> inventory = new List<Vehicle>();

            // this varaible tracks if the program should continue asking the user for input or exit
            bool done = false;

            // while we are not done
            while (!done)
            {
                // ask the user for what they want to do
                String option = getUserOption();

                // if they want to list the inventory
                // call the method to list it
                if (option == "list")
                {
                    printInventory(inventory);
                }
                // if they want to add an item to the inventory, 
                // call the method to get the item from the user
                else if (option == "add") 
                {
                    Vehicle newItem = getNewItem();
                    inventory.Add(newItem);
                }
                // if they want to delete an item,
                // call a method to get the index of the item they want to delete
                else if (option == "delete")
                {
                    int idx = getDeletePosition();
                    if (idx >=0 && idx < inventory.Count)
                    {
                        inventory.RemoveAt(idx);
                    } else {
                        Console.WriteLine("Bad position");
                    }
                }
                // if they want to quit,
                // set the done flag to false, so the main loop exits
                else if (option == "quit")
                {
                    done = true;
                }

                // print an empty line just to break up the input
                // Console.clear would also work here
                Console.WriteLine();
            }
        }

        // this method ask the user for a position they want to delete.
        // and returns it. if thy enter an non integer value, we return -1
        public static int getDeletePosition()
        {
            // ask the user for a position.
            Console.Write("Choose an item to delete by entering its number: ");
            String input = Console.ReadLine();
            try
            {
                // try to convert their input to an int
                // we subtract 1 from their input because the index in the list starts at 0
                // but we displayed the list with numbers starting at 1.
                return Convert.ToInt32(input)-1;
            }
            catch
            {
                // reutrn -1 if we could not convert their input to an int
                return -1;
            }

        }

        // this method asks the user for the item they want to add to the inventory
        // and return their input
        public static Vehicle getNewItem()
        {
            //asks for type of vehicle for use in logic below
            Console.Write("Enter a type of vehicle (Car, Motorcycle, Truck)");
            string type = Console.ReadLine();

            //if unavailable vehicle type is entered prompts user to select available vehicle type
            if (type.ToLower() != "car" && type.ToLower() != "truck" && type.ToLower() != "motorcycle")
            {
                Console.Write("Incorect vehicle type entered. Please rnter available type of vehicle (Car, Motorcycle, Truck)");
                type = Console.ReadLine();
            }
            
            //while type is available type
            while(type.ToLower() == "car" || type.ToLower() == "truck" || type.ToLower() == "motorcycle")
            {
                // ask for an item, and return the input
                Console.Write("Enter a color: ");
                String color = Console.ReadLine();
                
                Console.Write("Enter a make: ");
                String make = Console.ReadLine();
                
                Console.Write("Enter a model: ");
                String model = Console.ReadLine();

                //depending on vehicle type asks user for relevent information then instantiated new vehicle of type selected
                if(type.ToLower() == "car")
                {
                    Console.Write("Is hatch back? (y/n) ");
                    String isHatchback = Console.ReadLine().ToLower();
                    Vehicle newOne = new Car(color, make, model, isHatchback == "y");
                    return newOne;
                }
                else if(type.ToLower() == "motorcycle")
                {
                    Console.Write("type of motorcycle? (Chopper, Sports Bike, Scooter, Motor Tricycle)");
                    String isTricycle = Console.ReadLine().ToLower();
                    Vehicle newOne = new Motorcycle(color, make, model, isTricycle == "motor tricycle");
                    return newOne;
                }
                else if (type.ToLower() == "truck")
                {
                    Console.Write("Is the truck 4 wheel drive? (y/n) ");
                    String is4WheelDrive = Console.ReadLine().ToLower();
                    Vehicle newOne = new Truck(color, make, model, is4WheelDrive == "y");
                    return newOne;
                }
            }
            return null;
        }

        // ask the user for a valid  input and reutrn it
        public static String getUserOption()
        {
            Console.Write("Choose a command (list, add, delete) ");
            return Console.ReadLine();
        }

        // print the inventory out to the console.
        public static void printInventory(List<Vehicle> inventory)
        {
            // if the inventory is empty, we print a message letting them know that
            // and exit the function
            if(inventory.Count == 0){
                Console.WriteLine("You dont have any inventory");
                return;
            }
            // we start at position 1, so the inventory has nice numbers
            // we should remeber that the user sees the numbers starting as 1,
            // so when asking for item to delete, we need to automatically
            // handle that the index into the list starts at 0.
            int index = 1;
            // loop through the inventory and print it to the console
            foreach (Vehicle item in inventory)
            {
                Console.WriteLine("{0} - {1}", index, item);
                index++;
            }
        }
    }

    // abstract vehicle class, cannot be  instantiated
    public abstract class Vehicle{
        String make;
        String model;
        String color;
        protected int numWheels;

        public Vehicle(String color, String make, String model, int numWheels){
            this.color = color;
            this.make = make;
            this.model = model;
            this.numWheels = numWheels;
        }
        public virtual int changeWheels()
        {
            return numWheels;
        }

        // overiding the ToString method from the base object class
        override
        public String ToString(){
            //gets current class type, converts it to a string then uses linq to split it at the . is Inheritence.class, prints the last part of the split, then adds a formated string with color make and model.
            String formated = this.GetType().ToString().Split('.').Last() + String.Format(", {0}, {1}, {2}", color, make, model);
            return formated;
        }
    }

    // extending the Vehicle class with a car subclass
    public  class Car: Vehicle{
        bool isHatchback;

        // calling the base constructor in vehicle
        public Car(String color, String make, String model, bool isHatchback):base(color, make, model, 4){
            this.isHatchback = isHatchback;
        }
    }

    // extending the Vehicle class with a motorcycle subclass
    public class Motorcycle: Vehicle{
        bool isTricycle;

        public Motorcycle(String color, String make, String model, bool isTricycle):base(color, make, model, 2){
            this.isTricycle = isTricycle;
            changeWheels();
        }
        
        //changes number of wheels if motorcycle is a three wheeled tricycle
        public override int changeWheels(){
            if(isTricycle)
            {
                this.numWheels = 3;
            }
            else
            {
                this.numWheels = 2;
            }
            return numWheels;
        }
    }
    // extending the Vehicle class with a truck subclass
    public class Truck: Vehicle{
        bool is4WheelDrive;

        public Truck(String color, String make, String model, bool is4WheelDrive):base(color, make, model, 4){
            this.is4WheelDrive = is4WheelDrive;
        }
    }
}