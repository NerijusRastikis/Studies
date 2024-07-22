namespace TryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1
            //while (true)
            //{
            //    try
            //    {
            //        System.Convert.ToDouble(Console.ReadLine());
            //    }
            //    catch (OverflowException)
            //    {
            //        Console.WriteLine("OverflowException");
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("FormatException");
            //    }
            //    catch (ArgumentIsNullException)
            //    {
            //        Console.WriteLine("ArgumentIsNullException");
            //    }
            //}
            #endregion
            #region 2
            //while (true)
            //{
            //    try
            //    {
            //        int[] arr = { 1, 2, 3, 4, 5 };
            //        for (int i = 0; i < arr.Length; i++)
            //        {
            //            Console.WriteLine(arr[i]);
            //        }
            //        Console.WriteLine(arr[7]);
            //    }
            //    catch (IOException)
            //    {
            //        Console.WriteLine("IOException");
            //    }
            //    catch (IndexOutOfRangeException)
            //    {
            //        Console.WriteLine("IndexOutOfRangeException");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //    finally
            //    {
            //        Console.WriteLine("Done with array.");
            //        Console.ReadKey();
            //    }
            //}
            #endregion
            #region 3
            //while (true)
            //{
            //    try
            //    {
            //        int[] arr = { 19, 0, 75, 52 };
            //        for (int i = 0; i < arr.Length; i++)
            //        {
            //            Console.WriteLine(arr[i] / arr[i + 1]);
            //        }
            //    }
            //    catch (IndexOutOfRangeException)
            //    {
            //        Console.WriteLine("IndexOutOfRangeException");
            //    }
            //    catch (DivideByZeroException)
            //    {
            //        Console.WriteLine("DivideByZeroException");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex);
            //    }
            //    finally
            //    {
            //        Console.WriteLine("End of Task 3");
            //        Console.ReadKey();
            //    }
            //}
            #endregion
            #region 4
            //while (true)
            //{
            //    string formatPath = "";
            //    try
            //    {
            //        formatPath = $".\\..\\file.txt";
            //        var wtf = new WriteToFile();
            //        wtf.Write("file");
            //        var rff = new ReadFromFile();
            //        Console.WriteLine("---------------------");
            //        foreach (var text in rff.Read("file"))
            //        {
            //            Console.WriteLine(text);
            //        }
            //        Console.WriteLine("---------------------");
            //        Console.Write("Darbas atliktas ");
            //        Console.ForegroundColor = ConsoleColor.Green;
            //        Console.Write("sėkmingai");
            //        Console.ResetColor();
            //        Console.WriteLine(".");
            //    }
            //    finally
            //    {
            //        if (File.Exists(formatPath))
            //        {
            //            Console.WriteLine("---------------------");
            //            var rff = new ReadFromFile();
            //            foreach (var text in rff.Read("file"))
            //            {
            //                Console.WriteLine(text);
            //            }
            //            Console.WriteLine("---------------------");
            //            Console.WriteLine("Pabaiga...");
            //            Console.ReadKey(true);
            //        }
            //    }
            //}
            #endregion
        }
    }
}
