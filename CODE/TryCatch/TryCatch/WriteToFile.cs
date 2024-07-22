using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatch
{
    internal class WriteToFile
    {
        public string Name { get; set; } = "As";
        public string Kazkas { get; set; } = "16";
        public void Write(string fileName)
        {
            try
            {
                string[] strings = new string[] { Name, Kazkas };
                string formatPath = $".\\..\\{fileName}.txt";
                File.AppendAllLines(formatPath, strings);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("DirectoryNotFoundException");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("NotSupportedException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

    }
}
