using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RKIS_PR6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Чтение слова из файла
            string fileName = @"C:\Users\public.COPP\Desktop\Galeeva624\RKIS_PR61\numsTask1.txt";
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    words = line.Split(' ').ToList();
                }
            }
            
            // Поиск слов нечетной длины и их вывод
            Console.WriteLine("Слова нечетной длины: ");
            for(int i = 0; i < words.Count; i++)
                if (words[i].Length % 2 != 0)
                    Console.WriteLine(words[i]);
            
        }
    }
}