using System;
using System.Collections.Generic;

namespace pr1_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Ввод начала и конца диапазона, в рамках которого будет заполняться массив
            Console.WriteLine("Введите диапазон чисел:");                       
            Console.Write("Введите начало диапазона - ");                        
            int begin = int.Parse(Console.ReadLine());                        
            Console.Write("Введите конец диапазона - ");                        
            int end = int.Parse(Console.ReadLine());  
            
            int[] numbers = RndNums(begin, end); // Вызываем метод RndNums и записываем то, что он нам возвращает в массив
            
            foreach (int item in numbers)
                Console.Write(item + " "); // foreach выводит элемент массива в одну строку с пробелом между ними
        }                
        
        // Создаем метод RndNums для заполнения массива случайными чсилами
        // Метод принмает 2 параметра: начало и конец диапазона
        public static int[] RndNums(int start, int finish)        
        {            
            Random rnd = new Random();                        
            int n = rnd.Next(5, 20); // Размер массива определяется рандомным числом в диапазоне 5-20
            
            int[] numbers = new int[n]; // Массив numbers
            
            Console.WriteLine($"Массив с числами в диапазоне {start} - {finish}:");  
            
            
            for (int i = 0; i < n; i++) // for заполняет numbers случайными числами в диапазоне start-finish
                numbers[i] = rnd.Next(start, finish);

            return numbers; // Метод возвращает массив numbers
        }
    }
}