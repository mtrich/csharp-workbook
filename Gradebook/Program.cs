using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradebook
{
    class Program
    {
        public static void Main()
        {
            Gradebook book = new Gradebook();
            book.run();
        }
    }

    //Creates dictionary with name as key and a list of grades as values.
    class book{
        Dictionary<string, Value> grades = new Dictionary<string,Value>();
    }

    class Gradebook
    {

        public void run(){
            Gradebook.getUserInput(new Dictionary<string, List<int>>());
        }
        
        public static void getUserInput(Dictionary<string, List<int>> grades){
            string status = "y";

            //promts user to add name that is added as key in dictionary. Then           
            while (status != "n" && status != "no")
            {
                //prompts user to add name
                Console.WriteLine("Please enter student name:");
                string name = Console.ReadLine();
                //runs loop to ask user for grades
                List<int> gradeList = Value.Add();
                //adds name and list of grades to dictionary
                grades.Add(name,gradeList);
                //asks user if they want to add another student thus repeating this while loop.
                Console.WriteLine("Would you like to enter a new student?(Y/N)");
                status = Console.ReadLine().ToLower();
            }
            //Writes each sudents Name, grade average, max grade, and min grade.
            foreach (var key in grades.Keys)
            {
                Console.WriteLine("Name: " + key);
                Console.WriteLine("Average: " +grades[key].Average());
                Console.WriteLine("Max: " + grades[key].Max());
                Console.WriteLine("Minimum: " + grades[key].Min());
            }
        }
    }
    class Value
    {
        //promts user to add grade and if they want to keep adding grades. Then returns the grades.
        public static List<int> Add()
        {
            var grades = new List<int>();
            string keepAdding = "y";
            while (keepAdding != "n"&&keepAdding != "no")
            {
                //prompts user for grade then adds input to list
                Console.WriteLine("Please enter a grade:");
                grades.Add(Convert.ToInt16(Console.ReadLine()));
                //asks user if they want to keep adding grades
                Console.WriteLine("Keep adding grades?(Y/N)");
                keepAdding = Console.ReadLine().ToLower();   
            }
            return grades;
        }
    }
}
