using System;

public static class Display
{
    private static Warehouse<FoodItem> _foodWarehouse;
    private static Warehouse<WeaponItem> _weaponWarehouse;
    private static Warehouse<MedicalItem> _medicalWarehouse;

    public static void InitializeWarehouses(Warehouse<FoodItem> foodWarehouse, Warehouse<WeaponItem> weaponWarehouse, Warehouse<MedicalItem> medicalWarehouse)
    {
        _foodWarehouse = foodWarehouse;
        _weaponWarehouse = weaponWarehouse;
        _medicalWarehouse = medicalWarehouse;
    }

    public static void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Doomsday Warehouse Inventory Management ===");
            Console.WriteLine("");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Add Weapon Item");
            Console.WriteLine("3. Add Medical Item");
            Console.WriteLine("4. Display All Food Items");
            Console.WriteLine("5. Display All Weapon Items");
            Console.WriteLine("6. Display All Medical Items");
            Console.WriteLine("7. Get Specific Item");
            Console.WriteLine("");
            Console.WriteLine("8. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("=== Add Food Item ===");
                    _foodWarehouse.AddItem();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("=== Add Weapon Item ===");
                    _weaponWarehouse.AddItem();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("=== Add Medical Item ===");
                    _medicalWarehouse.AddItem();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("=== Food Items ===");
                    DisplayItems(_foodWarehouse);
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("=== Weapon Items ===");
                    DisplayItems(_weaponWarehouse);
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("=== Medical Items ===");
                    DisplayItems(_medicalWarehouse);
                    break;
                case "7":
                    Console.Clear();
                    Console.WriteLine("=== Get Specific Item ===");
                    GetSpecificItem();
                    break;
                case "8":
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.ResetColor();
                    break;
            }
            PauseAndClear();
        }
    }

    private static void DisplayItems<T>(Warehouse<T> warehouse) where T : InventoryItem
    {
        var items = warehouse.GetItems();
        if (items.Count == 0)
        {
            Console.WriteLine("No items found.");
        }
        else
        {
            foreach (var item in items)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item.ToString());
                Console.ResetColor();
            }
        }
    }

    private static void GetSpecificItem()
    {
        Console.Write("Enter item name: ");
        var name = Console.ReadLine();

        var item = GetInventoryItem(name);
        if (item != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(item.ToString());
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Item not found.");
            Console.ResetColor();
        }
    }

    private static InventoryItem GetInventoryItem(string name)
    {
        var foodItem = _foodWarehouse.GetItem(name) as InventoryItem;
        if (foodItem != null)
            return foodItem;

        var weaponItem = _weaponWarehouse.GetItem(name) as InventoryItem;
        if (weaponItem != null)
            return weaponItem;

        var medicalItem = _medicalWarehouse.GetItem(name) as InventoryItem;
        if (medicalItem != null)
            return medicalItem;

        return null;
    }

    private static void PauseAndClear()
    {
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }
}
