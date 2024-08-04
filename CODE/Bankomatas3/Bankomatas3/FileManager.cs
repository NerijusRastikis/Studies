using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bankomatas3
{
    public class FileManager : IFileManager
    {
        private readonly string _pathUsers;
        private readonly string _pathATM;
        private readonly string _pathLogs;

        public FileManager(string pathUsers, string pathATM, string pathLogs)
        {
            _pathUsers = pathUsers;
            _pathATM = pathATM;
            _pathLogs = pathLogs;
        }

        public string[] ReadFromATMFile()
        {
            try
            {
                return File.ReadAllLines(_pathATM);
            }
            catch (PathTooLongException)
            {
                try
                {
                    File.AppendAllText(_pathLogs, $"Failo vieta per ilga. {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Nenumatyta klaida! {ex.Message} {DateTime.Now}");
                }
                return new string[0];
            }
            catch (IOException)
            {
                try
                {
                    File.AppendAllText(_pathLogs, $"Nepavyko nuskaityti failo. {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Nenumatyta klaida! {ex.Message} {DateTime.Now}");
                }
                return new string[0];
            }
        }

        public string[] ReadFromUsersFile()
        {
            try
            {
                return File.ReadAllLines(_pathUsers);
            }
            catch (PathTooLongException)
            {
                try
                {
                    File.AppendAllText(_pathLogs, $"Failo vieta per ilga. {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Nenumatyta klaida! {ex.Message} {DateTime.Now}");
                }
                return new string[0];
            }
            catch (IOException)
            {
                try
                {
                    File.AppendAllText(_pathLogs, $"Nepavyko nuskaityti failo. {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Nenumatyta klaida! {ex.Message} {DateTime.Now}");
                }
                return new string[0];
            }
        }

        public void WriteToATMFile(string content)
        {
            var index = 0;
            var lines = File.ReadAllLines(_pathATM);
            try
            {
                string[] target = content.Split(',').ToArray();
                foreach (var line in lines)
                {
                    var dicedLine = line.Split(',');
                    if (dicedLine[0] == target[0])
                    {
                        continue;
                    }
                    else index++;
                }
                lines[index] = content;
                File.WriteAllLines(_pathATM, lines);
            }
            catch (IOException)
            {
                File.AppendAllText(_pathLogs, $"Klaida! Negalima irasyti failo! {DateTime.Now}");
            }
            catch (Exception ex)
            {
                File.AppendAllText(_pathLogs, $"Nenumatyta klaida! {ex.Message} {DateTime.Now}");
            }
        }

        public void WriteToUsersFile(string[] content, string cardNumber)
        {
            var index = 0;
            try
            {
                var lines = File.ReadAllLines(_pathATM);
                foreach (var line in lines)
                {
                    var dicedLine = line.Split(',');
                    if (dicedLine[0] == cardNumber)
                    {
                        continue;
                    }
                    else index++;
                }
                //lines[index] = content;
                File.WriteAllLines(_pathATM, content);
            }
            catch (IOException)
            {
                File.AppendAllText(_pathLogs, $"Klaida! Nepavyko irasyti i faila. {DateTime.Now}");
            }
            catch (Exception ex)
            {
                File.AppendAllText(_pathLogs, $"Nenumatyta klaida! {ex.Message} {DateTime.Now}");
            }
        }

    }
}
