using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr5_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Чтени целых чисел из файла
            string fileName = @"C:\Users\public.COPP\Desktop\Galeeva624\numsTask4.txt";
            List<int> nums = new List<int>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    nums = line.Split(' ').Select(Int32.Parse).ToList();
                }
            }
            
            // Поиск максимального числа
            int max = nums[0];
            Console.WriteLine("Числа из файла numsTask4.txt");
            foreach (int item in nums)
            {
                Console.Write($"{item}, ");
                if (item > max)
                {
                    max = item;
                }
            }

            // Вычисление суммы элементов отичающихся от максимального на 1
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
                if (Math.Abs(max - nums[i]) == 1)
                    sum += nums[i];
              
            
            Console.WriteLine($"\nСумма элементов, отличающbхся от максимального на 1 = {sum}");

        }
    }
}