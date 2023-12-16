using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;

namespace pr4_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"C:\Users\public.COPP\Desktop\numsTask2.txt";
            StreamReader reader = new StreamReader(fileName);
            string line = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
            } 
            reader.Close();
            
            double[] numbers = line.Split("; ").Select(double.Parse).ToArray();
            double sum = 0;
            for (int i = 0; numbers[i] != 0; i++)
            {
                if (numbers[i] > 0)
                {
                    sum += numbers[i];
                }
            }
            Console.WriteLine($"Сумма положительных элементов до 0 = {sum}");

        }
    }
}