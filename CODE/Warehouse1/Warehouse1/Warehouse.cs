using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;

public class Warehouse<T> where T : InventoryItem
{
    private readonly string _filePath;
    private readonly List<T> _items;

    public Warehouse(string filePath)
    {
        // Priima filePath kur yra failai
        _filePath = filePath;
        _items = new List<T>();
        LoadItemsFromFile();
    }

    public void AddItem()
    {
        var item = CreateItem();
        if (item != null)
        {
            _items.Add(item);
            SaveItemsToFile();
        }
    }

    private T CreateItem()
    {
        if (typeof(T) == typeof(FoodItem))
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter weight (kg): ");
            var weight = double.Parse(Console.ReadLine());
            Console.Write("Enter expiration date (yyyy-MM-dd): ");
            var expirationDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.Write("Enter calories: ");
            var calories = int.Parse(Console.ReadLine());

            return (T)Activator.CreateInstance(typeof(T), name, weight, expirationDate, calories);
        }
        else if (typeof(T) == typeof(WeaponItem))
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter weight (kg): ");
            var weight = double.Parse(Console.ReadLine());
            Console.Write("Enter damage: ");
            var damage = int.Parse(Console.ReadLine());

            return (T)Activator.CreateInstance(typeof(T), name, weight, damage);
        }
        else if (typeof(T) == typeof(MedicalItem))
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter weight (kg): ");
            var weight = double.Parse(Console.ReadLine());
            Console.Write("Enter expiration date (yyyy-MM-dd): ");
            var expirationDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.Write("Enter diseases: ");
            var diseases = Console.ReadLine();

            return (T)Activator.CreateInstance(typeof(T), name, weight, expirationDate, diseases);
        }

        return null;
    }

    public List<T> GetItems()
    {
        // Grazina sarasa is LoadItemsFromFile()
        return _items;
    }

    public T GetItem(string name)
    {
        // ChatGPT
        return _items.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    private void SaveItemsToFile()
    {
        using (var writer = new StreamWriter(_filePath))
        {
            foreach (var item in _items)
            {
                writer.WriteLine(item.ToString());
            }
        }
    }

    private void LoadItemsFromFile()
    {
        // Jei neegzistuoja failas - nieko nedaro
        if (!File.Exists(_filePath)) return;

        // Nuskaito faila
        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(", ");
            if (typeof(T) == typeof(FoodItem))
            {
                // Sudeda i masyva
                var name = parts[0];
                var weight = double.Parse(parts[1].Replace("kg", ""));
                var expirationDate = DateTime.Parse(parts[2]);
                var calories = int.Parse(parts[3].Replace("kcal", ""));
                // Sukelia i Generics sarasa
                _items.Add((T)Activator.CreateInstance(typeof(T), name, weight, expirationDate, calories));
            }
            else if (typeof(T) == typeof(WeaponItem))
            {
                var name = parts[0];
                var weight = double.Parse(parts[1].Replace("kg", ""));
                var damage = int.Parse(parts[2].Replace("dmg", ""));
                _items.Add((T)Activator.CreateInstance(typeof(T), name, weight, damage));
            }
            else if (typeof(T) == typeof(MedicalItem))
            {
                var name = parts[0];
                var weight = double.Parse(parts[1].Replace("kg", ""));
                var expirationDate = DateTime.Parse(parts[2]);
                var diseases = parts[3];
                _items.Add((T)Activator.CreateInstance(typeof(T), name, weight, expirationDate, diseases));
            }
        }
    }
}
