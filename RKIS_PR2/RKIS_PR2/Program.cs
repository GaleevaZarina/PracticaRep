using System;
using System.Collections.Generic;

namespace RKIS_PR2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[100]; // Создаем массив numbers размерностью 100
                                          
            numbers[0] = 103; // Первый элемент массива равен 100
            // Заполняем массив numbers с помощью цикла for
            for (int i = 1; i < 100; i++)            
            {                
                numbers[i] = numbers[i - 1] - 3; // присваиваем элемену массива значение на 3 меньше предыдущего элемента
                                                 
                Console.Write(numbers[i] + " "); // Сразу выводим массив numbers
            }
            
        }
    }
}