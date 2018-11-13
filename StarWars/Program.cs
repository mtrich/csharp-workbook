using System;

public class Program
{
	public static void Main()
	{
		//instantiating new instances of each person and passing their names and alliance to the constructor
		Person leia = new Person("Leia", "Organa", "Rebel");
        Person luke = new Person("Luke", "Skywalker", "Rebel");
        Person han = new Person("Han", "Solo", "Rebel");
        Person darth = new Person("Darth", "Vader", "Imperial");
        Person emporer = new Person("Emporer", "Palpatine", "Imperial");
		//instantiating new instances of each ship and passing their names, type and size to the constructor
		Ship tie = new Ship("Tie", "Fighter", 2);
        Ship falcon = new Ship("Falcon", "Freigter", 2);
        Ship xWing = new Ship("X-Wing", "Fighter", 1);
		//instantiating new instances of each station and passing their names, alliance and size to the constructor
        Station rebelSpaceStation = new Station("Rebel Space Station", "Rebel",5);
        Station deathStar = new Station("Death Star", "Imperial",10);

		//entering people into ships
		falcon.EnterShip(leia, 0);
		falcon.EnterShip(han, 1);
		xWing.EnterShip(luke, 0);
		tie.EnterShip(darth, 0);
		tie.EnterShip(emporer, 1);

		//entering ships into stations
		deathStar.EnterStation(tie, 0);
		rebelSpaceStation.EnterStation(xWing, 0);
		rebelSpaceStation.EnterStation(falcon, 1);

		//printing roster of each station
		Console.WriteLine(deathStar.roster);
		Console.WriteLine(rebelSpaceStation.roster);
	}
}

class Person
{
	private string firstName;
	private string lastName;
	private string alliance;

	//person constructor
	public Person(string firstName, string lastName, string alliance)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.alliance = alliance;
	}

	//joins first and last name to create fullname
	public string FullName
	{
		get
		{
			return this.firstName + " " + this.lastName;
		}

		set
		{
			string[] names = value.Split(' ');
			this.firstName = names[0];
			this.lastName = names[1];
		}
	}
}

class Ship
{
	//creates array of passengers so they can be listed out
	public Person[] passengers;

	//ship constructor
	public Ship(string name, string type, int size)
	{
		this.ShipName = name;
		this.Type = type;
		this.passengers = new Person[size];
	}

	public string Type
	{
		get;
		set;
	}

	public string ShipName
	{
		get;
		set;
	}

	//enter ship method
	public void EnterShip(Person person, int seat)
	{
		this.passengers[seat] = person;
	}

	//exit ship method
	public void ExitShip(int seat)
	{
		this.passengers[seat] = null;
	}

	//returns string of each person in a ship
	public string Passengers
	{
		get
		{
			String passengersString = "";
			foreach (var person in passengers)
			{
				passengersString += String.Format(" {0},", person.FullName);
			}

			return passengersString.TrimEnd(',');
		}
	}
}
class Station
{
	//creates array of ships so they can be listed out
	public Ship[] ships;

	//station constructor
    public Station (string name, string alliance, int port)
    {
		this.Name = name;
		this.ships = new Ship[port];
		this.Alliance = alliance;
    }
    public string Name
	{
		get;
		set;
	}
    public string Alliance
	{
		get;
		set;
	}

	//method that allows ships to enter station
	public void EnterStation(Ship ship, int port)
	{
		this.ships[port] = ship;
	}

	//method that allows ships to exit station
	public void ExitStation(int port)
	{
		this.ships[port] = null;
	}

	//returns list of each ship in station and each person in each ship
	public string roster
	{
		get
		{
			Console.WriteLine("\n"+"*****"+this.Name+"*****");
			String shipsString = "";
			for(int i = 0; i < ships.Length; i++)
			{
				if (ships[i] != null){
					
					shipsString += String.Format("\nShip name: {0} - Ship Type: {1}\nPassengers:{2}\n",ships[i].ShipName,ships[i].Type,ships[i].Passengers);
				}
			}
			return shipsString.TrimEnd();
		}	
	}
}