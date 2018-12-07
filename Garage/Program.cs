using System;


public class Program
{

	public static void Main()
	{
        // instantiating a new instance of person, and  passing names to the constructor;
        Person Jill = new Person("Jill");
        Person Chris = new Person("Chris");
        Person Rebecca = new Person("Rebecca");
        Person Barry = new Person("Barry");

        // instantiating a new instance of car, and  passing colors to the constructor;
		Car blueCar = new Car("blue");
        Car redCar = new Car("red");
        Car greenCar = new Car("green");
        Car whiteCar = new Car("white");

        //Assigning Persons names to cars
        blueCar.Name = Jill.Name;
        redCar.Name = Barry.Name;
        greenCar.Name = Chris.Name;
        whiteCar.Name = Rebecca.Name;

        // instantiating a new instance of Garage class, and passing in a size of 4 to the constructor;
		Garage smallGarage = new Garage(4);

        // calling a method Parkcar of the smallGarage instance, with inputs of car color and parking space
		smallGarage.ParkCar(blueCar, 0);
        smallGarage.ParkCar(redCar, 1);
        smallGarage.ParkCar(greenCar, 2);
        smallGarage.ParkCar(whiteCar, 3);

        // printint out the cars attribute of the small garage
		Console.WriteLine(smallGarage.Cars);
	}
}

class Car
{ 
    // once the color is set i cant change it, outisde of this class
    public string Color {get; private set;}

    // Name can be set outside of class
    public string Name{get; set;}

    // Car constructor 
    public Car(String color)
    {
        this.Color = color;
    }
}

class Person
{
    //attribute for persons name
    public string Name { get; private set;}

    //Person constructor
    public Person(string name){
        this.Name = name;
    }   
}

class Garage
{
    // creates array of cars so they can be parked in the for loop down below
    public Car[] cars;

    // constructor , int of initial size
    public Garage(int initialSize)
    {
        // setting the size of this garage
    	Size = initialSize;
        // instantiating an array of Cars, of size initialsize
	    this.cars = new Car[initialSize];
    }

    //attribute , private for number of slots in the garage.
    public int Size { get; private set; }
    
    // a method that adds a car to the spot in the cars array
    public void ParkCar (Car car, int spot)
    {
        // what if there is a car already in the spot?
        // what if the spot passed in is outside the array?
        cars[spot] = car;
    }
    public string Cars {
		get {
            String carsString = "";
            //parks cars in spot 
			for (int i = 0; i < cars.Length; i++)
			{
				if (cars[i] != null) {
					carsString += String.Format("{2}'s {0} car is in spot {1}.", cars[i].Color, i, cars[i].Name);
                    carsString += "\n";
				}
			}
			return carsString;
		}
	}
}