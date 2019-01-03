using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtComparerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo[] files = new FileInfo[2];
            /*
            for (int i = 0; i < files.Length;)
             {
                 Console.WriteLine($"Input file {i+1}: ");
                 files[i] = new FileInfo(Console.ReadLine());
                 if(files[i].Exists) i++;
                 else Console.WriteLine("File doesn't exist, try again.");
             }*/
            files[0] = new FileInfo("old.txt");
            files[1] = new FileInfo("new.txt");

            Comparer comparer = new Comparer();

            List<string[]> listaZmian = comparer.Compare(files);
            foreach (string[] linia in listaZmian)
            {
                foreach (string pole in linia)
                {
                    if(String.IsNullOrEmpty(pole)) continue;
                    Console.WriteLine(pole);
                }
            }
            Console.ReadLine();
        }
    }
}
