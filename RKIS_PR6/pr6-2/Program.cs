using System;
using System.Collections.Generic;
using System.IO;

namespace pr6_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Чтение слова из файла
            string fileName = @"C:\Users\public.COPP\Desktop\Galeeva624\RKIS_PR61\numsTask2.txt";
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    words.Add(line);
                }
            }

            // Составление из всех слов в листе одной большой строки. Слова разделяются пробелом
            string allWords = "";
            for(int i = 0; i < words.Count; i++)
                allWords = allWords + words[i] + " ";
            
            Console.WriteLine(allWords);
        }
    }
}