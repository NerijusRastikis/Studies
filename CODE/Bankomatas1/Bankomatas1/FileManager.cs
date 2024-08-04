using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bankomatas1
{
    public class FileManager
    {
        private readonly string _path;
        private readonly string _pathLog;

        public FileManager(string path, string pathLog)
        {
            _path = path;
            _pathLog = pathLog;
        }

        public string[] ReadFromFile()
        {
            try
            {
                return File.ReadAllLines(_path);
            }
            catch (FileNotFoundException)
            {
                File.AppendAllText(_pathLog, $"Nera arba nenuskaitomas failas. {DateTime.Now}");
                return new string[0];
            }
            catch (PathTooLongException)
            {
                File.AppendAllText(_pathLog, $"FAILO KELIAS PER ILGAS! Data: {DateTime.Now}");
                return new string[0];
            }
            catch (Exception ex)
            {
                File.AppendAllText($".\\..\\..\\Logs.txt", $"{ex} {DateTime.Now}");
                return new string[0];
            }
        }
        public void WriteToFile(string content)
        {
            try
            {
                File.AppendAllText(_path, content);
            }
            catch(FileNotFoundException)
            {
                File.AppendAllText(_pathLog, $"NERANDAMAS FAILAS! Bandoma irasyti: {content}. Data: {DateTime.Now}");
            }
            catch (PathTooLongException)
            {
                File.AppendAllText(_pathLog, $"FAILO KELIAS PER ILGAS! Bandoma irasyti: {content}. Data: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                File.AppendAllText(_pathLog, $"NEAISKI KLAIDA! Bandoma irasyti: {content}. Data: {DateTime.Now}. Klaidos kodas: {ex}");
            }
        }
    }
}
