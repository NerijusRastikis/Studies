using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public class Smalsumas
    {
        public void OptimizacijosUzdavinys(string path, int samples)
        {
            var timer = new Stopwatch();
            Console.WriteLine("Tikriname File.ReadAllLines efektyvumą.");
            timer.Start();
            for (int i = 0; i < samples; i++)
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    // do something
                }
            }
            timer.Stop();
            var readAllLinesTime = timer.ElapsedMilliseconds;
            Console.WriteLine($"File.ReadAllLines užtruko: {readAllLinesTime}");

            Console.WriteLine("Tikriname File.ReadLines efektyvumą.");
            timer.Restart();
            timer.Start();
            for (int i = 0; i < samples; i++)
            {
                var lines = File.ReadLines(path);
                foreach (var line in lines)
                {
                    // do something
                }
            }
            timer.Stop();
            var readLinesTime = timer.ElapsedMilliseconds;
            Console.WriteLine($"File.ReadLines užtruko: {readAllLinesTime}");
            timer.Restart();
            Console.WriteLine("Tikriname File.ReadLines kartu su ToArray() efektyvumą");
            timer.Start();
            for (int i = 0; i < samples; i++)
            {
                var lines = File.ReadLines(path).ToArray();
                foreach (var line in lines)
                {
                    // do something
                }
            }
            timer.Stop();
            var readLinesTime2 = timer.ElapsedMilliseconds;
            Console.WriteLine($"File.ReadLines su ToArray() užtruko: {readLinesTime2}");
            timer.Restart();
            Console.WriteLine("Tikriname File.ReadAllText efektyvumą, o po to splitiname");
            timer.Start();
            for (int i = 0; i < samples; i++)
            {
                var lines = File.ReadAllText(path).Split("\n");
                foreach (var line in lines)
                {
                    // do something
                }
            }
            timer.Stop();
            var readLinesTime3 = timer.ElapsedMilliseconds;
            Console.WriteLine($"File.ReadAllText su Split() užtruko: {readLinesTime3}");
        }
    }
}
