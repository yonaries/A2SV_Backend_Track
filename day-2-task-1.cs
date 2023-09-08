using System;
using System.Collections.Generic;
public class Input
{

    public static string toGradeLetter(float score)
    {
        if (score >= 90)
        {
            return "A+";
        }
        else if (score >= 80)
        {
            return "A";
        }
        else if (score >= 75)
        {
            return "B+";
        }
        else if (score >= 65)
        {
            return "B";
        }
        else if (score >= 55)
        {
            return "C+";
        }
        else if (score >= 50)
        {
            return "C";
        }
        else if (score >= 40)
        {
            return "D";
        }
        return "F";
    }
    public class Subject
    {
        public string Name { get; set; } = "";
        public float score { get; set; }
    }
    public class Student
    {
        public string Name { get; set; } = "";
        public int TotalSubjects { get; set; } = 0;
        public List<Subject> subjects = new List<Subject>();
    }
    public static string ReadLine(string ask, Func<string, bool> condition)
    {
        Console.Write(ask);
        string read = Console.ReadLine();
        while (condition(read))
        {
            Console.WriteLine("Please enter a valid input");
            Console.Write(ask);
            read = Console.ReadLine();
        }
        return read;
    }
    public static void Main()
    {
        Student student = new Student();
        student.Name = ReadLine("Enter your name: ", (read) =>
        {
            return read.Equals("");
        });
        int readSubs = 0;
        ReadLine("Enter total count of subjects: ", (read) =>
        {
            return !int.TryParse(read, out readSubs) || readSubs < 1;
        });
        student.TotalSubjects = readSubs;
        int x = 1;
        while (x <= readSubs)
        {
            Subject sub = new Subject();
            sub.Name = ReadLine($"Enter subject {x} name: ", (read) =>
            {
                return read.Equals("");
            });
            float score = 0;
            ReadLine($"Enter subject {x} score(100%): ", (read) =>
            {
                return read.Equals("") || !float.TryParse(read, out score) || score < 0 || score > 100;
            });
            sub.score = score;
            student.subjects.Add(sub);
            x++;
        }
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine(student.Name + "" + " scores");
        Dictionary<string, float> grades = new Dictionary<string, float>();
        grades.Add("A+", 7.0f);
        grades.Add("A", 6.0f);
        grades.Add("B+", 5.0f);
        grades.Add("B", 4.0f);
        grades.Add("C+", 3.0f);
        grades.Add("C", 2.0f);
        grades.Add("D", 1.0f);
        grades.Add("F", 0.0f);
        float gradeSum = 0;
        foreach (Subject sub in student.subjects)
        {
            string g = toGradeLetter(sub.score);
            Console.WriteLine(sub.Name + " - " + g);
            gradeSum += grades[g];
        }
        Console.WriteLine("CGPA - " + (gradeSum / readSubs));

    }
}
