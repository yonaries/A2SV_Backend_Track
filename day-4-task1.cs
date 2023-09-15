using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Program
{
    public static string ReadLine(string prompt, Func<string, bool> condition)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (condition(input))
            {
                Console.WriteLine("Please enter a valid input");
            }
        } while (condition(input));
        return input;
    }

    public static int ReadNumber(string prompt)
    {
        int result = 0;
        ReadLine(prompt, (input) =>
        {
            return !int.TryParse(input, out result) || result < 0;
        });
        return result;
    }

    public static void Main()
    {
        TaskManager taskManager = new TaskManager();

        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("+++++++");
            Console.WriteLine("Menu: Add");
            Console.WriteLine("    1. Add Task");
            Console.WriteLine("View");
            Console.WriteLine("    2. All tasks");

            for (int i = 0; i < Enum.GetNames(typeof(TaskCategories)).Length; i++)
            {
                Console.WriteLine($"    {i + 3}. {Enum.GetNames(typeof(TaskCategories))[i]} tasks");
            }
            Console.WriteLine("0. Exit");

            choice = ReadNumber("Choice: ");
            Console.WriteLine("+++++++");

            if (choice == 1)
            {
                Console.WriteLine("Task Categories:");
                for (int i = 0; i < Enum.GetNames(typeof(TaskCategories)).Length; i++)
                {
                    Console.WriteLine($"    {i + 1}. {Enum.GetNames(typeof(TaskCategories))[i]}");
                }
                int categoryChoice = ReadNumber("Select a task category: ");

                if (categoryChoice >= 1 && categoryChoice <= Enum.GetNames(typeof(TaskCategories)).Length)
                {
                    TaskCategories selectedCategory = (TaskCategories)(categoryChoice - 1);
                    Task task = new Task
                    {
                        Name = ReadLine("Name: ", string.IsNullOrWhiteSpace),
                        Description = ReadLine("Description: ", string.IsNullOrWhiteSpace),
                        Category = selectedCategory,
                        IsCompleted = ReadNumber("1 for completed, 2 for incomplete: ") == 1
                    };
                    taskManager.AddTask(task);
                }
                else
                {
                    Console.WriteLine("Invalid category choice.");
                }
            }
            else if (choice == 2)
            {
                taskManager.DisplayTasks((task) => true);
            }
            else if (choice > 2 && choice < Enum.GetNames(typeof(TaskCategories)).Length + 3)
            {
                int categoryIndex = choice - 3;
                TaskCategories selectedCategory = (TaskCategories)categoryIndex;
                taskManager.DisplayTasks((task) => task.Category == selectedCategory);
            }
            else if (choice == 0)
            {
                Console.WriteLine("Goodbye");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }
}

class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategories Category { get; set; }
    public bool IsCompleted { get; set; }

    public override string ToString()
    {
        return $"{Name}-{Description}-{Category}-{IsCompleted}";
    }
}

enum TaskCategories
{
    Personal,
    Work,
    Errands,
    School
}

class TaskManager
{
    public List<Task> Tasks { get; private set; }
    private readonly string filePath = "tasks.txt";

    public TaskManager()
    {
        Tasks = new List<Task>();
        Read();
    }

    public void Write()
    {
        try
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                foreach (Task task in Tasks)
                {
                    writer.WriteLine(task.ToString());
                }
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }

    public void Read()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] taskLine = line.Split(new string[] { "-" }, StringSplitOptions.None);
                    if (taskLine.Length == 4)
                    {
                        TaskCategories cat = (TaskCategories)Enum.Parse(typeof(TaskCategories), taskLine[2], true);

                        Tasks.Add(new Task
                        {
                            Name = taskLine[0],
                            Description = taskLine[1],
                            Category = cat,
                            IsCompleted = bool.Parse(taskLine[3])
                        });
                    }
                }
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
        Write();
    }

    public void DisplayTasks(Func<Task, bool> filterFunction)
    {
        if (Tasks.Count == 0)
        {
            Console.WriteLine("No tasks yet");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Tasks");
            foreach (Task task in Tasks.Where(filterFunction).ToList())
            {
                Console.WriteLine("Name: " + task.Name);
                Console.WriteLine("Description: " + task.Description);
                Console.WriteLine("Category: " + task.Category);
                Console.WriteLine("IsCompleted: " + task.IsCompleted);
            }
        }
    }
}
