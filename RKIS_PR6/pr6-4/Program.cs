using System;

namespace pr6_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // ввод положительного числа а
            Console.Write("Введите положительное число a: ");
            int a = int.Parse(Console.ReadLine());
            
            // Ввод положительных чисел и определение суммы чисел, которые делятся на число а нацело
            Console.WriteLine("Введите любые положиетльные числа (при отрицательном ввод прекратится): ");
            int x = 1;
            int sum = 0;
            while (x > 0)
            {
                x = int.Parse(Console.ReadLine());
                if (x < 0)
                    break;
                if (x % a == 0)
                    sum += x;
            }
            
            Console.WriteLine($"Сумма чисел, которые делятся на число a = {sum}");
        }
    }
}