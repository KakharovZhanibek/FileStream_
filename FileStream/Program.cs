using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream_
{
    class Program
    {
        static string Path()
        {
            string path = @"";
            Console.WriteLine("Введите путь");
            path = Console.ReadLine();
            return path;
        }

        static void NSA()
        {
            /* С помощью класса StreamWriter записать в текстовый файл 
             * свое имя, фамилию и возраст. Каждая запись должна начинаться с новой строки*/
            string path = Path();
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Кахаров");
                    sw.WriteLine("Жанибек");
                    sw.WriteLine("18");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CountOfSymbols()
        {
            /* Написать программу, читающую побайтно заданный файл и 
             * подсчитывающую число появлений каждого из 256 возможных знаков.*/

            Dictionary<char, int> stat = new Dictionary<char, int>();

            string path = Path();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] bytes = new byte[fs.Length];

                    fs.Read(bytes, 0, bytes.Length);

                    string data = System.Text.Encoding.Unicode.GetString(bytes);//Unicode

                    //string data = "";

                    //StreamReader sr = new StreamReader(fs);

                    //data = sr.ReadToEnd();//ANSI

                    foreach (char symbol in data)
                    {
                        if (stat.ContainsKey(symbol))
                        {
                            stat[symbol]++;
                        }
                        else
                        {
                            stat[symbol] = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            foreach (KeyValuePair<char, int> item in stat)
            {
                Console.WriteLine(item.Key + "\t\t" + item.Value);
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            NSA();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
            CountOfSymbols();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
