using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject1
{
    public class Warehouse<T> where T : InventoryItem
    {
        #region SETTING PATHS
        string pathW = "C:\\Users\\nerij\\Documents\\GitHub\\dotnet\\MiniProject1\\MiniProject1\\weapons.csv";
        string pathM = "C:\\Users\\nerij\\Documents\\GitHub\\dotnet\\MiniProject1\\MiniProject1\\medicine.csv";
        string pathF = "C:\\Users\\nerij\\Documents\\GitHub\\dotnet\\MiniProject1\\MiniProject1\\food.csv";
        #endregion
        int choice = 0;

        public void AddItem(T item)
        { 
            string addItemMenu = @"         ADD ITEM
            
            Please select category:
            1. Food
            2. Weapon
            3. Medicine";
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 3))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("UNACCEPTABLE INPUT!");
                Console.ResetColor();
                Console.WriteLine(addItemMenu);
            }
            string formatedInput = "";
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("ADD FOOD: ");
                    Console.WriteLine("");
                    var edible1 = new FoodItem();
                    Console.Write("Name: ");
                    edible1.Name = Console.ReadLine();
                    Console.Write("Weight: ");
                    edible1.Weight = double.Parse(Console.ReadLine());
                    Console.Write("Expiration date (YYYY-MM-DD): ");
                    edible1.Expire = new DateTime(int.Parse(Console.ReadLine()));
                    Console.Write("Calories: ");
                    edible1.Calories = int.Parse(Console.ReadLine());
                    formatedInput = $"{edible1.Name},{edible1.Weight},{edible1.Expire},{edible1.Calories}";
                    File.AppendAllText(pathF, formatedInput);
                    Console.WriteLine("");
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Food added successfully!");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("ADD WEAPON: ");
                    Console.WriteLine("");
                    var killable1 = new WeaponItem();
                    Console.Write("Name: ");
                    killable1.Name = Console.ReadLine();
                    Console.Write("Weight: ");
                    killable1.Weight = double.Parse(Console.ReadLine());
                    Console.Write("Damage: ");
                    killable1.Damage = double.Parse(Console.ReadLine());
                    formatedInput = $"{killable1.Name},{killable1.Weight},{killable1.Damage}";
                    File.AppendAllText(pathW, formatedInput);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Weapon added successfully!");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("ADD MEDICINE: ");
                    Console.WriteLine("");
                    var healable1 = new MedicalItem();
                    Console.Write("Name: ");
                    healable1.Name = Console.ReadLine();
                    Console.Write("Weight: ");
                    healable1.Weight = double.Parse(Console.ReadLine());
                    Console.Write("Expiration date (YYYY-MM-DD): ");
                    healable1.Expire = new DateTime(int.Parse(Console.ReadLine()));
                    Console.Write("Cures from: ");
                    healable1.CuresFrom = Console.ReadLine();
                    formatedInput = $"{healable1.Name},{healable1.Weight},{healable1.Expire},{healable1.CuresFrom}";
                    File.AppendAllText(pathM, formatedInput);
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Medicine added successfully!");
                    Console.ResetColor();
                    break;
                default:
                    throw new Exception("Something went wrong when adding item.");
            }
        }
        public List<string> GetItems()
        {
            Console.Clear();
            string[] tempMedicineList = File.ReadAllLines(pathM);
            string[] tempFoodList = File.ReadAllLines(pathF);
            string[] tempWeaponsList = File.ReadAllLines(pathW);
            string formatedLine = "";
            var items = new List<string>();
            Console.WriteLine("DISPLAY ITEMS");
            Console.WriteLine("");
            Console.WriteLine("CATEGORY: MEDICINE");
            Console.WriteLine("NAME\t\t\tWEIGHT\t\tEXPIRATION DATE\t\tPURPOSE");
            Console.WriteLine("----------------------------------------------------------------------------");
            // DISPLAY MEDICINE
            foreach (var item in tempMedicineList)
            {
                string[] tempFormatedLine = item.Split(",");
                foreach (var tempFormatedWord in tempFormatedLine)
                {
                    Console.Write($"{tempFormatedWord}\t\t");
                    formatedLine = $"{tempFormatedWord} ";
                }
                Console.WriteLine("");
                items.Add(formatedLine);
            }
            // DISPLAY FOOD
            Console.WriteLine("");
            Console.WriteLine("CATEGORY: FOOD");
            Console.WriteLine("NAME\t\t\tWEIGHT\t\tEXPIRATION DATE\t\tCALORIES");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var item in tempFoodList)
            {
                string[] tempFormatedLine = item.Split(",");
                foreach (var tempFormatedWord in tempFormatedLine)
                {
                    Console.Write($"{tempFormatedWord}\t\t");
                    formatedLine = $"{tempFormatedWord} ";
                }
                Console.WriteLine("");
                items.Add(formatedLine);
            }
            // DISPLAY WEAPONS
            Console.WriteLine("");
            Console.WriteLine("CATEGORY: WEAPONS");
            Console.WriteLine("NAME\t\t\tWEIGHT\t\tDAMAGE");
            Console.WriteLine("----------------------------------------------------------------------------");
            foreach (var item in tempWeaponsList)
            {
                string[] tempFormatedLine = item.Split(",");
                foreach (var tempFormatedWord in tempFormatedLine)
                {
                    Console.Write($"{tempFormatedWord}\t\t");
                    formatedLine = $"{tempFormatedWord} ";
                }
                Console.WriteLine("");
                items.Add(formatedLine);
            }
            Console.WriteLine("");
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("ENTER ");
            Console.ResetColor();
            Console.WriteLine("to return to menu");
            Console.ReadLine();
            return items;
        }
        public T GetItem()
        {
            throw new NotImplementedException();
        }
        public void MenuNavigator()
        {
            string menu = @"WELCOME TO WAREHOUSE APP!

1. Add item
2. View items
3. Search item

9. Exit";
            Console.WriteLine(menu);
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine(menu);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("UNACCEPTABLE SELECTION! Please repeat: ");
                Console.ResetColor();
            }
            switch (choice)
            {
                case 1:
                    AddItem();
                    break;
                case 2:
                    GetItems();
                    choice = 0;
                    Console.Clear();
                    MenuNavigator();
                    break;
                case 3:
                    GetItem();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("ERROR in Switch of MenuNavigator()!");
            }
        }
    }
}
