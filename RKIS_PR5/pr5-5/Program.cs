using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr5_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Чтение целых чисел из файла
            string fileName = @"C:\Users\public.COPP\Desktop\Galeeva624\numsTask5.txt";
            List<double> nums = new List<double>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    nums = line.Split(' ').Select(double.Parse).ToList();
                }
            }
            
            // Поиск максимального и минимального элементов
            double max = nums[0];
            int maxIndex = 0;
            double min = nums[0];
            int minIndex = 0;
            Console.WriteLine("Числа из файла numsTask5.txt:");
            for (int i = 0; i < nums.Count; i++)
            {
                Console.Write($"{nums[i]} ");
                if (nums[i] > max)
                {
                    max = nums[i];
                    maxIndex = i;
                }
                else if (nums[i] < min)
                {
                    min = nums[i];
                    minIndex = i;
                }
            }

            // Вычисление среднего арифметического чисел, расположенных между max и min
            double sum = 0;
            int count = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (minIndex > maxIndex)
                {
                    if (i > maxIndex && i < minIndex)
                    {
                        sum += nums[i];
                        count += 1;
                    }
                }
                else if (minIndex < maxIndex)
                {
                    if (i < maxIndex && i > minIndex)
                    {
                        sum += nums[i];
                        count += 1;
                    }
                }
            }
            
            Console.WriteLine($"\nСреднее арифметичесоке элементов расположенных между минимальным и максимальным = {sum / count}");

        }
    }
}