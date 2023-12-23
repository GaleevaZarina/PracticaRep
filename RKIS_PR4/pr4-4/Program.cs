using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr4_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"C:\Users\public.COPP\Desktop\numsTask4.txt"; // Переменная fileName, в которой храним путь к файлу numsTask4
            StreamReader reader = new StreamReader(fileName); // // Открываем поток для чтения файла numsTask4
            string line = ""; // Пустая строка line для хранения в нец прочитанных строк из файла
            
            while (!reader.EndOfStream)// Читаем файл
            {
                line = reader.ReadLine();
            }
            reader.Close(); // Закрываем поток

            int[] nums = line.Split(' ').Select(Int32.Parse).ToArray(); // Записываем числа из строки в массив nums
            int countRepeat = 0; // Переменная для подсчета повторяющихся чисела

            for (int i = 1; i < nums.Length; i++) // for для поиска одинаковых рядом стоящих чисел
                if (nums[i - 1] == nums[i])
                    countRepeat += 1;
            
            Console.WriteLine($"Количество одинаковых рядом стоящих чисел = {countRepeat}");

        }
    }
}