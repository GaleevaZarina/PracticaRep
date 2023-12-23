using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr5_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Чтени целых чисел из файла
            string fileName = @"C:\Users\public.COPP\Desktop\Galeeva624\numsTask3.txt";
            List<double> nums = new List<double>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    nums = line.Split(',').Select(double.Parse).ToList();
                }
            }

            // Поиск минимального числа и его индекса
            double min = nums[0];
            int minIndex = 0;
            double sum = 0;
            int count = 0;
            Console.WriteLine("Числа из файла numsTask3.txt:");
            for (int i = 0; i<nums.Count; i++)
            {
                Console.Write($"{nums[i]} ");
                if (nums[i] < min)
                {
                    min = nums[i];
                    minIndex = i;
                }
            }

            // подсчет суммы чисел до минимального элемента для вычисления среднего арифметичсекого
            for (int i = 0; i < nums.Count; i++)
            {
                if (i < minIndex)
                {
                    sum += nums[i];
                    count += 1;
                }
            }
          
            // Вывод среднего арифметического
            Console.WriteLine($"\nСреднее арифметическое элементов расположенных до минимального = {sum / count}");
            

        }
    }
}