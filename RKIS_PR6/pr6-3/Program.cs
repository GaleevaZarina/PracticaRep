using System;

namespace pr6_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Получение числа x
            Console.Write("Введите любое число: ");
            int x = int.Parse(Console.ReadLine());

            // Проверка x на четность и кратность 10
            if ((x % 2 == 0) && (x % 10 == 0))
                Console.WriteLine($"Число {x} является четным и кратным 10");
            else
                Console.WriteLine($"Число {x} не является четным и кратным 10");

        }
    }
}