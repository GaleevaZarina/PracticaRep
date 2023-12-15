using System;
using System.Collections.Generic;

namespace pr1_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>(); // Создаем список numbers, который будет хранить введеные пользователем числа
                                                 
            int x; // Создаем переменную x, в которую будем записывать числа, введееные пользователем
                   
            int sum = 0; // Переменная sum для подсчеа суммы всех чисел в списке numbers
                         
            int mult = 1; // Переменная mult для подсчет произведения всех чсиел в списке numbers
                          
            Console.WriteLine("Введите числа в список (чтобы закончить введите 0): ");           
            // С помощью цикла while заполням списо numbers числами и считаем сумму sum и произвдение mult этих чисел
            while (true)           
            {               
                x = int.Parse(Console.ReadLine()); // Ввод чисел пользователем
                
                // Если пользователь введет 0, то ввод прекратится(цикл прекратится)

                if (x == 0)
                {
                    break;
                }                   
                numbers.Add(x); // Добавление полученного числа x в список numbers
                                
                sum += x; // Считаем сумму всех чисел в списке numbers и записываем в переменную sum
                          
                mult *= x; // Считаем произведение всех чисел в списке numbers и записываем в переменную mult
                
            }                      
            int srednee = sum / numbers.Count; // Считаем среднее арифметическое чисел в списке numbers и записываем в переменную srednee
                                               // // Вывод полученных значений: sum(сумма), mult(произведение) и srednee(среднее арифмет)
                                               
            Console.WriteLine($"Сумма всех чисел = {sum} \nПроизвдение всех чисел = {mult} \nСреднее арифметическое = {srednee}");
            
        }
    }
}