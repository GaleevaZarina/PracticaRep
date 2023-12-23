using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace pr4_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR4\numsTask3.txt"; // Создаем переменную fileName, в которой храним путь к файлу numsTask3
            StreamReader reader = new StreamReader(fileName); // Открываем поток для чтения файла numsTask3
            string line = ""; // Пустая строка line для хранения в нец прочитанных строк из файла
            
            while (!reader.EndOfStream) // Читаем файл
            {
                line = reader.ReadLine();
            } 
            reader.Close(); // Закрываем поток
            
            int[] numbers = line.Split(' ').Select(Int32.Parse).ToArray(); // Записываем чсила из строки в массив numbers
            int max = 0; // Создаем переменную max для хранения максимального элемента
            
            for (int i = 0; numbers[i] != 0; i++) // Поиск максимального элемента с массиве до 0
                if (numbers[i] > max)
                    max = numbers[i];
            
            int min = max; // Создаем переменную max для хранения минимального элемента
            
            for (int i = 0; numbers[i] != 0; i++) // Поиск минимального элемента в массиве до 0
                if (numbers[i] < min)
                    min = numbers[i];
            
            // Выводим отношение минимального и максимального элементов друг к другу
            Console.WriteLine($"max = {max}\nmin = {min}\nОтношение минимального и максимального элементов друг к другу {(double) min/max}");

            
        }
    }
}