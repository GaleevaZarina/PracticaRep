using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace pr4_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите координаты (a, b):\na = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            
            if(a >= -1 && a <= 3 && b >= -2 && b <=4)
            {
                Console.WriteLine($"Точка с координатами ({a}; {b}) принадлежит заштрихованной области");
            }
            else
            {
                Console.WriteLine($"Точка с координатами ({a}; {b}) не принадлежит заштрихованной области");
            }
        }
    }
}