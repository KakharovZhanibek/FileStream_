using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachi
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

        static bool IsFib(List<int> numbers)
        {
            bool res = false;
            for (int i = 0; i < numbers.Count - 2; i++)
            {
                if (numbers[i] + numbers[i + 1] == numbers[i + 2])
                    res = true;
                else
                    return false;
            }
            return res;
        }

        static List<int> MakeFib(List<int> numbers)
        {
            int size = numbers.Count;
            for (int i = size - 1; i < (size * 2) - 1; i++)
            {
                numbers.Add(numbers[i - 1] + numbers[i]);
            }
            return numbers;
        }

        static void Main(string[] args)
        {
            string path = Path();

            string[] words;
            List<int> numbers = new List<int>();

            using (StreamReader sr = new StreamReader(path))
            {
                string text = sr.ReadLine();

                words = text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            bool isInt = false;

            foreach (string item in words)
            {
                int number;
                isInt = int.TryParse(item, out number);

                if (isInt)
                    numbers.Add(number);
            }

            if (IsFib(numbers))
            {
                numbers = MakeFib(numbers);

                foreach (int item in numbers)
                {
                    Console.Write(item + "  ");
                }

                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        string data = String.Join<int>(" ", numbers);

                        byte[] bytes = System.Text.Encoding.Unicode.GetBytes(data);

                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Последовательность не является рядом Фибоначчи");
            }
            Console.ReadLine();
        }
    }
}

