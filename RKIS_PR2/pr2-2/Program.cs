using System;

namespace pr2_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[10]; // Создаем массив numbers размерностью 10
                                         
            int x = 1; // Значение первого элемента массива numbers
            
            for (int i = 0; i < numbers.Length; i++)  // for заполняет нечетными числами массив numbers
            {
                numbers[i] = x; // Присваиаем элементу массива numbers значение x
                x += 2; // Увеличиваем x на 2, чтобы получить следующее нечетное число
                Console.Write(numbers[i] + " "); // Сразу выводим массив numbers
            }
        }
    }
}