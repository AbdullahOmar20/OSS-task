using System;
using System.Security.Cryptography;

namespace newProject;
public  class Person
{
    private string _name;
    private int _age;

    public string Name
    {
        get { return _name; }
        set
        {
            if (value == null || value == "" || value.Length == 32)
            {
                throw new Exception("Invalid Name");
            }

            _name = value;
        }
    }

    public int Age
    {
        get { return _age;}
        set
        {
            if (value <= 0 || value >= 128)
            {
                throw new Exception("Invalid Age");
            }

            _age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void print()
    {
        Console.WriteLine($"Name: {Name}, Age:{Age}");   
    }
}

public class Student : Person
{
    private int _year;
    private float _gpa;

    public int Year
    {
        get {return _year;}
        set
        {
            if (value < 1 || value > 5)
            {
                throw new Exception("Invalid year");
            }

            _year = Year;
        }

    }

    public float GPA
    {
        get {return _gpa;}
        set
        {
            if (value < 0 || value > 4)
            {
                throw new Exception("Invalid Gpa");
            }

            _gpa = GPA;
        }
    }

    public Student(string name, int age, int year, float gpa)
    :base(name,age)
    {
        Year = year;
        GPA = gpa;
    }

    public override void print()
    {
        Console.WriteLine($"Name: {Name} Age: {Age} Year: {Year} GPA: {GPA}");   
    }
}

public class Staff : Person
{
    private double _salary;
    private int _joinyear;

    public double Salary
    {
        get { return _salary;}
        set
        {
            if (value < 0 || value > 12000)
            {
                throw new Exception("Invalid salary");
            }

            _salary = Salary;
        }
    }

    public int joinYear
    {
        get { return _joinyear;}
        set
        {
            var d = DateTime.Today;
            var birthYear = d.Year - Age;
            if ((value-birthYear)<21)
            {
                throw new Exception("Invalid Join Year");
            }

            _joinyear = joinYear;
        }
    }

    public Staff(string name, int age, double salary, int joinyear)
    :base(name,age)
    {
        Salary = salary;
        joinYear = joinyear;
    }

    public override void print()
    {
        Console.WriteLine($"My name{Name}, My age:{Age}, my salary:{Salary}");
    }
}
public class database
{
    public int curr ;
    public Person[] person = new Person[50];

    public void AddStudent(Student student)
    {
        person[curr++] = student;
    }

    public void AddStaff(Staff staff)
    {
        person[curr++] = staff;
    }

    public void AddPerson(Person per)
    {
        person[curr++] = per;
    }

        public void PrintAll()
    {
        foreach (var item in person)
        {
            item?.print();
        }
    }
}

public class program
{
    public static void Main()
    {
        var database = new database();

       
        Console.WriteLine("Enter option 1)to add student  2)to add staff  3)to add person  4)to print all 0) to stop:");
        var option = Convert.ToInt32(Console.ReadLine());
        while (true)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("Done");
                    return;
                case 1:
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Age: ");
                    var age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Year: ");
                     var year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Gpa: ");
                    var gpa = Convert.ToSingle(Console.ReadLine());
                    try
                    {
                        var student = new Student(name, age, year, gpa);
                        database.AddStudent(student);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                    Console.WriteLine(
                        "Enter option 1)to add student  2)to add staff  3)to add person  4)to print all 0) to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Name: ");
                    var name2 = Console.ReadLine();
                    Console.Write("Age: ");
                    var age2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Salary: ");
                    var salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Join Year: ");
                    var joinyear = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var staff = new Staff(name2, age2, salary, joinyear);
                        database.AddStaff(staff);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                       
                    }
                    Console.WriteLine(
                        "Enter option 1)to add student  2)to add staff  3)to add person  4)to print all 0) to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Name: ");
                    var name3 = Console.ReadLine();
                    Console.Write("Age: ");
                    var age3 = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var person = new Person(name3,age3 );
                        database.AddPerson(person);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                    
                    Console.WriteLine(
                        "Enter option 1)to add student  2)to add staff  3)to add person  4)to print all 0) to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    
                    break;
                case 4:
                    database.PrintAll();
                    Console.WriteLine(
                        "Enter option 1)to add student  2)to add staff  3)to add person  4)to print all 0) to stop:");
                    option = Convert.ToInt32(Console.ReadLine());

                    break;
                default:
                    return;

            }
        }
    }
}