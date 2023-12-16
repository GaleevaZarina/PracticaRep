using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace RKIS_PR4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите любое целое положительное число n: ");
            int n = Int32.Parse(Console.ReadLine());
            int mult = 1;
            for (int i = 3; i < n; i = i + 3)
            {
                mult *= i;
            }

            Console.WriteLine($"Произведение натуральных чисел, не превышающих {n} и кратных трем = {mult}");
        }
        
    }
}