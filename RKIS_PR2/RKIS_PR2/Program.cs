using System;

namespace RKIS_PR2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[100]; // Создаем массив numbers размерностью 100
                                          
            numbers[0] = 100; // Первый элемент массива равен 100
            
            for (int i = 1; i < 100; i++) // for заполняет массив numbers     
            {                
                numbers[i] = numbers[i - 1] - 3; // присваиваем элемену массива значение на 3 меньше предыдущего элемента
                Console.Write(numbers[i-1] + " "); // Сразу выводим массив numbers
            }
            
        }
    }
}