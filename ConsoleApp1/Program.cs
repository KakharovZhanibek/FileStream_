using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum
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
        static void Main(string[] args)
        {
            string path = Path();

            string[] words;
            List<int> numbers = new List<int>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string text = sr.ReadLine();

                    words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    bool isInt = false;

                    foreach (string item in words)
                    {
                        int number;
                        isInt = int.TryParse(item, out number);

                        if (isInt)
                            numbers.Add(number);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            numbers.Add(numbers[0] + numbers[1]);

            Console.WriteLine(numbers[0] + " + " + numbers[1] + " = " + numbers[2]);

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    string data = (numbers[0] + " + " + numbers[1] + " = " + numbers[2]).ToString();

                    byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);

                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
