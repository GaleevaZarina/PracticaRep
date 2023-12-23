using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr3_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> nums = new List<int>(); // Создаем список nums, в котром будем хранить прочитанные числа из файла

            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR3\nums.txt"; // Создаем переменную fileName, чтобы хранить в ней путь к файлу nums   
            StreamReader reader = new StreamReader(fileName); // Создаем поток для чтения файла nums
            // С помощью цикла while построчно читаем файл nums
            while (!reader.EndOfStream) 
            {
                string line = reader.ReadLine(); // Создаем строку line, в которую запишем прочитанную из файла строку
                    
                nums = line.Split(' ').Select(int.Parse).ToList(); // Теперь отделяем дргу от друга полученные числа, используя split,
                                                                                // конвертируем их в int и записываем числа в список nums
            }
            reader.Close(); // Закрываем поток
            
            StreamWriter writer = new StreamWriter(fileName); // Создаем поток для записи информации в файл nums
            
            for (int i = 0; i < nums.Count; i++) // Проодимся по списку и делаем проверку
            {
                if (nums[i] % 2 != 0) // Если число нечетное, то записываем его в файл
                {
                    writer.Write($"{nums[i]} ");
                }
            }
            writer.Close(); // Закрываем поток
            
        }

    }
}