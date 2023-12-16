using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;

namespace pr4_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = @"C:\Users\public.COPP\Desktop\numsTask3.txt";
            StreamReader reader = new StreamReader(fileName);
            string line = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
            } 
            reader.Close();
            
            int[] numbers = line.Split(", ").Select(Int32.Parse).ToArray();
            int max = 0;
            
            for (int i = 0; numbers[i] != 0; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            int min = max;
            for (int i = 0; numbers[i] != 0; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            Console.WriteLine($"max = {max}\nmin = {min}\nОтношение минимального и максимального элементов друг к другу {(double) min/max}");

            
        }
    }
}