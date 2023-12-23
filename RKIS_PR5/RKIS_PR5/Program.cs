using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RKIS_PR5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Запись целых чисел из файла в лист nums
            string fileName = @"C:\Users\public.COPP\Desktop\Galeeva624\numsTask1.txt";
            StreamReader reader = new StreamReader(fileName);
            List<int> nums = new List<int>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                nums = line.Split(' ').Select(Int32.Parse).ToList(); 
            }
            reader.Close();

            // Поиск минимального элемента и его индекса
            int min = nums[0];
            int minIndex = 0;
            Console.WriteLine("\nЧисла из файла numsTask1.txt:");
            for (int i = 0; i<nums.Count; i++)
            {
                Console.Write($"{nums[i]} "); // вывод листа nums
                if (nums[i] < min)
                {
                    min = nums[i];
                    minIndex = i;
                }
            }

            // Вычисление произвдения чисел расположенных после минимального
            int mult = 1; // произвдение чисел
            for (int i = 0; i < nums.Count; i++)
            {
                if (i > minIndex)
                {
                    mult *= nums[i];
                }
            }
            
            Console.WriteLine($"\nПроизведние элементов расположенных после минимального = {mult}");
        }
    }
}