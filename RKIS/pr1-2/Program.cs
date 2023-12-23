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
            
            while (true) // циклом while заполням список numbers числами, считаем сумму sum и произвдение mult этих чисел       
            {               
                x = int.Parse(Console.ReadLine()); // Ввод чисел пользователем
                
                if (x == 0) // Если пользователь введет 0, то ввод прекратится (цикл прекратится)
                {
                    break;
                }                   
                numbers.Add(x); // Добавление полученного числа x в список numbers
                sum += x; // Считаем сумму всех чисел в списке numbers
                mult *= x; // Считаем произведение всех чисел в списке numbers
                
            }                      
            int srednee = sum / numbers.Count; // Считаем среднее арифметическое чисел в списке numbers
            
            // Вывод полученных значений: sum(сумма), mult(произведение) и srednee(среднее арифмет)
            Console.WriteLine($"Сумма всех чисел = {sum} \nПроизвдение всех чисел = {mult} \nСреднее арифметическое = {srednee}");
            
        }
    }
}