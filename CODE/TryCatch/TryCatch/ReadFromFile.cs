using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch
{
    internal class ReadFromFile
    {
        public string[] Read(string filePath)
        {
            try
            {
                string formatPath = $".\\..\\..\\{filePath}.txt";
                if (File.Exists(formatPath))
                {
                    return File.ReadAllLines(formatPath);

                }
                else
                {
                    Console.WriteLine("File was not found.");
                    return new string[0];
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("DirectoryNotFoundException");
                return new string[0];
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
                return new string[0];
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException");
                return new string[0];
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("NotSupportedException");
                return new string[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new string[0];
            }
        }
    }
}
