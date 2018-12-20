using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class Program
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student("Chris", "123-456-7891", "123 Delany", -2990));
            students.Add(new Student("Jill", "555-555-5555", "321 Racoon Dr.", -2500));
            students.Add(new Student("Jennifer", "210-867-5309", "5789 Stacy St.", 0));
            students.Add(new Student("Ronald", "1 (800) 244-6227", "110 North Carpenter Street", -500));

            IEnumerable<Student> negativeBalance = from currentStudent in students
                where currentStudent.Balance < 0
                select currentStudent;

            Console.WriteLine("all the students with a negative balance");
            foreach(Student currentStudent in negativeBalance){
                Console.WriteLine(currentStudent.Name);
            }
        }
    }

    public class Student
    {
        public string Name {get; set;}
        public string Phone {get; set;}
        public string Address {get; set;}
        public int Balance {get; set;}

        public Student (string name, string phone, string address, int balance)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Balance = balance;
        }
    }
}
