using System;
using System.Collections.Generic;

namespace pr1_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");            
            string line = Console.ReadLine(); // Ввод строки line
                                              
            int word_count = 1; /* word_count - cчетчик слов в строке line.            
            Счетчик изначально равен 1, т.к. в строе будет храниться хотя бы одно слово */                        
            
            for (int i = 0; i < line.Length; i++) // for для перебора строки line и подсчета в ней слов           
                if (line[i] == ' ') // Если элемент в строке равен пробелу, то увеличиваем word_count на 1
                    word_count += 1;
            
            line = line.Insert(0, "Start "); // Добавляем в начало строки слово Start
            line = line.Insert(line.Length, " End"); // Добавляем в конец строки слово End
                                                     
            // Вывод word_count и обновленной line
            Console.Write($"Количество слов в строке: {word_count} \nНовая строка: {line}");

        }
    }
}