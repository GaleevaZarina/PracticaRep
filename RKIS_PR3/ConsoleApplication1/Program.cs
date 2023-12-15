using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\input.txt"; // Создаем переменную fileName для хранения в ней пути к файлу input.txt
            StreamReader reader = new StreamReader(fileName); // Создаем поток reader для чтения файла input
            string[] lines = File.ReadAllLines(fileName); // Читаем весь файл целиком и получаем массив строк lines
            reader.Close(); // Закрываем поток
            
            // Выводим содержимое файла input (массив lines) в консоль
            foreach (string s in lines)
            {
                Console.WriteLine(s);
            }
            
            int[] luckyNumbers = new int[10]; // Создаем массив luckyNumbers, в котором будет хранить числа выбранные организаторами (первую строку массива lines)
            List<int[]> tickets = new List<int[]>(); // Создаем список tickets, в который запишем билеты с числами
                                                     // Билеты с числами будут хранится в виде массива
            
            for (int i = 0; i < lines.Length; i++) // С помощью цикла for проходимся по массиву строк (массив lines)
            {
                if (i == 0) // Если это первая строка (т.е. с индексом = 0), то записываем ее в массив luckyNumbers
                {
                    luckyNumbers = lines[i].Split(' ').Select(int.Parse).ToArray();
                }                    
                else if (i > 1) // Если это третья (четвертая, пятая и т.д.) строка (т.е. ее индекс > 1), то добавляем эту строку с список tickets
                {
                    tickets.Add(lines[i].Split(' ').Select(int.Parse).ToArray());
                }
            }            
            
            fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\output.txt"; // Перезаписываем переменную fileName  
            StreamWriter writer = new StreamWriter(fileName); // Создаем поток reader для записи информации в файл output       
            
            foreach (var item in tickets) // С помощью foreach проходимся по элементам списка tickets (в нем хранятся массивы чисел)
            {
                int luckyCount = 0; // Создаем переменную luckyCount, которая нужна для подсчета счастливых числе в билете
                for (int i = 0; i < item.Length; i++) // С помощью for проходимся по массиву чисел (по билету)
                {
                    for (int j = 0; j < luckyNumbers.Length; j++) // Используя второй for проходимся по luckyNumbers и ищем счастливые числа в билете
                    {
                        if (item[i] == luckyNumbers[j]) // Если число билета совпадает с числом, выбранным организатором, то увелииваем счетчик luckyCount на 1
                        {
                            luckyCount += 1;
                        }
                    }
                    
                }
                // После подсчета счастливых чисел в билете делаем проверку на выигрышный билет
                if (luckyCount >= 3)
                {
                    writer.WriteLine("Lucky"); // Записываем полученный результат в файл output
                }
                else
                {
                    writer.WriteLine("Unlucky"); // Записываем полученный результат в файл output
                }
            }
            
            writer.Close(); // Закрываем поток
            
        }
    }
}