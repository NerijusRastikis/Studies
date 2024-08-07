using RestoranasPOS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranasPOS.Services
{
    public class FileManager : IFileManager
    {
        private readonly string _alkodrinksPath;
        private readonly string _nonalkodrinksPath;
        private readonly string _snacksPath;
        private readonly string _coldFoodPath;
        private readonly string _hotFoodPath;
        private readonly string _chequesPath;

        public FileManager(string alkodrinksPath,
                           string nonalkodrinksPath,
                           string snacksPath,
                           string coldfoodPath,
                           string hotFoodPath,
                           string chequesPath)
        {
            _alkodrinksPath = alkodrinksPath;
            _nonalkodrinksPath = nonalkodrinksPath;
            _snacksPath = snacksPath;
            _coldFoodPath = coldfoodPath;
            _hotFoodPath = hotFoodPath;
            _chequesPath = chequesPath;
        }
        #region Reading...
        public Dictionary<string, decimal> ReadFrom_Alkodrinks()
        {
            var tempAlkodrinks = new Dictionary<string, decimal>();
            var alkoMenu = File.ReadAllLines(_alkodrinksPath);
            foreach (var alkodrink in alkoMenu)
            {
                var tempDish = alkodrink.Split(',');
                tempAlkodrinks.Add(tempDish[0], decimal.Parse(tempDish[1]));
            }
            return tempAlkodrinks;
        }
        public Dictionary<string, decimal> ReadFrom_Nonalkodrinks()
        {
            var tempNonalkodrinks = new Dictionary<string, decimal>();
            var nonalkoMenu = File.ReadAllLines(_nonalkodrinksPath);
            foreach (var nonalkodrink in nonalkoMenu)
            {
                var tempDish = nonalkodrink.Split(',');
                tempNonalkodrinks.Add(tempDish[0], decimal.Parse(tempDish[1]));
            }
            return tempNonalkodrinks;
        }
        public Dictionary<string, decimal> ReadFrom_Snacks()
        {
            var tempSnacks = new Dictionary<string, decimal>();
            var snacksMenu = File.ReadAllLines(_snacksPath);
            foreach (var snack in snacksMenu)
            {
                var tempDish = snack.Split(',');
                tempSnacks.Add(tempDish[0], decimal.Parse(tempDish[1]));
            }
            return tempSnacks;
        }
        public Dictionary<string, decimal> ReadFrom_Coldfood()
        {
            var tempColdFood = new Dictionary<string, decimal>();
            var coldfoodMenu = File.ReadAllLines(_coldFoodPath);
            foreach (var coldfood in coldfoodMenu)
            {
                var tempDish = coldfood.Split(',');
                tempColdFood.Add(tempDish[0], decimal.Parse(tempDish[1]));
            }
            return tempColdFood;
        }
        public Dictionary<string, decimal> ReadFrom_Hotfood()
        {
            var tempHotFood = new Dictionary<string, decimal>();
            var hotfoodMenu = File.ReadAllLines(_hotFoodPath);
            foreach (var hotfood in hotfoodMenu)
            {
                var tempDish = hotfood.Split(',');
                tempHotFood.Add(tempDish[0], decimal.Parse(tempDish[1]));
            }
            return tempHotFood;
        }
        public Dictionary<string, decimal> ReadFrom_Cheques()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Writing...

        #endregion
    }
}
