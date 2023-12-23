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
            int n = Int32.Parse(Console.ReadLine()); // Ввод любого положительного числа n
            int mult = 1; // Переменная mult для нахождения произведения чисел картных 3 и не превыщающих n 
            for (int i = 3; i < n; i = i + 3) // Пока i < n, с шагом 3, умножаем полученные числа
                mult *= i;

            Console.WriteLine($"Произведение натуральных чисел, не превышающих {n} и кратных трем = {mult}"); //  Вывод результата
        }
        
    }
}