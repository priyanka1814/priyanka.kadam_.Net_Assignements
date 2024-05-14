using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main(string[] args)
    {
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("Task List Application");
            Console.WriteLine("1. Create a task");
            Console.WriteLine("2. Read tasks");
            Console.WriteLine("3. Update a task");
            Console.WriteLine("4. Delete a task");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice:");
            
            int choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    ReadTasks();
                    break;
                case 3:
                    UpdateTask();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateTask()
    {
        Console.WriteLine("Enter the title of the task:");
        string title = Console.ReadLine();
        tasks.Add(title);
        Console.WriteLine("Task created successfully!");
    }

    static void ReadTasks()
    {
        Console.WriteLine("Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void UpdateTask()
    {
        Console.WriteLine("Enter the index of the task to update:");
        int index = int.Parse(Console.ReadLine());
        
        if (index >= 1 && index <= tasks.Count)
        {
            Console.WriteLine("Enter the new title of the task:");
            string newTitle = Console.ReadLine();
            tasks[index - 1] = newTitle;
            Console.WriteLine("Task updated successfully!");
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

    static void DeleteTask()
    {
        Console.WriteLine("Enter the index of the task to delete:");
        int index = int.Parse(Console.ReadLine());
        
        if (index >= 1 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Task deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
   
