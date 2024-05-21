using System;
using System.Collections.Generic;

public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Item(int id, string name, decimal price, int quantity)
    {
        ID = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {ID}, Name: {Name}, Price: {Price}, Quantity: {Quantity}");
    }
}

public class Inventory
{
    
    private List<Item> items = new List<Item>();

    public void AddItem(int id, string name, decimal price, int quantity)
    {
        if (items.Exists(i => i.ID == id))
        {
            Console.WriteLine("Item with this ID already exists.");
        }
        else
        {
            items.Add(new Item(id, name, price, quantity));
            Console.WriteLine("Item added successfully.");
        }
    }

    public void DisplayAllItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("No items in the inventory.");
        }
        else
        {
            foreach (var item in items)
            {
                item.Display();
            }
        }
    }

    public Item FindItemByID(int id)
    {
        return items.Find(i => i.ID == id);
    }

    public void UpdateItem(int id, string name, decimal price, int quantity)
    {
        Item item = FindItemByID(id);
        if (item != null)
        {
            item.Name = name;
            item.Price = price;
            item.Quantity = quantity;
            Console.WriteLine("Item updated successfully.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    public void DeleteItem(int id)
    {
        Item item = FindItemByID(id);
        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine("Item deleted successfully.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Inventory inventory = new Inventory();

        while (true)
        {
            Console.WriteLine("\nSelect operation:");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Display all items");
            Console.WriteLine("3. Find item by ID");
            Console.WriteLine("4. Update item");
            Console.WriteLine("5. Delete item");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddItemDynamically(inventory);
                    break;
                case 2:
                    Console.WriteLine("\nAll Items:");
                    inventory.DisplayAllItems();
                    break;
                case 3:
                    FindItemByIDDynamically(inventory);
                    break;
                case 4:
                    UpdateItemDynamically(inventory);
                    break;
                case 5:
                    DeleteItemDynamically(inventory);
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public static void AddItemDynamically(Inventory inventory)
    {
        Console.Write("Enter ID of the item: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input for ID. Please enter a number.");
            return;
        }

        Console.Write("Enter name of the item: ");
        string name = Console.ReadLine();

        Console.Write("Enter price of the item: ");
        decimal price;
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input.. Please enter a number.");
            return;
        }

        Console.Write("Enter quantity of the item: ");
        int quantity;
        if (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid input.. Please enter a number.");
            return;
        }

        inventory.AddItem(id, name, price, quantity);
    }

    public static void FindItemByIDDynamically(Inventory inventory)
    {
        Console.Write("Enter ID of the item to find: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input.. Please enter a number.");
            return;
        }

        Item item = inventory.FindItemByID(id);
        if (item != null)
        {
            Console.WriteLine("Item Found:");
            item.Display();
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    public static void UpdateItemDynamically(Inventory inventory)
    {
        Console.Write("Enter ID of the item to update: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input.. Please enter a number.");
            return;
        }

        Console.Write("Enter new name of the item: ");
        string name = Console.ReadLine();

        Console.Write("Enter new price of the item: ");
        decimal price;
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid input.. Please enter a number.");
            return;
        }

        Console.Write("Enter new quantity of the item: ");
        int quantity;
        if (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid input.. Please enter a number.");
            return;
        }

        inventory.UpdateItem(id, name, price, quantity);
    }

    public static void DeleteItemDynamically(Inventory inventory)
    {
        Console.Write("Enter ID of the item to delete: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input.. Please enter a number.");
            return;
        }

        inventory.DeleteItem(id);
    }
}
