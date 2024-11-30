using P003.Models;

namespace P003.Services
{
    public class FileService : IFileService
    {
        string path = "C:\\Projects\\.NET\\CodeAcademy\\Studies\\CODE\\P003\\P003\\file.txt";
        public FileService()
        {

        }

        public bool WriteLine(string content) // Išsaugoti duomenis į failą
        {
            try
            {
                File.AppendAllText(path, content);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public string? ReadLine(int id) // Nuskaityti eilutę iš failo
        {
            try
            {
                var tempLines = File.ReadAllLines(path);
                return tempLines[id];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public string[] ReadAllLines() // Nuskaityti visas eilutes iš failo
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new string[0];
            }
        }
        public bool ReplaceLine(string content, int id) // Pakeisti eilutę faile
        {
            try
            {
                var tempLines = File.ReadAllLines(path);
                tempLines[id + 1] = content;
                File.WriteAllLines(path, tempLines);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool RemoveLine(int id) // Ištrinti eilutę iš failo
        {
            try
            {
                var tempLines = File.ReadAllLines(path).ToList();
                tempLines.RemoveAt(id + 1);
                File.WriteAllLines(path, tempLines);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool UserExists(string Id)
        {
            var listOfLines = File.ReadAllLines(path);
            return (int.Parse(Id) > 0 && int.Parse(Id) <= listOfLines.Length);
        }
    }
}
