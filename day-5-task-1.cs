using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json; // Install-Package Newtonsoft.Json

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public readonly int RollNumber;
    public string Grade { get; set; }

    public Student(string name, int age, int rollNumber, string grade)
    {
        Name = name;
        Age = age;
        RollNumber = rollNumber;
        Grade = grade;
    }
}

class StudentList<T> where T : Student
{
    private List<T> students = new List<T>();

    public void AddStudent(T student)
    {
        students.Add(student);
    }

    public T FindStudentByName(string name)
    {
        return students.FirstOrDefault(s => s.Name == name);
    }

    public T FindStudentById(int rollNumber)
    {
        return students.FirstOrDefault(s => s.RollNumber == rollNumber);
    }

    public void DisplayAllStudents()
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, RollNumber: {student.RollNumber}, Grade: {student.Grade}");
        }
    }

    public void SerializeToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(fileName, json);
    }

    public void DeserializeFromJson(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            students = JsonConvert.DeserializeObject<List<T>>(json);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var studentList = new StudentList<Student>();

        while (true)
        {
            Console.WriteLine("\nStudent Information Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Search by RollNumber");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Serialize to JSON");
            Console.WriteLine("6. Deserialize from JSON");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option (1-7): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter RollNumber: ");
                        int rollNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter Grade: ");
                        string grade = Console.ReadLine();
                        studentList.AddStudent(new Student(name, age, rollNumber, grade));
                        break;
                    case 2:
                        Console.Write("Enter Name to search: ");
                        string searchName = Console.ReadLine();
                        Student foundByName = studentList.FindStudentByName(searchName);
                        if (foundByName != null)
                        {
                            Console.WriteLine($"Student found: Name: {foundByName.Name}, Age: {foundByName.Age}, RollNumber: {foundByName.RollNumber}, Grade: {foundByName.Grade}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;
                    case 3:
                        Console.Write("Enter RollNumber to search: ");
                        int searchRollNumber = int.Parse(Console.ReadLine());
                        Student foundById = studentList.FindStudentById(searchRollNumber);
                        if (foundById != null)
                        {
                            Console.WriteLine($"Student found: Name: {foundById.Name}, Age: {foundById.Age}, RollNumber: {foundById.RollNumber}, Grade: {foundById.Grade}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;
                    case 4:
                        studentList.DisplayAllStudents();
                        break;
                    case 5:
                        Console.Write("Enter JSON file name to save: ");
                        string jsonFileName = Console.ReadLine();
                        studentList.SerializeToJson(jsonFileName);
                        Console.WriteLine("Data serialized to JSON.");
                        break;
                    case 6:
                        Console.Write("Enter JSON file name to load: ");
                        string loadFileName = Console.ReadLine();
                        studentList.DeserializeFromJson(loadFileName);
                        Console.WriteLine("Data loaded from JSON.");
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1-7).");
            }
        }
    }
}
