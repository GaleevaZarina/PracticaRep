using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RKIS_PR3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\input.txt"; // Создаем переменную fileName, чтобы хранить в ней путь к файлу input          
            StreamReader reader = new StreamReader(fileName); // Создаем поток для чтения файла input
            string[] lines = File.ReadAllLines(fileName); // Читаем файл и записываем строки в массив lines
                                                          // lines - массив строк
            reader.Close(); // Закрываем поток
            
            foreach (string s in lines) // Выводим в консоль строки из файла input (из массива lines)
            {
                Console.WriteLine(s);
            }
            
            int[] luckyNumbers = new int[10]; // Создаем массив luckyNumbers для хранения в нем чисел выбранных орагнизаторами    
            List<int[]> tickets = new List<int[]>(); // Создем список tickets для хранения в нем билетов (массивов с числами)
            
            for (int i = 0; i < lines.Length; i++) // Перебираем элементы (строки) в массиве lines
            {
                if (i == 0) // Если это первая строка (т.е. индекс = 0), то записываем ее в luckyNumbers
                {
                    luckyNumbers = lines[i].Split(' ').Select(int.Parse).ToArray();
                }                    
                else if (i > 1) // Если это третья (четвертая, пятая и т.д.) строка, то сохраняем ее в tickets
                {
                    tickets.Add(lines[i].Split(' ').Select(int.Parse).ToArray());
                }

            }            
            
            fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\output.txt"; // Перезаписываем путь файла       
            StreamWriter writer = new StreamWriter(fileName); // Создаем поток для записи информации в файл output       
            
            foreach (var item in tickets) // Проходимся по билетам
            {
                int luckyCount = 0; // Создаем счетчик luckyNumbers - считает количество счастливых чисел в билете
                for (int i = 0; i < item.Length; i++) // Перебираем числа в билете
                {
                    for (int j = 0; j < luckyNumbers.Length; j++) // Перебираем числа выбранные организаторами и ищем их в билетах
                    {
                        if (item[i] == luckyNumbers[j]) // Если число в билете совпадает с выбранным организаторами, то увеличиваем счетчик на 1
                        {
                            luckyCount += 1;
                        }
                    }
                    
                }
                // После подсчета счастливых чисел в билете делаем проверку на выигрышный билет
                if (luckyCount >= 3)
                {
                    writer.WriteLine("Lucky"); // Записываем результат в файл output
                }
                else
                {
                    writer.WriteLine("Unlucky"); // Записываем результат в файл output
                }
            }
            
            writer.Close(); // Закрываем поток
            
        }
    }
}
