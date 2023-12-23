using System;
using System.IO;
using System.Linq;

namespace pr3_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"D:\ТТИТ\РКИС\Практика\КОДЫ\RKIS_PR3\water.txt"; // Создаем переменную fileName, чтобы хранить в ней путь к файлу water
           
            string line = ""; // Создаем пустую строку line, чтобы записать в нее прочитанные из файла строки
            StreamReader reader = new StreamReader(fileName); // Создаем поток для чтения файла water
            
            while (!reader.EndOfStream) // Читаем файл water построчно и записываем в line
            {
                line = reader.ReadLine();
            }
            reader.Close(); // Закрываем поток

            // Создаем массив height и записываем в него полученные числа
            int[] height = line.Split(' ').Select(int.Parse).ToArray(); 

            int maxWater = 0; // Создаем переменную maxWater, в которую будем записывать содержание наибольшего количества воды
            
            
            // ИСпользуем уикл в цикле и сравниваем между собой элементы массива (вертикальные линии)
            for (int i = 0; i < height.Length; i++)
            {
                Console.Write($"{height[i]} "); // Выводим числа, которые были записаны в файле water
                int countWater =
                    1; // Создаем счетчик наибольшего количества воды, при каждой новой итерации обнуляем его до 1

                for (int j = 0; j < height.Length; j++)
                {
                    if (height[i] >= height[j]) // Проверяем какой из сверяемых столбцов меньше
                    {
                        countWater =
                            height[j] * Math.Abs((j - i)); // Записываем в счетчик произведение наименьшего столбца
                        // и расстояния между этими столбцами
                    }
                    else if (height[i] <= height[j]) // Проверяем какой из сверяемых столбцов меньше
                    {
                        countWater =
                            height[i] * Math.Abs((j - i)); // Записываем в счетчик произведение наименьшего столбца
                        // и расстояния между этими столбцами
                    }

                    if (countWater > maxWater) // Проверка на наибольшее колчисетво воды
                    {
                        maxWater = countWater;
                    }
                }
            }
            
            Console.WriteLine("\n" + maxWater); // Выводим полученный результат
            
        }
    }
}