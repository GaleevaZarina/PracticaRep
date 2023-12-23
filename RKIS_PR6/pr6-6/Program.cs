using System;

namespace pr6_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Создание массива со случайным количеством случайных дробных чисел
            Random rnd = new Random();
            int n = rnd.Next(15);
            double[] array = new double[n];

            // Подсчет количества положительных и отрицательных элементов
            int sizePos = 0; // Положительнеы
            int sizeNeg = 0;  // Отрицательные
            Console.WriteLine($"Массив array размером {n}: ");
            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round(rnd.Next(-500, 500)*0.1, 1);
                Console.Write($"{array[i]};   ");
                if (array[i] > 0)
                    sizePos += 1;
                if (array[i] < 0)
                    sizeNeg += 1;
            }

            // Создание массивов с положительными и отрицательными чсилами
            double[] array_positive = new double[sizePos]; // Положительные числа
            double[] array_negative = new double[sizeNeg]; // Отрицательные числа

            // Заполнение массивов соответственными числами
            int indexPos = 0;
            int indexNeg = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > 0)
                {
                    array_positive[indexPos] = array[i];
                    indexPos ++;
                }
                if (array[i] < 0)
                {
                    array_negative[indexNeg] = array[i];
                    indexNeg ++;
                }
            }
            
            // вывод массивов array_positive и  array_negative
            Console.WriteLine($"\n\nМассив положительных чисел: ");
            for (int i = 0; i < sizePos; i++)
                Console.Write($"{array_positive[i]};   ");
            
            Console.WriteLine($"\n\nМассив отрицательных чисел: ");
            for (int i = 0; i < sizeNeg; i++)
                Console.Write($"{array_negative[i]};   ");

        }
    }
}