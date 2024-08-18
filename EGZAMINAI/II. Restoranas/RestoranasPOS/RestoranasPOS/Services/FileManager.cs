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
        private readonly string _clientsPath;

        public FileManager(string alkodrinksPath,
                           string nonalkodrinksPath,
                           string snacksPath,
                           string coldfoodPath,
                           string hotFoodPath,
                           string chequesPath,
                           string clientsPath)
        {
            _alkodrinksPath = alkodrinksPath;
            _nonalkodrinksPath = nonalkodrinksPath;
            _snacksPath = snacksPath;
            _coldFoodPath = coldfoodPath;
            _hotFoodPath = hotFoodPath;
            _chequesPath = chequesPath;
            _clientsPath = clientsPath;
        }
        #region Reading...

        // === ALKO GERIMAI - SKAITYMAS

        public Dictionary<string, decimal> ReadFrom_Alkodrinks()
        {
            try
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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
        }

        // === NE ALKO GERIMAI - SKAITYMAS
        public Dictionary<string, decimal> ReadFrom_Nonalkodrinks()
        {
            try
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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
        }

        // === UZKANDZIAI - SKAITYMAS
        public Dictionary<string, decimal> ReadFrom_Snacks()
        {
            try
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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
        }

        // === SALTIEJI - SKAITYMAS

        public Dictionary<string, decimal> ReadFrom_Coldfood()
        {
            try
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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
        }

        // === KARSTIEJI - SKAITYMAS
        public Dictionary<string, decimal> ReadFrom_Hotfood()
        {
            try
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
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
                return new Dictionary<string, decimal>
                {
                    { "Klaida", 0 }
                };
            }
        }

        // === CEKIAI - SKAITYMAS
        public string[] ReadFrom_Cheques()
        {
            try
            {
                return File.ReadAllLines(_chequesPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
                return new string[0];
            }
        }

        // REZERVACIJOS - SKAITYMAS
        public string[] ReadFrom_Reservations()
        {
            try
            {
                return File.ReadAllLines(_clientsPath);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
                return new string[0];
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
                return new string[0];
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
                return new string[0];
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
                return new string[0];
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
                return new string[0];
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
                return new string[0];
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
                return new string[0];
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
                return new string[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
                return new string[0];
            }
        }
        #endregion

        #region Writing...
        public void WriteTo_Reservations(string clientInfo)
        {
            try
            {
                File.AppendAllText(_clientsPath, clientInfo);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
            }
        }
        public void WriteTo_Cheques(List<string> chequesInfo, int type)
        {
            try
            {
                if (type == 1)
                {
                    File.AppendAllText(_chequesPath, "Kliento čekis\n");
                    foreach (var chequeLine in chequesInfo)
                    {
                        File.AppendAllText(_chequesPath, chequeLine);
                        File.AppendAllText(_chequesPath, "\n");
                    }
                    File.AppendAllText(_chequesPath, "=== SEPARATOR ===\n");
                }
                else if (type == 2)
                {
                    File.AppendAllText(_chequesPath, "Restorano čekis\n");
                    foreach (var chequeLine in chequesInfo)
                    {
                        File.AppendAllText(_chequesPath, chequeLine);
                        File.AppendAllText(_chequesPath, "\n");
                    }
                    File.AppendAllText(_chequesPath, "=== SEPARATOR ===\n");
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Klaida: Failo vieta nerasta.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Klaida: Failo kelias per ilgas.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Klaida: Failas nerastas.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Klaida: Netinkama metodo implementacija.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Klaida: Neturite teisių nuskaityti failą.");
            }
            catch (IOException)
            {
                Console.WriteLine("Klaida: Negalima nuskaityti failo.");
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Klaida: Failas tuščias.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Klaida: Negalima grąžinti tokio formato.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nenumatyta klaida: {ex.ToString()}");
            }
        }
        #endregion
    }
}
