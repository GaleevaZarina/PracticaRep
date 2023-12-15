using System;
using System.Collections.Generic;
namespace RKIS
{    
    internal class Program    
    {        
        public static void Main(string[] args)        
        {            
            int[] numbers = new int[10]; // Создаем массив numbers размером 10
            Random rnd = new Random();            
            int min = 100; // Переменная min для поиска минимального числа в массиве
            
            int minindex = 0; // Переменная minindex будет хранить индкекс элемента с минимальным значением
                              
            Console.WriteLine("Массив numbers: "); // Создаем цикл for, заполняем массив numbers случайными числами и ищем минимальный элемент
                                                   
            for (int i = 0; i < numbers.Length; i++)            
            {                
                numbers[i] = rnd.Next(100); // Присваивание случайного числа элементу массива numbers
                /* Если значение элемента масива numbers < min, то присваиваем min значение этого элемента
                 и присваиваем переменной minindex индекс этого элемента */
                if (numbers[i] < min)
                {
                    min = numbers[i];                            
                    minindex = i;
                }                               
                Console.Write($"{numbers[i]}; "); // Выводим массив numbers
                
            }            
            Console.WriteLine($"\nНомер минимального числа = {minindex}"); // Выводим minindex (номер минимального чсила в массива)
            
        }    
    }
    
}