using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;

namespace pr4_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"C:\Users\public.COPP\Desktop\numsTask4.txt";
            StreamReader reader = new StreamReader(fileName);
            string line = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
            }
            reader.Close();

            int[] nums = line.Split(' ').Select(Int32.Parse).ToArray();
            int countRepeat = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i])
                {
                    countRepeat += 1;
                }
            }
            Console.WriteLine($"Количество одинаковых рядом стоящих чисел = {countRepeat}");

        }
    }
}