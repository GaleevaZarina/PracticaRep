using System;
using System.Collections.Generic;

namespace pr1_3
{
    internal class Program
    {
        public static void Main(string[] args)
        { 
            List<string> lines = new List<string>(); // Создаем список lines для хранения полученных элементов     
            string x; // Переменную x, в которую будем записывать введеные строки
                     
           Console.WriteLine("Введите элементы в список (чтобы закончить введите пустую строку): "); 
           
           while (true) // While для ввода элементов пользователем и записи их в список lines   
           {                
               x = Console.ReadLine(); // Ввод строки x пользователем
               
               if (x == "") // Если введена пустая строка, то прекращаем цикл
               {
                   break;
               }                
               lines.Add(x); // Добавляем полученную стоку x в список lines
           }            
           string maxElement = lines[0]; // maxElement для хранения в ней элемента с наибольшей длинной
                                         
           string minElement = lines[0]; // minElement для хранения в ней элемента с наименьшей длинной
           
           foreach (string item in lines)   // foreach для перебора списка и поиска maxElement и minElement элементов        
           {               
               if (item.Length > maxElement.Length)  // Если длина элемента item больше длины элемента в переменной maxElement, то                 
                   maxElement = item;                // присваиваем переменной maxElement значение item
               if (item.Length < minElement.Length)  // Если длина элемента item < длины элемента в переменной minElement, то
                   minElement = item;                // присваиваем переменной minElement значение item
           }   
           
           // Выводим полученные значения: самый длинный и самый короткий элемент списка
           Console.WriteLine($"Самый длинный элемент списка -  {maxElement} \nСамый короткий элемент списка - {minElement}");

        }
    }
}