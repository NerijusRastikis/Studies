using ProjectATM.Models;
using ProjectATM.Repositories.Interfaces;

namespace ProjectATM.Repositories
{
    public class ATMRepository : IATMRepository
    {
        private readonly string _fileName;
        private readonly List<AutomatedTellerMachine> _atms;

        public ATMRepository(string fileName)
        {
            _fileName = fileName;
            _atms = LoadATMs();
        }

        public List<AutomatedTellerMachine> LoadATMs()
        {
            var atms = new List<AutomatedTellerMachine>();

            if (!File.Exists(_fileName))
                return atms;

            try
            {
                var lines = File.ReadAllLines(_fileName);

                foreach (var line in lines)
                {
                    var parts = line.Split(';');

                    if (parts.Length != 3)
                        continue;

                    var bills = new Dictionary<int, int>();

                    var billParts = parts[2].Split(',');
                    foreach (var billPart in billParts)
                    {
                        var billData = billPart.Split(':');
                        if (billData.Length == 2 &&
                            int.TryParse(billData[0], out var denomination) &&
                            int.TryParse(billData[1], out var count))
                        {
                            bills[denomination] = count;
                        }
                    }

                    if (int.TryParse(parts[0], out var atmId))
                    {
                        atms.Add(new AutomatedTellerMachine
                        {
                            Id = atmId,
                            Location = parts[1],
                            Bills = bills
                        });
                    }
                    else
                    {
                        Console.WriteLine($"Klaida! Blogas formatas faile: {_fileName}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Klaida! Klaida skaitant faila: {_fileName} {e.Message}");
            }

            return atms;
        }

        public AutomatedTellerMachine? GetATM(int id)
        {
            return _atms.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AutomatedTellerMachine> GetATMs()
        {
            return _atms;
        }

        public void Save(List<AutomatedTellerMachine> atms)
        {
            var lines = atms.Select(atm =>
                $"{atm.Id};{atm.Location};{string.Join(",", atm.Bills.Select(b => $"{b.Key}:{b.Value}"))}");
            File.WriteAllLines(_fileName, lines);
        }

        public void UpdateATM(AutomatedTellerMachine atm)
        {
            var index = _atms.FindIndex(x => x.Id == atm.Id);
            if (index != -1)
            {
                _atms[index] = atm;
                Save(_atms);
            }
            else
            {
                Console.WriteLine($"Klaida! Bankomatas su ID: {atm.Id} nerastas");
            }
        }

    }
}
