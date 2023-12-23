using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr4_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR4\numsTask2.txt"; // Создаем переменную fileName, в которой храним путь к файлу numsTask2
            StreamReader reader = new StreamReader(fileName); // Открываем поток для чтения файла numsTask2
            string line = ""; // Создаем пустую строку line для хранения в ней прочитанных строк из файла
            
            while (!reader.EndOfStream) // Читаем файл
            {
                line = reader.ReadLine();
            } 
            reader.Close(); // Закрываем поток
            
            double[] numbers = line.Split(';').Select(double.Parse).ToArray(); // Записываем чсила из строки в массив numbers
            double sum = 0; // Создаем переменную sum для подсчета суммы положительных чисел до 0
            
            Console.WriteLine("Числа из файла numsTask2: ");
            for (int i = 0; numbers[i] != 0; i++) // Перебираем все числа до 0
                if (numbers[i] > 0) // Если число больше 0, то прибавляем его к сумме sum
                    sum += numbers[i];
           
            Console.WriteLine($"Сумма положительных элементов до 0 = {sum}"); // Вывод суммы
        }
    }
}