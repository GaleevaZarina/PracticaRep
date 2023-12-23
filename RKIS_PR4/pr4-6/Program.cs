using System;
using System.Collections.Generic;
using System.IO;

namespace pr4_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите координаты (a, b):\na = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            
            if ((b >= -3) && (b <= (2 * a) + 2) && (b <= (-2 * a) + 2))    
                Console.WriteLine("Координата принадлежит закрашенной области");
            else    
                Console.WriteLine("Координата не принадлежит закрашенной области");
        }
    }
}