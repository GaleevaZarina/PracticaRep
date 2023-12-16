using System;
using System.Collections.Generic;

namespace pr1_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           // Создаем список lines для хранения полученных элементов
           List<string> lines = new List<string>();            
           string x; // создаем переменную x, в которую будем записывать введеные пользователем строки
                     
           Console.WriteLine("Введите элементы в список (чтобы закончить введите пустую строку): ");            
           // Используем цикл while для ввода элементов пользователем и записи их в список lines
           while (true)            
           {                
               x = Console.ReadLine(); // Ввод строки x пользователем
                                       // Если пользователь ввел пустую строку x, то прекращаем цикл

               if (x == "")
               {
                   break;
               }                
               lines.Add(x); // Добавляем полученную стоку x в список lines
           }            
           string maxElement = lines[0]; // Создаем переменную maxElement для хранения в ней элемента с наибольшей длинной
                                         
           string minElement = lines[0]; // Создаем переменную minElement для хранения в ней элемента с наименьшей длинной
            
           // С помощью foreach перебираем список и ищем самый длинный и самый короткий элемент
           foreach (string item in lines)            
           {                /* Если длина элемента item больше длины элемента в переменной maxElement, то                 
           присваиваем переменной maxElement значение item */
               if (item.Length > maxElement.Length)
               {
                   maxElement = item;
               }                
               /* Если длина элемента item < длины элемента в переменной minElement, то
                присваиваем переменной minElement значение item */
               if (item.Length < minElement.Length)
               {
                   minElement = item;
               }            
           }            
           // Выводим полученные значения: самый длинный и самый короткий элемент списка

           Console.WriteLine(
               $"Самый длинный элемент списка -  {maxElement} \nСамый короткий элемент списка - {minElement}");

        }
    }
}