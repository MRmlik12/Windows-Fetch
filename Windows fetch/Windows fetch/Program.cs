//Imported Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_fetch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Windows Fetch by MRmlik12 Github Link: https://github.com/MRmlik12/Windows-Fetch \n");
            Console.WriteLine();
            Console.Title = "Windows Fetch";
            var start = new Show();
            start.OnStart();
            Console.ReadKey();
        }
    }
}
