using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace pr5_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Запись вещественных чисел из файла в лист nums
            string fileName = @"C:\Users\public.COPP\Desktop\КОДЫ\RKIS_PR5\numsTask2.txt";
            List<double> nums = new List<double>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    nums = line.Split(';').Select(double.Parse).ToList();
                }
            }
            
            // Алгоритм, сортирующий числа по возрастанию
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = 1; j < nums.Count; j++)
                {
                    if (nums[j] < nums[j-1])
                    {
                        double x = nums[j];
                        nums[j] = nums[j-1];
                        nums[j-1] = x;
                    }
                }
            }

            // Запись отсортированного списка обратно в файл
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (double item in nums)
                {
                    writer.Write($"{item}; ");
                }
            }

            
            
            
        }
    }
}