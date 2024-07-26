using DoomsdayWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomsdayWarehouse.Service
{
    public interface IWarehouse<T> where T : InventoryItem
    {
        void AddItem(T item);
        bool Contains(string name);
        T? GetItem(string name);
        List<T?> GetItems();
        void RemoveItem(string name);
    }
    public class Warehouse<T>: IWarehouse<T> where T : InventoryItem, new()
    {
        private readonly string _filePath;

        public Warehouse(string filePath)
        {
            _filePath = filePath;
        }

        public void AddItem(T item)
        {
            string csvLine = item.ToCSV();
            try
            {
                File.AppendAllText(_filePath, csvLine);
            }
            catch (FileNotFoundException)
            {
               
            }
        }

        public bool Contains(string name)
        {
            var items = GetItems();
            return items.Any(item => item.Name == name);
        }

        public T? GetItem(string name)
        {
            var items = GetItems();
            return items.FirstOrDefault(item => item.Name == name);
           
        }

        public List<T?> GetItems()
        {
            try
            {
                var csvLines = File.ReadAllLines(_filePath);
                var items = csvLines.Select(line => new T().FromCSV(line) as T);
                return items.ToList();

            }
            catch (FileNotFoundException)
            {
                return new List<T?>();
            }
            
        }

        public void RemoveItem(string name)
        {
            var items = GetItems();
            if (items != null)
            {
                items.RemoveAll(x => x!.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                File.WriteAllText(_filePath, string.Empty);
                if (items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        AddItem(item!);
                    }
                }
            }
        }

    }

    
}
